using Papeleria.LogicaAplicacion.DTO.DTOS.Administrador;
using Papeleria.LogicaAplicacion.DTO.DTOS.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCasosUso.Cliente
{
    public interface IGetAllCliente
    {
        //Aproveche la existencia de este dto ya que me servia porque utiliza los mismos atributos
        IEnumerable<DtoClienteCompleto> Ejecutar();
    }
}
