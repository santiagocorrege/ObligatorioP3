using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Papeleria.LogicaAplicacion.DTO.DTOS.Lineas;

namespace Papeleria.LogicaAplicacion.DTO.DTOS.Pedido
{
    public class DtoPedidoCompleto
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha Pedido")]
        public DateTime FechaPedido { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha Entrega")]
        public DateTime FechaEntrega { get; set; }

        [Display(Name = "Nombre Cliente")]
        public string ClienteNombre { get; set; }

        public List<DtoLinea> Lineas { get; set; } = new List<DtoLinea>();

        [Column(TypeName = "decimal(10,2)")]
        public decimal Recargo { get; set; }

        [Display(Name = "Costo Total")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal CostoPedido { get; set; }

        [Display(Name = "Tipo Pedido")]
        public string Tipo { get; set; }
    }
}
