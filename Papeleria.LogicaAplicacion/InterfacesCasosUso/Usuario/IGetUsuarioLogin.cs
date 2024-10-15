using Papeleria.LogicaAplicacion.DTO.DTOS.Usuario;
using Papeleria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCasosUso.Usuario
{
    public interface IGetUsuarioLogin
    {
        public DtoUsuarioLogin Ejecutar(string Email, string password);
    }
}
