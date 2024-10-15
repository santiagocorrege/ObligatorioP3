using Papeleria.LogicaAplicacion.DTO.DTOS.Administrador;
using Papeleria.LogicaAplicacion.DTO.DTOS.Usuario;
using Papeleria.LogicaNegocio.Exceptions;
using Papeleria.LogicaNegocio.Exceptions.Administrador;
using Papeleria.LogicaNegocio.Exceptions.Usuario;
using SistemaAutenticacion.Entidades;
using SistemaAutenticacion.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTO.Mapper
{
    internal static class UsuarioMapper
    {
        internal static DtoUsuarioLogin ToDto(Usuario user)
        {
            if (user == null) throw new UserException("Error el usuario no puede ser nulo");
            return new DtoUsuarioLogin()
            {
                Email = user.Email.Valor,
                Rol = user.Rol()
            };
        }
    }
}
