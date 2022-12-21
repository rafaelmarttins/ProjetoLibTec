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
    public class TipoStatusEmprestimoServico : GenericService<TipoStatusEmprestimo, TipoStatusEmprestimoPoco>
    {
        public TipoStatusEmprestimoServico(LibTecContexto contexto) : base(contexto)
        { }

        public override List<TipoStatusEmprestimoPoco> Consultar(Expression<Func<TipoStatusEmprestimo, bool>>? predicate = null)
        {
            IQueryable<TipoStatusEmprestimo> query;
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

        public override List<TipoStatusEmprestimoPoco> Listar(int? take = null, int? skip = null)
        {
            IQueryable<TipoStatusEmprestimo> query;
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

        public override List<TipoStatusEmprestimoPoco> Vasculhar(int? take = null, int? skip = null, Expression<Func<TipoStatusEmprestimo, bool>>? predicate = null)
        {
            IQueryable<TipoStatusEmprestimo> query;
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

        public override List<TipoStatusEmprestimoPoco> ConverterPara(IQueryable<TipoStatusEmprestimo> query)
        {
            return query.Select(res =>
                     new TipoStatusEmprestimoPoco()
                     {
                         CodigoTipoStatusEmprestimo = res.CodigoTipoStatusEmprestimo,
                         Descricao = res.Descricao,
                         Situacao = res.Situacao,
                         DataDeInsercao = res.DataDeInsercao,
                         DataDeAlteracao = res.DataDeAlteracao,
                         DataDeExclusao = res.DataDeExclusao,
                     }
             )
             .ToList();
        }
    }
}
