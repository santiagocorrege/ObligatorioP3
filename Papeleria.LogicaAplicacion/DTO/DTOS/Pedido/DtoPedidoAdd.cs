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
    public class DtoPedidoAdd
    {
        [DataType(DataType.Date)]
        [Required]
        public DateTime FechaEntrega { get; set; }

        [Required]
        public int ClienteId { get; set; }

        public string ClienteNombre { get; set; }

        public string Tipo { get; set; }

        public List<DtoLinea> Lineas { get; set; } = new List<DtoLinea>();

    }
}
