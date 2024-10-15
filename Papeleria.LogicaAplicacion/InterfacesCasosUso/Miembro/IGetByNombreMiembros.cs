using Papeleria.LogicaAplicacion.DTO.DTOS.Administrador;
using Papeleria.LogicaAplicacion.DTO.DTOS.Miembro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCasosUso.Miembro
{
    public interface IGetByNombreMiembros
    {
        IEnumerable<DtoMiembroListado> Ejecutar(string nombre);
    }
}
