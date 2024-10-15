using SistemaAutenticacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioMiembro : IRepositorio<Miembro>
    {
        IEnumerable<Miembro> GetByNombre(string nombre);
    }
}
