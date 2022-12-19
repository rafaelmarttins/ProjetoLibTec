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
    public class TipoStatusReservaController : ControllerBase
    {
        private TipoStatusReservaServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public TipoStatusReservaController(LibTecContexto context) : base()
        {
            this.servico = new TipoStatusReservaServico(context);
        }

        /// <summary>
        /// Lista todos os registros da tabela Tipo Status Reserva por Paginação.
        /// </summary>
        /// <param name="take"> Onde inicia os resultados da pesquisa. </param>
        /// <param name="skip"> Quantos registros serão retornados. </param>
        /// <returns> Todos os registros. </returns>
        [HttpGet]
        public ActionResult<List<TipoStatusReservaPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<TipoStatusReservaPoco> lista = this.servico.Listar(take, skip);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        ///  Lista os registro usando a chave de Tipo Status Reserva.
        /// </summary>
        /// <param name="chave"> Chave de pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("{chave:int}")]
        public ActionResult<TipoStatusReservaPoco> GetById(int chave)
        {
            try
            {
                TipoStatusReservaPoco poco = this.servico.PesquisarPelaChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Inclui um novo dado na tabela Tipo Status Reserva.
        /// </summary>
        /// <param name="poco"> Dados que será incluido. </param>
        /// <returns> Dados incluido. </returns>
        [HttpPost]
        public ActionResult<TipoStatusReservaPoco> Post([FromBody] TipoStatusReservaPoco poco)
        {
            try
            {
                TipoStatusReservaPoco novoPoco = this.servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Altera um dado existente na tabela Tipo Status Reserva.
        /// </summary>
        /// <param name="poco"> Altera o dado selecionado. </param>
        /// <returns> Altera o dado selecionado. </returns>
        [HttpPut]
        public ActionResult<TipoStatusReservaPoco> Put([FromBody] TipoStatusReservaPoco poco)
        {
            try
            {
                TipoStatusReservaPoco novoPoco = this.servico.Alterar(poco);
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
        public ActionResult<TipoStatusReservaPoco> DeleteById(int chave)
        {
            try
            {
                TipoStatusReservaPoco poco = this.servico.Excluir(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
