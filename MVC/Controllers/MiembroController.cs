using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papeleria.AccesoDatos.EF;
using Papeleria.LogicaNegocio.InterfacesRepositorios;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Miembro;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Miembro;
using Papeleria.LogicaAplicacion.DTO.DTOS.Miembro;
using MVC.Filters;
using Papeleria.LogicaAplicacion.DTO.DTOS.Administrador;

namespace MVC.Controllers
{
    public class MiembroController : Controller
    {
        private IAltaMiembro _altaMiembro;
        private IGetAllMiembro _getAllMiembro;
        private IGetMiembro _getMiembro;
        private IModificarMiembro _modificarMiembro;
        private IEliminarMiembro _eliminarMiembro;
        private IGetByNombreMiembros _getByNombreMiembros;
        public MiembroController(IAltaMiembro altaMiembro, IGetAllMiembro getAllMiembro, IGetMiembro getMiembro, IModificarMiembro modificarMiembro, IEliminarMiembro eliminarMiembro, IGetByNombreMiembros getByNombreMiembros)
        {
            _altaMiembro = altaMiembro;
            _getAllMiembro = getAllMiembro;
            _getMiembro = getMiembro;
            _modificarMiembro = modificarMiembro;
            _eliminarMiembro = eliminarMiembro;
            _getByNombreMiembros = getByNombreMiembros;
        }

        // GET: MiembroController
        [AdminFilter]
        public ActionResult Index()
        {
            try
            {
                var miembros = _getAllMiembro.Ejecutar();
                if (miembros == null || miembros.Count() == 0)
                {
                    ViewBag.Mensaje = "No existen miembros";
                    return View();
                }
                else
                {
                    return View(miembros);
                }
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
                throw;
            }
            
        }

        // GET: MiembroController/Details/5
        [AdminFilter]
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Mensaje"] = "No existe miembros registrados";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var dto = _getMiembro.GetById(id.GetValueOrDefault());
                    if (dto == null)
                    {
                        throw new Exception("No existen miembros con ese id");
                    }
                    else
                    {
                        return View(dto);
                    }
                }
            }
            catch (Exception e)
            {
                TempData["Mensaje"] = $"Error:  {e.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: MiembroController/Create
        [AdminFilter]
        public ActionResult Create()
        {
            return View();
        }

        // POST: MiembroController/Create
        [AdminFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DtoMiembroAlta dto)
        {
            try
            {
                _altaMiembro.Ejecutar(dto);
                TempData["Mensaje"] = "Miembro Creado";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: MiembroController/Edit/5
        [AdminFilter]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Error = "Se requiere el id del miembro";
                return View();
            }
            try
            {
                DtoMiembroModificar miembroDto = _getMiembro.GetById(id.GetValueOrDefault());
                if(miembroDto != null)
                {
                    return View(miembroDto);
                } else
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

        // POST: MiembroController/Edit/5
        [AdminFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DtoMiembroModificar dto)
        {
            try
            {
                _modificarMiembro.Ejecutar(id, dto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: MiembroController/Delete/5
        [AdminFilter]
        public ActionResult Delete(int? id)
        {
            //Se puede modificar junto con el [POST] para que trabajen con DtoModificarMiembro
            DtoMiembroListado dto = _getMiembro.GetMiembroByIdDtoListado(id.GetValueOrDefault());
            if (dto != null)
            {
                return View(dto);
            }
            else
            {
                ViewBag.Mensaje = $"No existen miembros con el id {id.GetValueOrDefault()}";
                return View();
            }
        }

        // POST: MiembroController/Delete/5
        [AdminFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DtoMiembroListado dto)
        {
            try
            {
                if(id == null)
                {
                    throw new Exception("El id no puede ser nulo");
                }
                _eliminarMiembro.Ejecutar(id);
                TempData["Mensaje"] = "Miembro Eliminado";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        [AdminFilter]
        public ActionResult GetByNombreMiembros(string NombreMiembro)
        {
            try
            {
                IEnumerable<DtoMiembroListado> dtoMiembros = _getByNombreMiembros.Ejecutar(NombreMiembro);
                if (dtoMiembros == null || dtoMiembros.Count() == 0)
                {
                    throw new Exception("No hay administradores con ese nombre");
                }
                else
                {
                    return View("Index", dtoMiembros);
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
