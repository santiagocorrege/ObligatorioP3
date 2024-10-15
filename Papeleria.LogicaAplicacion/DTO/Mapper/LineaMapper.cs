using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones.Linea;
using Papeleria.LogicaAplicacion.DTO.DTOS.Lineas;

namespace Papeleria.LogicaAplicacion.DTO.Mapper
{
    public class LineaMapper
    {
        internal static DtoLinea ToDto (Linea linea)
        {
            if (linea == null) throw new ArgumentNullException("No pueden existir linea vacias");
            return new DtoLinea()
            {
                ArticuloId = linea.ArticuloId,
                ArticuloNombre = linea.Articulo.Nombre,
                PrecioVigente = linea.Articulo.PrecioActual,
                Cantidad = linea.Cantidad,
                Costo = linea.CalcularCosto(),
                Stock = linea.Articulo.Stock
            };
        }

        internal static Linea FromDto(DtoLinea dto)
        {
            return new Linea(dto.ArticuloId, dto.Cantidad);
        }

        internal static IEnumerable<DtoLinea> FromLista(IEnumerable<Linea> lista)
        {
            if (lista == null) throw new ArgumentNullException("Lista vacia");
            return lista.Select(elemento => ToDto(elemento)).ToList();
        }
    }
}
