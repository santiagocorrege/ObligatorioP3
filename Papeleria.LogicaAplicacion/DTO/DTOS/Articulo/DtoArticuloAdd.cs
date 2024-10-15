using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTO.DTOS.Articulo
{
    public class DtoArticuloAdd
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string Codigo { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecioActual { get; set; }

        [Required]
        public int Stock { get; set; }
    }
}
