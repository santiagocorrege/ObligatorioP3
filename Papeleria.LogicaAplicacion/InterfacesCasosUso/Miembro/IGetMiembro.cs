using Papeleria.LogicaAplicacion.DTO.DTOS.Miembro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCasosUso.Miembro
{
    public interface IGetMiembro
    {
        DtoMiembroModificar GetById(int id);

        //Se puede eliminar, hay que modificar las vistas de Remove de Miembro para que trabajen con DtoMiembroModificar
        public DtoMiembroListado GetMiembroByIdDtoListado(int id);
    }
}
