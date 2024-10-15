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
    public class GetPedidoById : IGetPedidoById
    {
        private IRepositorioPedido _repoPedido;

        public GetPedidoById(IRepositorioPedido repoPedidio)
        {
            _repoPedido = repoPedidio;
        }

        public DtoPedidoCompleto Ejecutar(int id)
        {
            if(id == null || id == 0)
            {
                throw new PedidoException("El id del pedido que desea buscar no puede ser nulo");
            }
            var pedido = _repoPedido.GetById(id);
            if (pedido == null) throw new PedidoException("No existe un pedido con ese id");
            return PedidoMapper.ToDtoCompleto(pedido);
        }
    }
}
