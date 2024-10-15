using Papeleria.LogicaNegocio.Excepciones.Pedido;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    public class PedidoComun : Pedido, IValidate
    {
        public static int s_Plazo { get; set; }

        public static int s_RecargoDistancia { get; set; }

        public PedidoComun(DateTime fechaEntrega, Cliente cliente, List<Linea> lineas) : base(fechaEntrega, cliente, lineas)
        {
            Validate();
            Recargo = CalcularRecargo();
            CostoPedido = base.CostoTotal();
        }

        public PedidoComun(DateTime fechaEntrega, int clienteId) : base(fechaEntrega, clienteId)
        {
        }
        protected PedidoComun() { }
        public override void Validate()
        {
            base.Validate();
            //Se valida el Plazo de mas para prevenir fallas de seguridad
            if (FechaEntrega.Subtract(FechaPedido).Days < s_Plazo)
            {
                throw new PedidoException("Los pedidos comunes no pueden tener fecha prometida de entrega menor a una semana");
            }
        }

        public override decimal CalcularRecargo()
        {
            int recargo = 0;
            if (Cliente.Direccion.Distancia > 100)
            {
                recargo = s_RecargoDistancia;
            }
            return recargo;
        }

        public override string Tipo()
        {
            return "PedidoComun";
        }
    }
}
