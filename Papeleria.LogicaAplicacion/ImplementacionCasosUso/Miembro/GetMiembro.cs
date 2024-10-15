using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaAplicacion.DTO.DTOS.Miembro;
using Papeleria.LogicaAplicacion.DTO.Mapper;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Miembro;
using Papeleria.LogicaNegocio.Exceptions.Miembro;
using Papeleria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ImplementacionCasosUso.Miembro
{
    public class GetMiembro : IGetMiembro
    {
        private IRepositorioMiembro _repoMiembro;
        public GetMiembro(IRepositorioMiembro repoMiembro)
        {
            _repoMiembro = repoMiembro;
        }

        public DtoMiembroModificar GetById(int id)
        {
            if(id == null)
            {
                throw new MiembroException("El id no es valido");
            }
            else
            {
                var miembro = _repoMiembro.GetById(id);
                if(miembro == null)
                {
                    throw new MiembroException("No hay miembros con ese id");
                }
                return MiembroMapper.ToDtoModificar(miembro);
            }
        }

        public DtoMiembroListado GetMiembroByIdDtoListado(int id)
        {
            if (id == null)
            {
                throw new MiembroException("El id no es valido");
            }
            else
            {
                var miembro = _repoMiembro.GetById(id);
                if (miembro == null)
                {
                    throw new MiembroException("No hay miembros con ese id");
                }
                var miembroDto = MiembroMapper.ToDto(miembro);
                return miembroDto;
            }
        }
    }
}
