using Microsoft.AspNetCore.Mvc;
using Papeleria.AccesoDatos.EF;
using Papeleria.LogicaAplicacion.DTO.DTOS.Articulo;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Articulo;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Articulo;
using Papeleria.LogicaNegocio.Excepciones.Articulo;
using Papeleria.LogicaNegocio.InterfacesRepositorios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    /// <summary>
    /// Controlador para la gestión de artículos. Proporciona operaciones para consultar los artículos de manera alfabética.
    /// </summary>
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private IGetArticulosAlfabeticamente _getArticulos;
        public ArticuloController(IGetArticulosAlfabeticamente getArticulosAlfabeticamente)
        {
            _getArticulos = getArticulosAlfabeticamente;
        }

        /// <summary>
        /// Obtiene todos los artículos ordenados alfabéticamente.
        /// </summary>
        /// <returns>Una acción que devuelve una lista de artículos. Retorna NotFound si no hay artículos.</returns>
        /// <response code="200">Devuelve la lista de artículos.</response>
        /// <response code="404">Si no hay artículos disponibles.</response>
        /// <response code="400">Si ocurre un error al obtener los artículos.</response>
        /// <response code="500">Si ocurre un error interno del servidor.</response>
        [HttpGet]
        public ActionResult<IEnumerable<DtoArticuloCompleto>> Get()
        {
            try
            {
                var articulos = _getArticulos.Ejecutar();
                if(!articulos.Any()) { return NotFound(); }
                return Ok(articulos);
            }
            catch(ArticuloException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //// GET api/<ArticulosController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ArticulosController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ArticulosController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ArticulosController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
