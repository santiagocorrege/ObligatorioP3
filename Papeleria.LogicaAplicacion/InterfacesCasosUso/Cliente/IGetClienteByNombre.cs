using Papeleria.LogicaAplicacion.DTO.DTOS.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCasosUso.Cliente
{
    public interface IGetClienteByNombre
    {
        IEnumerable<DtoClienteCompleto> Ejecutar(string nombre);
    }
}
