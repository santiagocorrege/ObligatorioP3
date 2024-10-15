using Papeleria.LogicaAplicacion.DTO.DTOS.Miembro;
using Papeleria.LogicaAplicacion.DTO.Mapper;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Miembro;
using Papeleria.LogicaNegocio.Exceptions.Administrador;
using Papeleria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ImplementacionCasosUso.Miembro
{
    public class GetByNombreMiembros : IGetByNombreMiembros
    {
        private IRepositorioMiembro _repoMiembros;

        public GetByNombreMiembros(IRepositorioMiembro repoMiembros)
        {
            _repoMiembros = repoMiembros;
        }

        public IEnumerable<DtoMiembroListado> Ejecutar(string nombre)
        {
            if (string.IsNullOrEmpty(nombre.Trim()))
            {
                throw new AdministradorException("El nombre no puede ser nulo");
            }
            else
            {
                var miembros = _repoMiembros.GetByNombre(nombre);
                if (miembros == null || miembros.Count() == 0) throw new AdministradorException("No existe ningun administrador con ese nombre");
                return MiembroMapper.FromLista(miembros);
            }
        }
    }
}
