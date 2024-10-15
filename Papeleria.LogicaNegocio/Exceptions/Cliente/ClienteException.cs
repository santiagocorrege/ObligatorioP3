using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.Cliente
{
    public class ClienteException : Exception
    {
        public ClienteException()
        {
        }

        public ClienteException(string? message) : base(message)
        {
        }

        public ClienteException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ClienteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
