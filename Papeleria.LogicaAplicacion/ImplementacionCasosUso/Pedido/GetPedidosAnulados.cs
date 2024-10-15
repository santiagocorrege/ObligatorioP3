using Papeleria.LogicaAplicacion.DTO.DTOS.Pedido;
using Papeleria.LogicaAplicacion.DTO.Mapper;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Pedidos;
using Papeleria.LogicaNegocio.Excepciones.Pedido;
using Papeleria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ImplementacionCasosUso.Pedido
{
    public class GetPedidosAnulados : IGetPedidosAnulados
    {
        private IRepositorioPedido _repoPedido;

        public GetPedidosAnulados(IRepositorioPedido repositorioPedido)
        {
            _repoPedido = repositorioPedido;
        }
        public IEnumerable<DtoPedidoNoEntregado> Ejecutar()
        {
            var pedidos = _repoPedido.GetPedidosAnulados();
            if (pedidos == null) throw new PedidoException("No existen pedidos anulados");
            return PedidoMapper.FromListaNoEntregado(pedidos);
        }
    }
}
