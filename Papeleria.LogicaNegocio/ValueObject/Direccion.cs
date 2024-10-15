using Papeleria.LogicaNegocio.Excepciones;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using Papeleria.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Papeleria.LogicaNegocio.Excepciones.Cliente;
using System.ComponentModel.DataAnnotations.Schema;

namespace Papeleria.LogicaNegocio.ValueObject
{
    [ComplexType]
    public record Direccion : IValidate
    {
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string Ciudad { get; set; }

        public decimal Distancia { get; set; }

        protected Direccion() { }
        public Direccion(string calle, int numero, string ciudad, decimal distancia)
        {
            Calle = UtilidadesString.FormatearTexto(calle);
            Numero = numero;
            Ciudad = UtilidadesString.FormatearTexto(ciudad);
            Distancia = distancia;
            Validate();
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Calle))
            {
                throw new ClienteException("La calle de la direccion no puede ser nula");
            }
            if (Numero == null || Numero <= 0 || Numero > 9999)
            {
                throw new ClienteException("El numero no es valido");
            }
            if (string.IsNullOrEmpty(Ciudad))
            {
                throw new ClienteException("La ciudad de la direccion no puede ser nula");
            }
            if (Distancia == null || Distancia < 0 || Numero > 99999)
            {
                throw new ClienteException("La distancia no es valido");
            }
        }

        public override string ToString()
        {
            return $"Calle: {Calle}\nNumero: {Numero}\nCiudad: {Ciudad}\nDistancia: {Distancia}";
        }
    }
}
