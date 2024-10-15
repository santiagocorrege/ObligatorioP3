using Papeleria.LogicaAplicacion.DTO.DTOS.Articulo;
using Papeleria.LogicaAplicacion.DTO.Mapper;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Articulo;
using Papeleria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ImplementacionCasosUso.Articulo
{
    public class GetArticulosAlfabeticamente : IGetArticulosAlfabeticamente
    {
        private IRepositorioArticulo _repoArticulo;

        public GetArticulosAlfabeticamente(IRepositorioArticulo repoArticulo)
        {
            _repoArticulo = repoArticulo;
        }

        public IEnumerable<DtoArticuloCompleto> Ejecutar()
        {
            var articulos = _repoArticulo.GetArticulosOrdenadosAlfabeticamente();
            if (articulos == null) throw new ArgumentNullException("No existen articulos registrados");

            return ArticuloMapper.FromLista(articulos);

        }
    }
}
