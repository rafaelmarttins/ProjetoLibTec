using LibTec.Domain.EF;
using LibTec.Poco;
using LibTec.Service.Lib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibTecApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/lib/[controller]")]
    [ApiController]
    public class EmprestimoController : ControllerBase
    {
        private EmprestimoServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public EmprestimoController(LibTecContexto context) : base()
        {
            this.servico = new EmprestimoServico(context);
        }

        /// <summary>
        /// Lista todos os registros da tabela Emprestimo por Paginação.
        /// </summary>
        /// <param name="take"> Onde inicia os resultados da pesquisa. </param>
        /// <param name="skip"> Quantos registros serão retornados. </param>
        /// <returns> Todos os registros. </returns>
        [HttpGet]
        public ActionResult<List<EmprestimoPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<EmprestimoPoco> lista = this.servico.Listar(take, skip);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        /// <summary>
        /// Listar todos os registros da tabela Emprestimo por código de Tipo Status Emprestimo.
        /// </summary>
        /// <param name="empcodigo"> Chave de pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("PorStatusEmprestimo/{empcodigo:int}")]
        public ActionResult<List<EmprestimoPoco>> GetByStatusEmprestimo(int empcodigo)
        {
            try
            {
                List<EmprestimoPoco> listaPoco = this.servico.Consultar(res => res.CodigoStatus == empcodigo).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        /// <summary>
        ///  Lista os registro usando a chave de Emprestimo.
        /// </summary>
        /// <param name="chave"> Chave de pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("{chave:int}")]
        public ActionResult<EmprestimoPoco> GetById(int chave)
        {
            try
            {
                EmprestimoPoco poco = this.servico.PesquisarPelaChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Inclui um novo dado na tabela Emprestimo.
        /// </summary>
        /// <param name="poco"> Dados que será incluido. </param>
        /// <returns> Dados incluido. </returns>
        [HttpPost]
        public ActionResult<EmprestimoPoco> Post([FromBody] EmprestimoPoco poco)
        {
            try
            {
                EmprestimoPoco novoPoco = this.servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Altera um dado existente na tabela Emprestimo.
        /// </summary>
        /// <param name="poco"> Altera o dado selecionado. </param>
        /// <returns> Altera o dado selecionado. </returns>
        [HttpPut]
        public ActionResult<EmprestimoPoco> Put([FromBody] EmprestimoPoco poco)
        {
            try
            {
                EmprestimoPoco novoPoco = this.servico.Alterar(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Exclui um registro existente no recurso, utilizando um id.
        /// </summary>
        /// <param name="chave"> Chave para localização. </param>
        /// <returns> Dado excluido por Id. </returns>
        [HttpDelete("{chave:int}")]
        public ActionResult<EmprestimoPoco> DeleteById(int chave)
        {
            try
            {
                EmprestimoPoco poco = this.servico.Excluir(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
