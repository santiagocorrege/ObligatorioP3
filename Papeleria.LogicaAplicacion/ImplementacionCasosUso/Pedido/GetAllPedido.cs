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
    public class GetAllPedido : IGetAllPedido
    {
        private IRepositorioPedido _repoPedido;

        public GetAllPedido(IRepositorioPedido repoPedido)
        {
            _repoPedido = repoPedido;
        }

        public IEnumerable<DtoPedidoCompleto> Ejecutar()
        {
            var pedidos = _repoPedido.GetAll();
            if(pedidos == null || pedidos.Count() == 0) { throw new PedidoException("No hay pedidos registrados"); }
            return PedidoMapper.FromListaCompleto(pedidos);
        }
    }
}
