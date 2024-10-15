using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papeleria.AccesoDatos.EF;
using Papeleria.LogicaNegocio.InterfacesRepositorios;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Administrador;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Administrador;
using Papeleria.LogicaAplicacion.DTO.DTOS.Administrador;
using Humanizer;
using Papeleria.LogicaAplicacion.DTO.DTOS.Miembro;
using MVC.Filters;

namespace MVC.Controllers
{
    public class AdministradorController : Controller
    {
        private IGetAdministrador _getAdministrador;
        private IGetAllAdministrador _getAllAdministrador;
        private IAddAdministrador _addAdministrador;
        private IDeleteAdministrador _removeAdministrador;
        private IUpdateAdministrador _updateAdministrador;
        private IGetByNombreAdministradores _getByNombreAdministradores;

        public AdministradorController(IGetAdministrador getAdministrador, IGetAllAdministrador getAllAdministrador, IAddAdministrador addAdministrador, IDeleteAdministrador deleteAdministrador, IUpdateAdministrador updateAdministrador, IGetByNombreAdministradores getByNombreAdministradores)
        {
            _getAdministrador = getAdministrador;
            _getAllAdministrador = getAllAdministrador;
            _addAdministrador = addAdministrador;
            _removeAdministrador = deleteAdministrador; 
            _updateAdministrador = updateAdministrador;
            _getByNombreAdministradores = getByNombreAdministradores;
        }

        // GET: AdministradorController
        [AdminFilter]
        public ActionResult Index()
        {
            try
            {
                var administradores = _getAllAdministrador.Ejecutar();
                if(administradores == null || administradores.Count() == 0)
                {
                    ViewBag.Mensaje = "No existen administradores registrodos";
                    return View();
                }
                else
                {
                    return View(administradores);
                }
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: AdministradorController/Details/5
        [AdminFilter]
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Mensaje"] = "No existe administradores";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var dto = _getAdministrador.GetById(id.GetValueOrDefault());
                    if(dto == null)
                    {
                        throw new Exception("No existen administradores con ese id");
                    }
                    else
                    {
                        return View(dto);
                    }
                }
            }catch(Exception e)
            {
                TempData["Mensaje"] = $"Error:  {e.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: AdministradorController/Create
        [AdminFilter]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdministradorController/Create
        [AdminFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DtoAdministrador dto)
        {
            try
            {
                _addAdministrador.Ejecutar(dto);
                TempData["Mensaje"] = "Administrador Creado";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: AdministradorController/Edit/5
        [AdminFilter]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Error = "Se requiere el id del administrador";
                return View();
            }
            try
            {
                DtoAdministradorId adminDto = _getAdministrador.GetById(id.GetValueOrDefault());
                if (adminDto != null)
                {
                    return View(adminDto);
                }
                else
                {
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // POST: AdministradorController/Edit/5
        [AdminFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DtoAdministradorId dto)
        {
            try
            {
                _updateAdministrador.Ejecutar(id, dto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: AdministradorController/Delete/5
        [AdminFilter]
        public ActionResult Delete(int? id)
        {
            DtoAdministradorId dto = _getAdministrador.GetById(id.GetValueOrDefault());
            if (dto != null)
            {
                return View(dto);
            }
            else
            {
                ViewBag.Mensaje = $"No existen administradores con el id {id.GetValueOrDefault()}";
                return View();
            }
        }

        // POST: AdministradorController/Delete/5
        [AdminFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DtoAdministradorId dto)
        {
            try
            {
                if (id == null)
                {
                    throw new Exception("El id no puede ser nulo");
                }
                _removeAdministrador.Ejecutar(id);
                TempData["Mensaje"] = "Administrador Eliminado";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        [AdminFilter]
        public ActionResult GetByNombreAdministradores(string NombreAdministrador)
        {
            try
            {
                IEnumerable<DtoAdministradorId> dtoAdministradores = _getByNombreAdministradores.Ejecutar(NombreAdministrador);
                if(dtoAdministradores == null || dtoAdministradores.Count() == 0)
                {
                    throw new Exception("No hay administradores con ese nombre");
                }
                else
                {
                    return View("Index", dtoAdministradores);
                }                
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [AdminFilter]
        public ActionResult Error()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
