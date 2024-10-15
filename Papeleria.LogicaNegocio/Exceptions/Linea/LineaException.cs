using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones.Linea
{
    public class LineaException : Exception
    {
        public LineaException()
        {
        }

        public LineaException(string? message) : base(message)
        {
        }

        public LineaException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected LineaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
