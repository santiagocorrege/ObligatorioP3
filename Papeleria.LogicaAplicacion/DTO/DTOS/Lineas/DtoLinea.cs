using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTO.DTOS.Lineas
{
    public class DtoLinea
    {
        public int ArticuloId { get; set; }
        public string ArticuloNombre { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [Display(Name ="Precio")]
        public decimal PrecioVigente { get; set; }

        public int Cantidad { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Costo Total")]
        public decimal Costo { get; set; }

        public int Stock {  get; set; }
    }
}
