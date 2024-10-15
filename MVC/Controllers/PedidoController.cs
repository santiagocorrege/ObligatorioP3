using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Filters;
using Papeleria.AccesoDatos.EF;
using Papeleria.LogicaAplicacion.DTO.DTOS.Cliente;
using Papeleria.LogicaAplicacion.DTO.DTOS.Lineas;
using Papeleria.LogicaAplicacion.DTO.DTOS.Pedido;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Articulo;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Cliente;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Pedido;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Articulo;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Cliente;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Pedidos;
using Papeleria.LogicaNegocio.Excepciones.Pedido;
using Papeleria.LogicaNegocio.InterfacesRepositorios;
using System.Text.Json;

namespace MVC.Controllers
{
    public class PedidoController : Controller
    {
        private IGetClienteByNombre _getClienteByNombre;
        private IGetAllCliente _getAllCliente;
        private IGetClienteById _getClienteById;

        private IAddPedido _addPedido;
        private IGetAllPedido _getAllPedidos;
        private IGetPedidoById _getPedidoById;
        private IGetPedidosNoEntregadosFecha _getPedidosNoEntregadosFecha;
        private IAnularPedido _anularPedido;

        private IGetArticulosAlfabeticamente _getArticulos;

        public PedidoController(IGetClienteByNombre getClienteByNombre, IGetAllCliente getAllCliente, IGetClienteById getClienteById, IAddPedido addPedido, IGetArticulosAlfabeticamente getArticulosAlfabeticamente, IGetAllPedido getAllPedido, IGetPedidoById getPedidoById, IGetPedidosNoEntregadosFecha getPedidosNoEntregadosFecha, IAnularPedido anularPedido) 
        {
            _getAllCliente = getAllCliente;
            _getClienteByNombre = getClienteByNombre;
            _getClienteById = getClienteById;
            _addPedido = addPedido;
            _getArticulos = getArticulosAlfabeticamente;
            _getAllPedidos = getAllPedido;
            _getPedidoById = getPedidoById;
            _getPedidosNoEntregadosFecha = getPedidosNoEntregadosFecha;
            _anularPedido = anularPedido;
        }


        // GET: PedidoController
        [AdminFilter]
        public ActionResult Index()
        {
            try
            {
                var pedidos = _getAllPedidos.Ejecutar();
                if (pedidos == null || pedidos.Count() == 0)
                {
                    throw new Exception("No existen pedidos registrados");
                }
                else
                {
                    return View(pedidos);
                }
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }            
        }

        [AdminFilter]
        public ActionResult PedidoSelectCliente(IEnumerable<DtoClienteCompleto>? clientesFiltrados)
        {
            var clientes = _getAllCliente.Ejecutar();
            return View(clientes);
        }

        [AdminFilter]
        [HttpPost]
        public ActionResult PedidoSelectCliente(string nombreCliente)
        {
            try
            {
                if (nombreCliente == null)
                {
                    throw new Exception("Ingrese un nombre valido para poder filtrar los clientes");
                }
                var clientes = _getClienteByNombre.Ejecutar(nombreCliente);
                if (clientes == null || clientes.Count() == 0)
                {
                    throw new Exception("No existen clientes que posean un pedido con un costo superior al ingresado");
                }
                else if(clientes.Count() > 1)
                {
                    //ACA YA TENGO QUE ENVIAR A AGREGAR PEDIDO
                    return View("PedidoSelectCliente", clientes);
                }
                else
                {
                    int idClient = clientes.First(c => c.Id != null).Id;
                    return RedirectToAction("Create", new { id = idClient});
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [AdminFilter]
        public ActionResult GetPedidosNoEntregadosFecha()
        {
            return View();
        }

        [AdminFilter]
        [HttpPost]
        public ActionResult GetPedidosNoEntregadosFecha(DateTime fecha)
        {
            //IF MONTO VACIO
            try
            {
                if (fecha == null || fecha == DateTime.MinValue) throw new ArgumentNullException("La fecha del pedido no puede ser nula");
                var pedidos = _getPedidosNoEntregadosFecha.Ejecutar(fecha);
                if (pedidos == null || pedidos.Count() == 0)
                {
                    throw new Exception("No existen pedidos no entregados realizados en la fecha ingresada");
                }
                else
                {
                    ViewBag.Mensaje = "Pedidos filtrados";
                    return View("GetPedidosNoEntregadosFecha", pedidos);
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("GetPedidosNoEntregadosFecha");

            }
        }
        [AdminFilter]
        public ActionResult AnularPedido (int? id)
        {
            try
            {
                if (id == null || id == 0) throw new PedidoException("El id de pedido no es valido");
                _anularPedido.Ejecutar(id.GetValueOrDefault());
                TempData["Mensaje"] = "Pedido anulado";
                return RedirectToAction("GetPedidosNoEntregadosFecha");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("GetPedidosNoEntregadosFecha");
            }
        }
        [AdminFilter]
        // GET: PedidoController/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null || id == 0) throw new PedidoException("El id de pedido no es valido");
                var pedido = _getPedidoById.Ejecutar(id.GetValueOrDefault());
                return View(pedido);

            }
            catch(Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
        }

        [AdminFilter]
        // GET: PedidoController/Create
        public ActionResult Create(int id)
        {
            try
            {
                SetListasViewBag(null);
                HttpContext.Session.SetString("SessionPedidoDto", "");
                ViewBag.Articulos = TempData["Articulos"];
                if (id == 0 || id == null)
                {
                    TempData["Error"] = "No puede crear un pedido sin seleccionar un cliente antes";
                    return View("PedidoSelectCliente");
                }
                var dtoCliente = _getClienteById.Ejecutar(id);
                DtoPedidoAdd dtoP = new DtoPedidoAdd() { ClienteId = id, ClienteNombre = dtoCliente.RazonSocial };
                return View(dtoP);
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Create", id);
            }                       
        }

        // POST: PedidoController/Create
        [AdminFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DtoPedidoAdd dto)
        {
            try
            {
                bool error = false;
                if(dto == null)
                {
                    ViewBag.Error = "No se pudo guardar el pedido";
                    error = true;
                }
                var dtoPedidoRecuperado = GetPedidoFromSession();
                dtoPedidoRecuperado.FechaEntrega = dto.FechaEntrega;
                dtoPedidoRecuperado.ClienteId = dto.ClienteId;
                dtoPedidoRecuperado.Tipo = dto.Tipo;
                if (dtoPedidoRecuperado == null || dtoPedidoRecuperado.Lineas == null || dtoPedidoRecuperado.Lineas.Count == 0)
                {
                    ViewBag.Error = "No se han agregado articulos al pedido";
                    error = true;
                }
                if (!error)
                {
                    dto.Lineas = dtoPedidoRecuperado.Lineas;
                    int idPedido = _addPedido.Ejecutar(dto).GetValueOrDefault();
                    LimpiarSession();
                    TempData["Mensaje"] = "Pedido Agregado";
                    return RedirectToAction("Details", new { id = idPedido });
                    //return RedirectToAction("Index");
                }
                else
                {
                    SetListasViewBag(null);
                    ViewBag.Articulos = TempData["Articulos"];
                    return View("Create", dtoPedidoRecuperado);
                }
            }
            catch (Exception ex)
            {
                SetListasViewBag(null);
                ViewBag.Articulos = TempData["Articulos"];
                ViewBag.Error = ex.Message;
                return View("Create", dto);
            }
        }
        [AdminFilter]
        public ActionResult Cancelar()
        {
            LimpiarSession();
            TempData["Mensaje"] = "Pedido cancelado";
            return RedirectToAction("PedidoSelectCliente");
        }

        public void LimpiarSession()
        {
            HttpContext.Session.Remove("SessionPedidoDto");
        }

        [AdminFilter]
        public ActionResult AgregarLinea(int? articuloId, int? cantidad, DtoPedidoAdd dtoPedido)
        {
            try
            {
                if (articuloId == null || cantidad == null || cantidad < 0) throw new ArgumentNullException("Debe seleccionar un articulo y una cantidad valida");
                //if (dtoPedido == null) throw new ArgumentNullException("Dto pedido nulo, debe seleccionar un cliente antes de crear el pedido para continuar");
                if (dtoPedido == null)
                    dtoPedido = new DtoPedidoAdd();

                var linea = new DtoLinea
                {
                    ArticuloId = articuloId.GetValueOrDefault(),
                    Cantidad = cantidad.GetValueOrDefault(),
                };
                if (linea.ArticuloId == 0 || linea.Cantidad <= 0) throw new ArgumentNullException("La cantidad no puede ser menor igual a 0 y el id tiene que ser valido");
                DtoPedidoAdd? dtoPedidoRecuperado = GetPedidoFromSession();
                if (dtoPedidoRecuperado.Lineas.Any(l => l.ArticuloId == linea.ArticuloId)) throw new ArgumentNullException("No se puede agregar ese item a la lista, ya fue agregado");
                dtoPedidoRecuperado.FechaEntrega = dtoPedido.FechaEntrega;
                dtoPedidoRecuperado.ClienteId = dtoPedido.ClienteId;
                dtoPedidoRecuperado.Tipo = dtoPedido.Tipo;
                if (dtoPedidoRecuperado != null)
                {
                    dtoPedidoRecuperado.Lineas.Add(linea);
                    HttpContext.Session.SetString("SessionPedidoDto", JsonSerializer.Serialize(dtoPedidoRecuperado));
                    ViewBag.Mensaje = $"Articulo agregado";
                }
                SetListasViewBag(null);
                ViewBag.Articulos = TempData["Articulos"];
                return View("Create", dtoPedidoRecuperado);

            }
            catch(Exception ex)
            {
                TempData["Error"] = ex.Message;
                SetListasViewBag(null);
                ViewBag.Articulos = TempData["Articulos"];
                return View("Create", dtoPedido);

            }
        }



        [AdminFilter]
        private DtoPedidoAdd? GetPedidoFromSession()
        {
            DtoPedidoAdd? dtoPedidoRecuperado;
            string? sessionPedidoDto = HttpContext.Session.GetString("SessionPedidoDto");
            if (!string.IsNullOrEmpty(sessionPedidoDto))
            {
                dtoPedidoRecuperado = JsonSerializer.Deserialize<DtoPedidoAdd>(sessionPedidoDto);
            }
            else
            {
                dtoPedidoRecuperado = new DtoPedidoAdd();
            }
            return dtoPedidoRecuperado;
        }

        private void SetListasViewBag(int? idArticuloSeleccionado)
        {
            var articulos = _getArticulos.Ejecutar();

            if(idArticuloSeleccionado == null)
                idArticuloSeleccionado = 0;

            var selectArticulos = new SelectList(articulos, "Id", "Nombre", idArticuloSeleccionado);
            TempData["Articulos"] = selectArticulos;
        }


        // GET: PedidoController/Edit/5
        [AdminFilter]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PedidoController/Edit/5
        [AdminFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PedidoController/Delete/5
        [AdminFilter]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PedidoController/Delete/5
        [AdminFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
