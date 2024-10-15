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
    public class GetAllMiembro : IGetAllMiembro
    {
        IRepositorioMiembro _repoMiembro;

        public GetAllMiembro(IRepositorioMiembro repoMiembro)
        {
            _repoMiembro = repoMiembro;
        }

        public IEnumerable<DtoMiembroListado> Ejecutar()
        {
            var miembros = _repoMiembro.GetAll();
            if(miembros == null || miembros.Count() == 0)
            {
                throw new MiembroException("No hay miembros registrados");
            }
            return MiembroMapper.FromLista(miembros);
        }
    }
}
