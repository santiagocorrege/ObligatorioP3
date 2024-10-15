using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Excepciones.Cliente;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using Papeleria.LogicaNegocio.ValueObject;

namespace Papeleria.LogicaNegocio.Entidades
{
    [Index(nameof(RUT), IsUnique = true)]
    [Index(nameof(RazonSocial), IsUnique = true)]
    public class Cliente : IEntity, IValidate
    {
        #region Properties
        public int Id { get; set; }

        public string RazonSocial { get; set; }
        public RUT RUT { get; set; }
        
        public Direccion Direccion { get; set; }


        public Cliente (string razonSocial, long rut, string calle, int numero, string ciudad, decimal distancia)
        {
            RazonSocial = razonSocial;
            RUT = new RUT(rut);
            Direccion = new Direccion(calle, numero, ciudad, distancia);
            Validate();
        }

        protected Cliente()
        {

        }
        #endregion
        #region Methods
        public void Validate()
        {
            if (string.IsNullOrEmpty(RazonSocial))
            {
                throw new ClienteException("La razon social no puede ser nula");
            }
        }

        public override string ToString()
        {
            return $"RUT: {RUT}\n{Direccion}";
        }
        #endregion
    }
}
