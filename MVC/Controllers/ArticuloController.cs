using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Filters;
using Papeleria.AccesoDatos.EF;
using Papeleria.LogicaAplicacion.DTO.DTOS.Administrador;
using Papeleria.LogicaAplicacion.DTO.DTOS.Articulo;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Articulo;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Articulo;
using Papeleria.LogicaNegocio.InterfacesRepositorios;

namespace MVC.Controllers
{
    public class ArticuloController : Controller
    {
        private IAddArticulo _addArticulo;
        private IGetArticulosAlfabeticamente _getArticulosAlfabeticamente;

        public ArticuloController(IAddArticulo addArticulo, IGetArticulosAlfabeticamente getArticulosAlfabeticamente)
        {
            _addArticulo = addArticulo;
            _getArticulosAlfabeticamente = getArticulosAlfabeticamente;
        }
        // GET: ArticuloController
        [AdminFilter]
        public ActionResult Index()
        {
            try
            {
                var articulos = _getArticulosAlfabeticamente.Ejecutar();
                if (articulos == null || articulos.Count() == 0)
                {
                    ViewBag.Mensaje = "No existen articulos registrados";
                    return View();
                }
                else
                {
                    return View(articulos);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
                throw;
            }
        }

        // GET: ArticuloController/Details/5
        [AdminFilter]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArticuloController/Create
        [AdminFilter]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticuloController/Create
        [AdminFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DtoArticuloAdd dto)
        {
            try
            {
                _addArticulo.Ejecutar(dto);
                TempData["Mensaje"] = "Articulo Agregado";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return View();
        }

        // GET: ArticuloController/Edit/5
        [AdminFilter]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArticuloController/Edit/5
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

        // GET: ArticuloController/Delete/5
        [AdminFilter]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArticuloController/Delete/5
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
