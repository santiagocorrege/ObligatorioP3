using Papeleria.LogicaNegocio.InterfacesEntidades;
using Papeleria.LogicaNegocio.Excepciones.Linea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace Papeleria.LogicaNegocio.Entidades
{
    [PrimaryKey(nameof(PedidoId), nameof(ArticuloId))]
    public class Linea : IValidate
    {
        #region Properties
        public int PedidoId { get; set; }
        

        [ForeignKey("ArticuloId")]
        public int ArticuloId { get; set; }
        public Articulo Articulo { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecioVigente { get; set; }

        public int Cantidad { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Costo { get; set; }
        public Linea(Articulo articulo, int cantidad)
        {
            Articulo = articulo;
            PrecioVigente = articulo.PrecioActual;
            Cantidad = cantidad;
            Validate();
            Costo = CalcularCosto();
        }

        public Linea(int articuloId, int cantidad)
        {
            ArticuloId = articuloId;
            Cantidad = Cantidad;
        }
        protected Linea() { }
        #endregion

        #region Methods
        public void Validate()
        {
            if(Articulo == null && ArticuloId == 0)
            {
                throw new LineaException("El articulo no puede ser nulo");
            }
            if (PrecioVigente < 0)
            {
                throw new LineaException("El precio vigente no es valido");
            }
            if (Cantidad <= 0)
            {
                throw new LineaException("La cantidad no es valida");
            }
        }

        public decimal CalcularCosto()
        {
            return PrecioVigente * Cantidad;
        }
        #endregion

    }
}
