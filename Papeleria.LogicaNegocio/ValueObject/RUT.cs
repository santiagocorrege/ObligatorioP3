using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones.Cliente;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.ValueObject
{
    [ComplexType]
    public record RUT : IValidate
    {
        public long Valor { get; init; }

        protected RUT() { }
        public RUT(long valor)
        {
            Valor = valor;
            Validate();
        }
        public void Validate()
        {
            if(Valor == null)
            {
                throw new ClienteException("El RUT no puede ser nulo");
            }
            if (Valor < 99999999999 || Valor > 1000000000000) 
            {
                throw new ClienteException("El RUT debe tener 12 digitos");
            }
        }
    }
    
}
