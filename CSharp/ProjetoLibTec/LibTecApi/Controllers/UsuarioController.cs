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
    public class UsuarioController : ControllerBase
    {
        private UsuarioServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public UsuarioController(LibTecContexto context) : base()
        {
            this.servico = new UsuarioServico(context);
        }

        /// <summary>
        /// Lista todos os registros da tabela Usuario por Paginação.
        /// </summary>
        /// <param name="take"> Onde inicia os resultados da pesquisa. </param>
        /// <param name="skip"> Quantos registros serão retornados. </param>
        /// <returns> Todos os registros. </returns>
        [HttpGet]
        public ActionResult<List<UsuarioPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<UsuarioPoco> lista = this.servico.Listar(take, skip);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Listar todos os registros da tabela Usuario por código de Tipo Usuario.
        /// </summary>
        /// <param name="tipcodigo"> Chave de pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("PorTipoUsuario/{tipcodigo:int}")]
        public ActionResult<List<UsuarioPoco>> GetByTipoUsuario(int tipcodigo)
        {
            try
            {
                List<UsuarioPoco> listaPoco = this.servico.Consultar(usu => usu.CodigoTipoUsuario == tipcodigo).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Listar todos os registros da tabela Usuario por código de Maximo Emprestimo.
        /// </summary>
        /// <param name="maxcod"> Chave de pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("PorMaximoEmprestimo/{maxcod:int}")]
        public ActionResult<List<UsuarioPoco>> GetByMaxEmprestimo(int maxcod)
        {
            try
            {
                List<UsuarioPoco> listaPoco = this.servico.Consultar(usu => usu.MaxEmprestimos == maxcod).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        ///  Lista os registro usando a chave de Usuario.
        /// </summary>
        /// <param name="chave"> Chave de pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("{chave:int}")]
        public ActionResult<UsuarioPoco> GetById(int chave)
        {
            try
            {
                UsuarioPoco poco = this.servico.PesquisarPelaChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Inclui um novo dado na tabela Usuario.
        /// </summary>
        /// <param name="poco"> Dados que será incluido. </param>
        /// <returns> Dados incluido. </returns>
        [HttpPost]
        public ActionResult<UsuarioPoco> Post([FromBody] UsuarioPoco poco)
        {
            try
            {
                UsuarioPoco novoPoco = this.servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Altera um dado existente na tabela Usuario.
        /// </summary>
        /// <param name="poco"> Altera o dado selecionado. </param>
        /// <returns> Altera o dado selecionado. </returns>
        [HttpPut]
        public ActionResult<UsuarioPoco> Put([FromBody] UsuarioPoco poco)
        {
            try
            {
                UsuarioPoco novoPoco = this.servico.Alterar(poco);
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
        public ActionResult<UsuarioPoco> DeleteById(int chave)
        {
            try
            {
                UsuarioPoco poco = this.servico.Excluir(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
