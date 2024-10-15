using Papeleria.LogicaNegocio.InterfacesEntidades;
using Papeleria.LogicaNegocio.Excepciones.Pedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    public class PedidoExpress : Pedido, IValidate
    {
        public static int s_Plazo { get; set; }

        public static int s_RecargoBase { get; set; }

        public static int s_RecargoMismoDia { get; set; }

        public PedidoExpress(DateTime fechaEntrega, Cliente cliente, List<Linea> lineas) : base (fechaEntrega, cliente, lineas)
        {   
            Validate();
            Recargo = CalcularRecargo();
            CostoPedido = base.CostoTotal();
        }
        public PedidoExpress(DateTime fechaEntrega, int clienteId) : base(fechaEntrega, clienteId)
        {
        }
        protected PedidoExpress() { }

        public override void Validate()
        {
            base.Validate ();
            //Se valida el Plazo de mas para prevenir fallas de seguridad
            if (FechaEntrega.Subtract(FechaPedido).Days > s_Plazo)
            {
                throw new PedidoException("La fecha de entrega del pedido express no puede superar el plazo");
            }
        }

        public override string Tipo()
        {
            return "PedidoExpress";
        }

        public override decimal CalcularRecargo()
        {
            int plazoEstipulado = FechaEntrega.Subtract(FechaPedido.Date).Days;
            int recargo = s_RecargoBase;
            if(plazoEstipulado < 1)
            {
                recargo = s_RecargoMismoDia;
            }
            return recargo;
        }
    }
}
