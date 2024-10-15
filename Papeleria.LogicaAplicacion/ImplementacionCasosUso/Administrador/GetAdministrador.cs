using Papeleria.LogicaAplicacion.DTO.DTOS.Administrador;
using Papeleria.LogicaAplicacion.DTO.Mapper;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Administrador;
using Papeleria.LogicaNegocio.Exceptions.Administrador;
using Papeleria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ImplementacionCasosUso.Administrador
{
    public class GetAdministrador : InterfacesCasosUso.Administrador.IGetAdministrador
    {
        private IRepositorioAdministrador _repoAdmin;

        public GetAdministrador(IRepositorioAdministrador repoAdmin)
        {
            _repoAdmin = repoAdmin;
        }
        public DtoAdministradorId GetById(int id)
        {
            if(id == null) { throw new AdministradorException("El id de busqueda no puede ser nulo"); }
            var administrador = _repoAdmin.GetById(id);
            if(administrador == null)
            {
                throw new AdministradorException("El id ingresado no pertenece a ningun administrador");
            }
            return AdministradorMapper.ToDtoId(administrador);
        }
    }
}
