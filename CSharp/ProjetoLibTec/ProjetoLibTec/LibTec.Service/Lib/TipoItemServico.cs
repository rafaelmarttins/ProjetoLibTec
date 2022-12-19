using LibTec.Domain.EF;
using LibTec.Poco;
using LibTec.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibTec.Service.Lib
{
    public class TipoItemServico : GenericService<TipoItem, TipoItemPoco>
    {
        public TipoItemServico(LibTecContexto contexto) : base(contexto) 
        { }

        public override List<TipoItemPoco> Consultar(Expression<Func<TipoItem, bool>>? predicate = null)
        {
            IQueryable<TipoItem> query;
            if (predicate == null)
            {
                query = this.genrepo.Browseable(null);
            }
            else
            {
                query = this.genrepo.Browseable(predicate);
            }
            return this.ConverterPara(query);
        }

        public override List<TipoItemPoco> Listar(int? take = null, int? skip = null)
        {
            IQueryable<TipoItem> query;
            if (skip == null)
            {
                query = this.genrepo.GetAll();
            }
            else
            {
                query = this.genrepo.GetAll(take, skip);
            }
            return ConverterPara(query);
        }

        public override List<TipoItemPoco> Vasculhar(int? take = null, int? skip = null, Expression<Func<TipoItem, bool>>? predicate = null)
        {
            IQueryable<TipoItem> query;
            if (skip == null)
            {
                if (predicate == null)
                {
                    query = this.genrepo.Browseable(null);
                }
                else
                {
                    query = this.genrepo.Browseable(predicate);
                }
            }
            else
            {
                if (predicate == null)
                {
                    query = this.genrepo.GetAll(take, skip);
                }
                else
                {
                    query = this.genrepo.Searchable(take, skip, predicate);
                }
            }
            return this.ConverterPara(query);
        }

        public override List<TipoItemPoco> ConverterPara(IQueryable<TipoItem> query)
        {
            return query.Select(aut =>
                     new TipoItemPoco()
                     {
                         CodigoTipoItem = aut.CodigoTipoItem,
                         Descricao = aut.Descricao,
                         Situacao = aut.Situacao,
                         DataDeInsercao = aut.DataDeInsercao,
                         DataDeAlteracao = aut.DataDeAlteracao,
                         DataDeExclusao = aut.DataDeExclusao,
                     }
             )
             .ToList();
        }
    }
}
