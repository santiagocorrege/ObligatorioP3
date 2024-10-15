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
    public class UpdateAdministrador : IUpdateAdministrador
    {
        private IRepositorioAdministrador _repositorioAdministrador;

        public UpdateAdministrador(IRepositorioAdministrador repositorioAdministrador)
        {
            _repositorioAdministrador = repositorioAdministrador;
        }

        public void Ejecutar(int id, DtoAdministradorId dto)
        {
            if(id == null || dto == null)
            {
                throw new AdministradorException("Los datos del administrador no pueden ser nulos");
            }
            else
            {
                var adminisrador = _repositorioAdministrador.GetById(dto.Id);
                if(adminisrador == null)
                {
                    throw new AdministradorException("No existe ningun administrador con ese id");
                }
                else
                {
                    SistemaAutenticacion.Entidades.Administrador administrador = AdministradorMapper.FromDtoId(dto);
                    _repositorioAdministrador.Update(id, administrador);
                }
            }

        }
    }
}
