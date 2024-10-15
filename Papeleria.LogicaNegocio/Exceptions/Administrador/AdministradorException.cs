using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Exceptions.Administrador
{
    public class AdministradorException : Exception
    {
        public AdministradorException()
        {
        }

        public AdministradorException(string? message) : base(message)
        {
        }

        public AdministradorException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected AdministradorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
