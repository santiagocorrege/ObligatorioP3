using Papeleria.LogicaNegocio.Excepciones.Pedido;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    public abstract class Pedido : IEntity, IValidate
    {
        #region Properties
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime FechaPedido { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime FechaEntrega { get; set; }
        
        public Cliente Cliente { get; set; }

        [ForeignKey(nameof(Cliente))]
        public int ClienteId {  get; set; }
        public List<Linea> Lineas { get; set; } = new List<Linea>();

        [Column(TypeName = "decimal(10,2)")]
        public decimal Recargo { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal CostoPedido { get; set; }
        public static decimal s_Iva { get; set; }

        public bool Valido { get; set; } = true;

        public Pedido(DateTime fechaEntrega, Cliente cliente, List<Linea> lineas)
        {
            FechaPedido = DateTime.Now;
            FechaEntrega = fechaEntrega;
            Cliente = cliente;
            Lineas = lineas;
            Validate();
        }

        public Pedido(DateTime fechaEntrega, int clienteId)
        {
            FechaPedido = DateTime.Now;
            FechaEntrega = fechaEntrega;
            ClienteId = clienteId;
            Validate();
        }

        protected Pedido() { }
        #endregion
        #region Methods
        public virtual void Validate()
        {
            if(Cliente == null && ClienteId == 0)
            {
                throw new PedidoException("El cliente no puede ser nulo");
            }

            if (FechaEntrega < DateTime.MinValue || FechaEntrega < DateTime.Now.Date)
            {
                throw new PedidoException("La fecha de entrega no es valida");
            }

        }

        public abstract decimal CalcularRecargo();

        public void AgregarLinea(Articulo art, int cantidad)
        {
            if(Lineas.Any(l => l.ArticuloId == art.Id))
            {
                throw new PedidoException("Uno de los articulos que intenta agregar al pedido esta repetido");
            }
            else
            {

                Lineas.Add(new Linea(art, cantidad));
            }

        }
        public abstract string Tipo();
        public decimal CostoTotal() 
        {
            decimal total = 0;
            foreach (Linea linea in Lineas)
            {
                total += linea.Costo;

            }
            total += total * Recargo / 100; // La clase  Pedido es abstracta por ende va a llamar a el metodo de la clase especialzada?
            return total + total * s_Iva;
        }

        public void Anular()
        {
            Valido = false;
        }
        #endregion
    }
}
