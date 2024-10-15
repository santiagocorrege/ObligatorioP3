using Papeleria.AccesoDatos.EF;
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
    public class GetByNombreAdministradores : IGetByNombreAdministradores
    {
        private IRepositorioAdministrador _repoAdmin;

        public GetByNombreAdministradores(IRepositorioAdministrador repo) 
        {
            _repoAdmin = repo;
        }

        public IEnumerable<DtoAdministradorId> Ejecutar(string nombre)
        {
            if (string.IsNullOrEmpty(nombre.Trim()))
            {
                throw new AdministradorException("El nombre no puede ser nulo");
            }
            else
            {
                var administradores = _repoAdmin.GetByNombre(nombre);
                if (administradores == null || administradores.Count() == 0) throw new AdministradorException("No existe ningun administrador con ese nombre");
                return AdministradorMapper.FromLista(administradores);
            }
        }
    }
}
