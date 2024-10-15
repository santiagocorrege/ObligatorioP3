using Papeleria.LogicaAplicacion.DTO.DTOS.Articulo;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones.Articulo;
using Papeleria.LogicaNegocio.Excepciones.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTO.Mapper
{
    public class ArticuloMapper
    {
        public static Articulo FromDtoAgregar(DtoArticuloAdd dto)
        {
            if(dto == null) throw new ArgumentNullException("El dto a mapper no puede ser nulo");
            Articulo articulo = new Articulo(dto.Nombre, dto.Descripcion, dto.Codigo, dto.PrecioActual, dto.Stock);
            return articulo;
        }

        public static DtoArticuloCompleto ToDtoArticuloCompleto(Articulo articulo)
        {
            if (articulo == null) throw new ArgumentNullException("El articulo que se intenta mappear es nulo");
            return new DtoArticuloCompleto()
            {
                Id = articulo.Id,
                Nombre = articulo.Nombre,
                Descripcion = articulo.Descripcion,
                Codigo = articulo.Codigo,
                PrecioActual = articulo.PrecioActual,
                Stock = articulo.Stock
            };
        }

        public static IEnumerable<DtoArticuloCompleto> FromLista(IEnumerable<Articulo> articulos)
        {
            if (articulos == null) throw new ArticuloException("No se pueden mappear los articulos");
            return articulos.Select(a => ToDtoArticuloCompleto(a));
        }
    }
}
