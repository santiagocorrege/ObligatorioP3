using Papeleria.LogicaAplicacion.DTO.DTOS.Miembro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCasosUso.Miembro
{
    public interface IGetAllMiembro
    {
        public IEnumerable<DtoMiembroListado> Ejecutar(); 
    }
}
