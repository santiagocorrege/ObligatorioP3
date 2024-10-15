using Papeleria.LogicaAplicacion.DTO.DTOS.Miembro;
using Papeleria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCasosUso.Miembro
{
    public interface IModificarMiembro
    {
        public void Ejecutar(int id, DtoMiembroModificar dto);
        
    }
}
