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
    public class DeleteAdministrador : InterfacesCasosUso.Administrador.IDeleteAdministrador
    {
        private IRepositorioAdministrador _repoAdmin;

        public DeleteAdministrador(IRepositorioAdministrador repoAdmin)
        {
            _repoAdmin = repoAdmin;
        }

        public void Ejecutar(int id)
        {
            if (id == null || id == 0) throw new AdministradorException("El id del administrador que se desea eliminar no puede ser nulo");
            _repoAdmin.Remove(id);
        }
    }
}
