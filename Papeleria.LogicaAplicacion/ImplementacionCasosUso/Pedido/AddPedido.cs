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
    public class AddPedido : IAddPedido
    {
        private IRepositorioPedido _repoPedido;
        private IRepositorioCliente _repoCliente;
        private IRepositorioArticulo _repoArticulo;

        private IRepositorioParametro _repoParam;

        public AddPedido(IRepositorioPedido repoPedido, IRepositorioArticulo repoArticulo, IRepositorioCliente repoCliente , IRepositorioParametro repoParam)
        {
            _repoPedido = repoPedido;
            _repoArticulo = repoArticulo;
            _repoCliente = repoCliente;
            _repoParam = repoParam;
        }
        public int? Ejecutar(DtoPedidoAdd dtoPedido)
        {
            if (dtoPedido == null)
            {
                throw new PedidoException("El pedido no puede ser nulo");
            }
            LogicaNegocio.Entidades.Pedido pedido = PedidoMapper.FromDtoAdd(dtoPedido);
            if(pedido == null)
            {
                throw new PedidoException("El pedido no es valido, problema de conversion");
            }
            if (dtoPedido.Lineas == null) throw new ArgumentNullException("El pedido debe tener al menos 1 articulo");

            var cliente = _repoCliente.GetById(dtoPedido.ClienteId);
            if (cliente == null) throw new ArgumentNullException("El cliente al que se desea agregar el pedido no existe");

            foreach(var linea in dtoPedido.Lineas)
            {
                LogicaNegocio.Entidades.Articulo art = _repoArticulo.GetById(linea.ArticuloId);
                if (art == null) throw new ArgumentNullException("El articulo que se desea agregar no existe");
                if (linea.Cantidad <= 0) throw new ArgumentNullException("La cantidad del articulo que se desea agregar no puede ser menor o igual a 0");
                if (linea.Cantidad > art.Stock) throw new ArgumentNullException($"No hay stock suficiente de {art.Nombre}, no se puede agregar el pedido");
                
                pedido.AgregarLinea(art, linea.Cantidad);                
            }

            LogicaNegocio.Entidades.Pedido.s_Iva = _repoParam.GetValorDecimal("Iva");

            LogicaNegocio.Entidades.PedidoComun.s_Plazo = _repoParam.GetValorInt("PlazoPedidoComun");
            LogicaNegocio.Entidades.PedidoComun.s_RecargoDistancia = _repoParam.GetValorInt("ComunRecargoDistancia");

            LogicaNegocio.Entidades.PedidoExpress.s_Plazo = _repoParam.GetValorInt("PlazoPedidoExpress");
            LogicaNegocio.Entidades.PedidoExpress.s_RecargoBase = _repoParam.GetValorInt("ExpresRecargoBase");
            LogicaNegocio.Entidades.PedidoExpress.s_RecargoMismoDia = _repoParam.GetValorInt("ExpresRecargoMismoDia");
            //Se hace validacion de el tipo especifico de pedido con los valores de los parametros guardados si no existian los parametros para la validacion Plazos en dias de los pedidos
            //No era necesaria esta validacion en el caso de uso
            pedido.Cliente = cliente;
            pedido.Validate();
            pedido.Recargo = pedido.CalcularRecargo();
            pedido.CostoPedido = pedido.CostoTotal();
            _repoPedido.Add(pedido);
            return pedido.Id;
        }


    }
}
