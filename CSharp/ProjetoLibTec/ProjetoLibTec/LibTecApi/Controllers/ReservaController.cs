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
    public class ReservaController : ControllerBase
    {
        private ReservaServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public ReservaController(LibTecContexto context) : base()
        {
            this.servico = new ReservaServico(context);
        }

        /// <summary>
        /// Lista todos os registros da tabela Reserva por Paginação.
        /// </summary>
        /// <param name="take"> Onde inicia os resultados da pesquisa. </param>
        /// <param name="skip"> Quantos registros serão retornados. </param>
        /// <returns> Todos os registros. </returns>
        [HttpGet]
        public ActionResult<List<ReservaPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<ReservaPoco> lista = this.servico.Listar(take, skip);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        /// <summary>
        /// Listar todos os registros da tabela Reserva por código de Tipo Status Reserva.
        /// </summary>
        /// <param name="rescodigo"> Chave de pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("PorStatusReserva/{rescodigo:int}")]
        public ActionResult<List<ReservaPoco>> GetByStatusReserva(int rescodigo)
        {
            try
            {
                List<ReservaPoco> listaPoco = this.servico.Consultar(res => res.CodigoStatus == rescodigo).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        /// <summary>
        ///  Lista os registro usando a chave de Reserva.
        /// </summary>
        /// <param name="chave"> Chave de pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("{chave:int}")]
        public ActionResult<ReservaPoco> GetById(int chave)
        {
            try
            {
                ReservaPoco poco = this.servico.PesquisarPelaChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Inclui um novo dado na tabela Reserva.
        /// </summary>
        /// <param name="poco"> Dados que será incluido. </param>
        /// <returns> Dados incluido. </returns>
        [HttpPost]
        public ActionResult<ReservaPoco> Post([FromBody] ReservaPoco poco)
        {
            try
            {
                ReservaPoco novoPoco = this.servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Altera um dado existente na tabela Reserva.
        /// </summary>
        /// <param name="poco"> Altera o dado selecionado. </param>
        /// <returns> Altera o dado selecionado. </returns>
        [HttpPut]
        public ActionResult<ReservaPoco> Put([FromBody] ReservaPoco poco)
        {
            try
            {
                ReservaPoco novoPoco = this.servico.Alterar(poco);
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
        public ActionResult<ReservaPoco> DeleteById(int chave)
        {
            try
            {
                ReservaPoco poco = this.servico.Excluir(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
