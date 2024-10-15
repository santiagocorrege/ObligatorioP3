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
    public class AddAdministrador : IAddAdministrador
    {
        private IRepositorioAdministrador _repoAdmin;

        public AddAdministrador(IRepositorioAdministrador repoAdmin)
        {
            _repoAdmin = repoAdmin;
        }
        public void Ejecutar(DtoAdministrador dto)
        {
            if(dto == null)
            {
                throw new AdministradorException("El administrador a agregar tiene campos vacios");
            }
            else
            {
                var administrador = AdministradorMapper.FromDto(dto);
                _repoAdmin.Add(administrador);
            }
        }
    }
}
