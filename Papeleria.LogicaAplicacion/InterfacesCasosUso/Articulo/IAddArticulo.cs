using Papeleria.LogicaAplicacion.DTO.DTOS.Articulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCasosUso.Articulo
{
    public interface IAddArticulo
    {
        public void Ejecutar(DtoArticuloAdd dto);
    }
}
