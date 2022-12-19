using LibTec.Domain.EF;
using LibTec.Mapping.Base;
using LibTec.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibTec.Service.Base
{
    public class GenericService<TDominio, TPoco> : IGenericService<TDominio, TPoco>
       where TDominio : class
       where TPoco : class
    {
        protected GenericRepository<TDominio> genrepo;

        protected GenericMap<TDominio, TPoco> genmap;

        public GenericService(LibTecContexto context)
        {
            this.genrepo = new GenericRepository<TDominio>(context);

            this.genmap = new GenericMap<TDominio, TPoco>();
        }

        public List<TPoco> Listar()
        {
            return this.Consultar(null);
        }

        public virtual List<TPoco> Listar(int? take = null, int? skip = null)
        {
            throw new NotImplementedException();
        }

        public virtual List<TPoco> Consultar(Expression<Func<TDominio, bool>>? predicate = null)
        {
            throw new NotImplementedException();
        }

        public virtual List<TPoco> Vasculhar(int? take = null, int? skip = null, Expression<Func<TDominio, bool>>? predicate = null)
        {
            throw new NotImplementedException();
        }

        public TPoco? PesquisarPelaChave(object chave)
        {
            TDominio? lida = this.genrepo.GetById(chave);
            TPoco? lidaPoco = null;
            if (lida != null)
            {
                lidaPoco = this.ConverterPara(lida);
            }
            return lidaPoco;
        }

        public TPoco? Inserir(TPoco poco)
        {
            TDominio? nova = this.ConverterPara(poco);
            TDominio? criada = this.genrepo.Insert(nova);
            TPoco? criadaPoco = null;
            if (criada != null)
            {
                criadaPoco = this.ConverterPara(criada);
            }
            return criadaPoco;
        }

        public TPoco? Alterar(TPoco poco)
        {
            TDominio? editada = this.ConverterPara(poco);
            TDominio? alterada = this.genrepo.Update(editada);
            TPoco? alteradaPoco = null;
            if (alterada != null)
            {
                alteradaPoco = this.ConverterPara(alterada);
            }
            return alteradaPoco;
        }

        public TPoco? Excluir(object chave)
        {
            TDominio? del = this.genrepo.Delete(chave);
            TPoco? delPoco = null;
            if (del != null)
            {
                delPoco = this.ConverterPara(del);
            }
            return delPoco;
        }

        public TDominio ConverterPara(TPoco poco)
        {
            return this.genmap.Mapping.Map<TDominio>(poco);
        }

        public TPoco ConverterPara(TDominio dominio)
        {
            return this.genmap.Mapping.Map<TPoco>(dominio);
        }

        public virtual List<TPoco> ConverterPara(IQueryable<TDominio> query)
        {
            throw new NotImplementedException();
        }
    }
}
