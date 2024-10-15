using Papeleria.LogicaAplicacion.DTO.DTOS.Pedido;
using Papeleria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCasosUso.Pedidos
{
    public interface IAddPedido
    {
        public int? Ejecutar(DtoPedidoAdd dto);
    }
}
