using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Models.Usuario;
using Papeleria.AccesoDatos.EF;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Usuario;
using Papeleria.LogicaNegocio.InterfacesRepositorios;
using SistemaAutenticacion.Entidades;
using System.Diagnostics;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        //CORREGIR, TRABAJAR CON CASO DE USO
        private IGetUsuarioLogin _getUsuarioLogin;

        public HomeController(IGetUsuarioLogin getUsuarioLogin)
        {
            _getUsuarioLogin = getUsuarioLogin;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View(new UsuarioLoginModel());
        }

        [HttpPost]
        public IActionResult Login(UsuarioLoginModel model)
        {
            try
            {
                if(model == null || String.IsNullOrEmpty(model.Email) || String.IsNullOrEmpty(model.Password))
                {
                    ViewBag.Error = "Rellene todos los campos";
                    return View(model);
                }
                var user = _getUsuarioLogin.Ejecutar(model.Email, model.Password);
                if(user == null)
                {
                    throw new Exception("Usuario y/o password invalidas");
                }
                else
                {
                    string rol = user.Rol;
                    HttpContext.Session.SetString("Email", user.Email);
                    HttpContext.Session.SetString("Rol", rol);
                    if (rol == "Administrador")
                    {
                        return RedirectToAction("Index", rol);
                    }
                    else
                    {
                        TempData["Error"] = "Aun no existen acciones para el Miembro";
                        return RedirectToAction("Login", "Home");
                    }
                }
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
