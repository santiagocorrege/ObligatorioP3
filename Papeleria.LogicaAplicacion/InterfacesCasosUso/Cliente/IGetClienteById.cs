using Papeleria.LogicaAplicacion.DTO.DTOS.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCasosUso.Cliente
{
    public interface IGetClienteById
    {
        public DtoClienteCompleto Ejecutar(int id);
    }
}
