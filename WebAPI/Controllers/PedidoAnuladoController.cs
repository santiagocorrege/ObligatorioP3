using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DTO.DTOS.Pedido;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Articulo;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Pedidos;
using Papeleria.LogicaNegocio.Excepciones.Articulo;
using Papeleria.LogicaNegocio.Excepciones.Pedido;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    /// <summary>
    /// Controlador para gestionar pedidos anulados.
    /// Proporciona operaciones para obtener una lista de pedidos que han sido anulados.
    /// </summary>
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoAnuladoController : ControllerBase
    {
        private IGetPedidosAnulados _getPedidosAnulados;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="PedidoAnuladoController"/> con las dependencias necesarias.
        /// </summary>
        /// <param name="getPedidosAnulados">Servicio para obtener los pedidos anulados.</param>
        public PedidoAnuladoController(IGetPedidosAnulados getPedidosAnulados)
        {
            _getPedidosAnulados = getPedidosAnulados;
        }

        /// <summary>
        /// Obtiene todos los pedidos anulados.
        /// </summary>
        /// <returns>Una lista de pedidos anulados si existen, NotFound si no hay ninguno.</returns>
        /// <response code="200">Devuelve la lista de pedidos anulados.</response>
        /// <response code="404">Si no hay pedidos anulados.</response>
        /// <response code="400">Si ocurre un error relacionado con la obtención de pedidos.</response>
        /// <response code="500">Si ocurre un error interno del servidor.</response>
        [HttpGet]
        public ActionResult<IEnumerable<DtoPedidoNoEntregado>> Get()
        {
            try
            {
                var pedidos = _getPedidosAnulados.Ejecutar();
                if (!pedidos.Any()) { return NotFound(); }
                return Ok(pedidos);
            }
            catch (PedidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //// GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ValuesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
