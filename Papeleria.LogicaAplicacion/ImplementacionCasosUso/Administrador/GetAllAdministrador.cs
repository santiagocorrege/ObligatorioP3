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
    public class GetAllAdministrador : IGetAllAdministrador
    {
        private IRepositorioAdministrador _repositorioAdministrador;

        public GetAllAdministrador(IRepositorioAdministrador repositorioAdministrador)
        {
            _repositorioAdministrador = repositorioAdministrador;
        }
        public IEnumerable<DtoAdministradorId> Ejecutar()
        {
            var administradores = _repositorioAdministrador.GetAll();
            if (administradores == null || administradores.Count() == 0)
            {
                throw new AdministradorException("No hay administradores registrados");
            }
            else
            {
                return AdministradorMapper.FromLista(administradores);
            }
        }
    }
}
