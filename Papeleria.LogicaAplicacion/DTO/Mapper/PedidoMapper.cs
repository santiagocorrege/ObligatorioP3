using Papeleria.LogicaAplicacion.DTO.DTOS.Cliente;
using Papeleria.LogicaAplicacion.DTO.DTOS.Pedido;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones.Cliente;
using Papeleria.LogicaNegocio.Excepciones.Pedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTO.Mapper
{
    public class PedidoMapper
    {

        internal static Pedido FromDtoAdd(DtoPedidoAdd dto)
        {
            if (dto == null) throw new ArgumentNullException("Dto nulo no se puede mappear");
            if (dto.Tipo == null) throw new ArgumentNullException("El tipo de pedido no puede ser nulo");
            if(dto.Tipo == "Express")
            {
                var pedido = new PedidoExpress(dto.FechaEntrega, dto.ClienteId);
                return pedido;
            }
            else if(dto.Tipo == "Comun")
            {
                var pedido = new PedidoComun(dto.FechaEntrega, dto.ClienteId);
                return pedido;
            }
            else
            {
                throw new Exception("El tipo de pedido no es valido");
            }
            
        }

        internal static DtoPedidoAdd ToDtoAdd(Pedido pedido)
        {
            if (pedido == null) throw new ArgumentNullException("Pedido nulo");

            return new DtoPedidoAdd()
            {
                FechaEntrega = pedido.FechaEntrega,
                ClienteId = pedido.ClienteId,
                Tipo = pedido.Tipo(),
                Lineas = pedido.Lineas.Select(l => LineaMapper.ToDto(l)).ToList()
            };
        }

        internal static DtoPedidoCompleto ToDtoCompleto(Pedido pedido)
        {
            if (pedido == null) throw new ArgumentNullException("Pedido nulo");

            var tipo = "";
            if (pedido is PedidoExpress)
            {
                tipo = "Pedido Express";
            }
            else
            {
                tipo = "Pedido Comun";
            }
            return new DtoPedidoCompleto()
            {
                Id = pedido.Id,
                FechaPedido = pedido.FechaPedido,
                FechaEntrega = pedido.FechaEntrega,
                ClienteNombre = pedido.Cliente.RazonSocial,
                Tipo = tipo,
                Lineas = pedido.Lineas.Select(l => LineaMapper.ToDto(l)).ToList(),
                Recargo = pedido.Recargo,
                CostoPedido = pedido.CostoPedido
            };
        }

        public static IEnumerable<DtoPedidoCompleto> FromListaCompleto(IEnumerable<Pedido> pedidos)
        {
            if (pedidos == null) throw new PedidoException("No se pueden mappear los pedidos");
            return pedidos.Select(p => ToDtoCompleto(p));
        }

        public static DtoPedidoNoEntregado ToDtoNoEntregado(Pedido pedido)
        {
            if (pedido == null) throw new ArgumentNullException("Pedido nulo");

            return new DtoPedidoNoEntregado()
            {
                Id = pedido.Id,
                ClienteNombre = pedido.Cliente.RazonSocial,
                FechaEntrega = pedido.FechaEntrega,
                FechaPedido = pedido.FechaPedido,
                CostoPedido = pedido.CostoPedido
            };
        }

        public static IEnumerable<DtoPedidoNoEntregado> FromListaNoEntregado(IEnumerable<Pedido> pedidos)
        {
            if (pedidos == null) throw new PedidoException("No se pueden mappear los pedidos");
            return pedidos.Select(p => ToDtoNoEntregado(p));
        }
    }
}
