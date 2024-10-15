using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Filters;
using Papeleria.AccesoDatos.EF;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Cliente;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Cliente;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesRepositorios;

namespace MVC.Controllers
{
    public class ClienteController : Controller
    {
        private IGetAllCliente _getAllClientes;
        private IGetClientesSuperanMonto _getClientesSuperanMonto;
        private IGetClienteByNombre _getClientesByNombre;

        public ClienteController(IGetAllCliente getAllClientes, IGetClientesSuperanMonto getClientesSuperanMonto, IGetClienteByNombre getClientesByNombre)
        {
            _getClientesSuperanMonto = getClientesSuperanMonto;
            _getAllClientes = getAllClientes;
            _getClientesByNombre = getClientesByNombre;
        }


        // GET: ClienteController
        [AdminFilter]
        public ActionResult Index()
        {
            try
            {
                var clientes = _getAllClientes.Ejecutar();
                if (clientes == null || clientes.Count() == 0)
                {
                    ViewBag.Mensaje = "No existen clientes registrados";
                    return View();
                }
                else
                {
                    return View(clientes);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
                throw;
            }
        }


        [AdminFilter]
        [HttpPost]
        public ActionResult GetClientesMonto(int montoPedido)
        {
            //IF MONTO VACIO
            try
            {
                var clientes = _getClientesSuperanMonto.Ejecutar(montoPedido);
                if(montoPedido == null || montoPedido <= 0)
                {
                    throw new Exception("Ingrese un monto valido");
                }
                if (clientes == null || clientes.Count() == 0)
                {
                    throw new Exception("No existen clientes que posean un pedido con un costo superior al ingresado");
                }
                else
                {
                    ViewBag.Mensaje = "Clientes filtrados";
                    return View("Index", clientes);
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [AdminFilter]
        [HttpPost]
        public ActionResult GetClientesByNombre(string nombreCliente)
        {            
            try
            {
                if(nombreCliente == null)
                {
                    throw new Exception("Ingrese un nombre valido para poder filtrar los clientes");
                }
                var clientes = _getClientesByNombre.Ejecutar(nombreCliente);
                if (clientes == null || clientes.Count() == 0)
                {
                    throw new Exception("No existen clientes que posean un pedido con un costo superior al ingresado");
                }
                else
                {
                    return View("Index", clientes);
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        // GET: ClienteController/Details/5
        [AdminFilter]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClienteController/Create
        [AdminFilter]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ClienteController/Edit/5
        [AdminFilter]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClienteController/Edit/5
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

        // GET: ClienteController/Delete/5
        [AdminFilter]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClienteController/Delete/5
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
