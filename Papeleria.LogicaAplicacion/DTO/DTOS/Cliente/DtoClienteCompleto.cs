using Papeleria.LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTO.DTOS.Cliente
{
    public class DtoClienteCompleto
    {
        public int Id { get; set; }

        public string RazonSocial { get; set; }
        public long RUT { get; set; }

        public string Calle { get; set; }
        public int Numero { get; set; }
        public string Ciudad { get; set; }

        public decimal Distancia { get; set; }

    }
}
