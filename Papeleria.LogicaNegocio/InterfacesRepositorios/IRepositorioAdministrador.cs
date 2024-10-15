using SistemaAutenticacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioAdministrador : IRepositorio<Administrador>
    {
        IEnumerable<Administrador> GetByNombre(string nombre);
    }
}
