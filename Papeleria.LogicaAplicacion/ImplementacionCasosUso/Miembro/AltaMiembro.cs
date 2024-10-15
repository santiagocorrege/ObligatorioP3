using Papeleria.LogicaAplicacion.DTO.DTOS.Miembro;
using Papeleria.LogicaAplicacion.DTO.Mapper;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Miembro;
using Papeleria.LogicaNegocio.Exceptions.Miembro;
using Papeleria.LogicaNegocio.InterfacesRepositorios;
using SistemaAutenticacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ImplementacionCasosUso.Miembro
{
    public class AltaMiembro : IAltaMiembro
    {
        private IRepositorioMiembro _repoMiembro {  get; set; }

        public AltaMiembro(IRepositorioMiembro repositorioMiembro)
        {
            _repoMiembro = repositorioMiembro;
        }
        public void Ejecutar(DtoMiembroAlta dto)
        {
            if (dto == null)
            {
                throw new MiembroException("El miembro no puede ser nulo");
            }
            else
            {
                SistemaAutenticacion.Entidades.Miembro miembro = MiembroMapper.FromDto(dto);
                _repoMiembro.Add(miembro);
            }
            //repoMiembro.Add();
        }
    }
}
