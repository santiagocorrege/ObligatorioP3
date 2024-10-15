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
    public class ModificarMiembro : IModificarMiembro
    {
        private IRepositorioMiembro _repoMiembro;

        public ModificarMiembro(IRepositorioMiembro repoMiembro)
        {
            _repoMiembro = repoMiembro;
        }

        public void Ejecutar(int id, DtoMiembroModificar dto)
        {
            if(id == null)
            {
                throw new MiembroException("No existe ningun Miembro que posea ese id");
            }
            if(dto == null)
            {
                throw new MiembroException("Faltan datos para actualizar el miembro");
            }
            SistemaAutenticacion.Entidades.Miembro miembro = MiembroMapper.FromDtoModificar(dto);
            _repoMiembro.Update(id, miembro);
        }
    }
}
