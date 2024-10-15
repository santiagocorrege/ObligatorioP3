using Papeleria.LogicaAplicacion.DTO.DTOS.Miembro;
using Papeleria.LogicaNegocio.Exceptions.Miembro;
using SistemaAutenticacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTO.Mapper
{
    public static class MiembroMapper
    {
        public static Miembro FromDto(DtoMiembroAlta dto)
        {
            if(dto == null) throw new ArgumentNullException(nameof(dto));
            return new Miembro(dto.Nombre, dto.Apellido, dto.Email, dto.Password);
        }

        public static DtoMiembroListado ToDto(Miembro miembro)
        {
            if (miembro == null) throw new ArgumentNullException();

            return new DtoMiembroListado()
            {
                Id = miembro.Id,
                Nombre = miembro.Nombre,
                Apellido = miembro.Apellido,
                Email = miembro.Email.Valor,
                Password = miembro.Password.Valor
            };
        }

        public static Miembro FromDtoModificar(DtoMiembroModificar dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            var miembro = new Miembro (dto.Nombre, dto.Apellido, dto.Email, dto.Password);
            miembro.Id = dto.Id;
            return miembro;
        }

        public static DtoMiembroModificar ToDtoModificar(Miembro miembro)
        {
            if (miembro == null) throw new ArgumentNullException();

            return new DtoMiembroModificar()
            {
                Id = miembro.Id,
                Nombre = miembro.Nombre,
                Apellido = miembro.Apellido,
                Email = miembro.Email.Valor,
                Password = miembro.Password.Valor
            };
        }

        public static IEnumerable<DtoMiembroListado> FromLista(IEnumerable<Miembro> miembros)
        {
            if (miembros == null) throw new ArgumentNullException();
            return miembros.Select(miembro => ToDto(miembro));
        }
           
    }
}
