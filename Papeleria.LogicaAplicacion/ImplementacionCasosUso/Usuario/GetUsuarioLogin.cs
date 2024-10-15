using Papeleria.LogicaAplicacion.DTO.DTOS.Usuario;
using Papeleria.LogicaAplicacion.DTO.Mapper;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Usuario;
using Papeleria.LogicaNegocio.InterfacesRepositorios;
using SistemaAutenticacion.Exceptions.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ImplementacionCasosUso.Usuario
{
    public class GetUsuarioLogin : IGetUsuarioLogin
    {
        private IRepositorioUsuario _repoUsuario;

        public GetUsuarioLogin(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public DtoUsuarioLogin Ejecutar(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) throw new UsuarioException("El email y/o contrasena no pueden ser vacios");
            var usuario = _repoUsuario.GetByUsuarioLogin(email, password);
            if (usuario == null) throw new UsuarioException("El usuario y/o contrasena no es valido");
            return UsuarioMapper.ToDto(usuario);
        }
    }
}
