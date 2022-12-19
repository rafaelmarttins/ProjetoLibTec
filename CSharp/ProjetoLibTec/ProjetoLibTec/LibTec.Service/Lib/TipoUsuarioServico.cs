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
    public class TipoUsuarioServico : GenericService<TipoUsuario, TipoUsuarioPoco>
    {
        public TipoUsuarioServico(LibTecContexto contexto) : base(contexto)
        { }

        public override List<TipoUsuarioPoco> Consultar(Expression<Func<TipoUsuario, bool>>? predicate = null)
        {
            IQueryable<TipoUsuario> query;
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

        public override List<TipoUsuarioPoco> Listar(int? take = null, int? skip = null)
        {
            IQueryable<TipoUsuario> query;
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

        public override List<TipoUsuarioPoco> Vasculhar(int? take = null, int? skip = null, Expression<Func<TipoUsuario, bool>>? predicate = null)
        {
            IQueryable<TipoUsuario> query;
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

        public override List<TipoUsuarioPoco> ConverterPara(IQueryable<TipoUsuario> query)
        {
            return query.Select(tip =>
                     new TipoUsuarioPoco()
                     {
                         CodigoTipoUsuario = tip.CodigoTipoUsuario,
                         Descricao = tip.Descricao,
                         Situacao = tip.Situacao,
                         DataDeInsercao = tip.DataDeInsercao,
                         DataDeAlteracao = tip.DataDeAlteracao,
                         DataDeExclusao = tip.DataDeExclusao,
                     }
             )
             .ToList();
        }
    }
}
