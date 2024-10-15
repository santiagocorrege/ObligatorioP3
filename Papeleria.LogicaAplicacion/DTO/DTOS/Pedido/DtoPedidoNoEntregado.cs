using Papeleria.LogicaAplicacion.DTO.DTOS.Lineas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTO.DTOS.Pedido
{
    public class DtoPedidoNoEntregado
    {

        public int Id { get; set; }

        [Display(Name = "Nombre Cliente")]
        public string ClienteNombre { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha Pedido")]
        public DateTime FechaPedido { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha Entrega")]
        public DateTime FechaEntrega { get; set; }


        [Display(Name = "Costo Total")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal CostoPedido { get; set; }

    }
}
