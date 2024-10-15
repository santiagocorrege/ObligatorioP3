using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTO.DTOS.Administrador
{
    public class DtoAdministradorId : DtoAdministrador
    {
        [Required]
        public int Id { get; set; }
    }
}
