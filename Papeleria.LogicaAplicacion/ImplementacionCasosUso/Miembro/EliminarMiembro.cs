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
    public class EliminarMiembro : IEliminarMiembro
    {
        private IRepositorioMiembro _repoMiembro;

        public EliminarMiembro(IRepositorioMiembro repoMiembro)
        {
            _repoMiembro = repoMiembro;
        }

        public void Ejecutar(int id)
        {
            if(id == null)
            {
                throw new MiembroException("El id no puede ser nulo");
            }
            _repoMiembro.Remove(id);
        }
    }
}
