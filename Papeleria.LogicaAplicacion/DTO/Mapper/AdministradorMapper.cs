using Papeleria.LogicaAplicacion.DTO.DTOS.Administrador;
using Papeleria.LogicaNegocio.Exceptions.Administrador;
using SistemaAutenticacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTO.Mapper
{
    public static class AdministradorMapper
    {
        public static DtoAdministradorId ToDtoId(Administrador administrador)
        {
            if (administrador == null) throw new AdministradorException("Error el administrador no puede ser nulo");
            return new DtoAdministradorId()
            {
                Id = administrador.Id,
                Nombre = administrador.Nombre,
                Apellido = administrador.Apellido,
                Email = administrador.Email.Valor,
                Password = administrador.Password.Valor,   
            };
        }
        public static Administrador FromDtoId(DtoAdministradorId dto)
        {
            if (dto == null) throw new AdministradorException("Error el administrador no puede ser nulo");
            Administrador administrador = new Administrador(dto.Nombre, dto.Apellido, dto.Email, dto.Password);
            administrador.Id = dto.Id;
            return administrador;
        }

        public static DtoAdministrador ToDto(Administrador administrador)
        {
            if (administrador == null) throw new AdministradorException("Error el administrador no puede ser nulo");
            return new DtoAdministrador()
            {
                Nombre = administrador.Nombre,
                Email = administrador.Email.Valor,
                Password = administrador.Password.Valor,
            };
        }
        public static Administrador FromDto(DtoAdministrador dto)
        {
            if (dto == null) throw new AdministradorException("Error el administrador no puede ser nulo");
            Administrador administrador = new Administrador(dto.Nombre, dto.Apellido, dto.Email, dto.Password);
            return administrador;
        }

        public static IEnumerable<DtoAdministradorId> FromLista(IEnumerable<Administrador> administradores)
        {
            if (administradores == null) throw new AdministradorException("No se pueden mappear los administradores");
            return administradores.Select(a => ToDtoId(a));
        }
    }
}
