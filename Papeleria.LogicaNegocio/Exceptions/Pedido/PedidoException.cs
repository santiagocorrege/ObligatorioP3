using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.Pedido
{
    public class PedidoException : Exception
    {
        public PedidoException()
        {
        }

        public PedidoException(string? message) : base(message)
        {
        }

        public PedidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PedidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
