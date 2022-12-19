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
    public class ItemController : ControllerBase
    {
        private ItemServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public ItemController(LibTecContexto context) : base()
        {
            this.servico = new ItemServico(context);
        }

        /// <summary>
        /// Lista todos os registros da tabela Item por Paginação.
        /// </summary>
        /// <param name="take"> Onde inicia os resultados da pesquisa. </param>
        /// <param name="skip"> Quantos registros serão retornados. </param>
        /// <returns> Todos os registros. </returns>
        [HttpGet]
        public ActionResult<List<ItemPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<ItemPoco> lista = this.servico.Listar(take, skip);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        /// <summary>
        /// Listar todos os registros da tabela Item por código de Tipo Item.
        /// </summary>
        /// <param name="tipcodigo"> Chave de pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("PorTipoItem/{tipcodigo:int}")]
        public ActionResult<List<ItemPoco>> GetByTipoItem(int tipcodigo)
        {
            try
            {
                List<ItemPoco> listaPoco = this.servico.Consultar(res => res.CodigoTipoItem == tipcodigo).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        /// <summary>
        ///  Lista os registro usando a chave de Item.
        /// </summary>
        /// <param name="chave"> Chave de pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("{chave:int}")]
        public ActionResult<ItemPoco> GetById(int chave)
        {
            try
            {
                ItemPoco poco = this.servico.PesquisarPelaChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Inclui um novo dado na tabela Item.
        /// </summary>
        /// <param name="poco"> Dados que será incluido. </param>
        /// <returns> Dados incluido. </returns>
        [HttpPost]
        public ActionResult<ItemPoco> Post([FromBody] ItemPoco poco)
        {
            try
            {
                ItemPoco novoPoco = this.servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Altera um dado existente na tabela Item.
        /// </summary>
        /// <param name="poco"> Altera o dado selecionado. </param>
        /// <returns> Altera o dado selecionado. </returns>
        [HttpPut]
        public ActionResult<ItemPoco> Put([FromBody] ItemPoco poco)
        {
            try
            {
                ItemPoco novoPoco = this.servico.Alterar(poco);
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
        public ActionResult<ItemPoco> DeleteById(int chave)
        {
            try
            {
                ItemPoco poco = this.servico.Excluir(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
