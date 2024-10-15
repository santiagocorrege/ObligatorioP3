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
    public class GetPedidosNoEntregadosFecha : IGetPedidosNoEntregadosFecha
    {
        private IRepositorioPedido _repoPedidos;

        public GetPedidosNoEntregadosFecha(IRepositorioPedido _repositorioPedidos)
        {
            _repoPedidos = _repositorioPedidos;
        }

        public IEnumerable<DtoPedidoNoEntregado> Ejecutar(DateTime date)
        {
            if (date == null || date == DateTime.MinValue && date == DateTime.MaxValue) throw new PedidoException("La fecha de filtrado no es valida");
            var pedidos = _repoPedidos.GetNoEntregadosFecha(date);
            if (pedidos == null || pedidos.Count() == 0) throw new PedidoException("No existen pedidos no entregados para esa fecha");
            return PedidoMapper.FromListaNoEntregado(pedidos);
        }
    }
}
