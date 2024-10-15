using Papeleria.LogicaAplicacion.DTO.DTOS.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCasosUso.Cliente
{
    public interface IGetClientesSuperanMonto
    {
        IEnumerable<DtoClienteCompleto> Ejecutar(int monto);
    }
}
