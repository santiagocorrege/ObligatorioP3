using Papeleria.LogicaAplicacion.DTO.DTOS.Articulo;
using Papeleria.LogicaAplicacion.DTO.Mapper;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Articulo;
using Papeleria.LogicaNegocio.Excepciones.Articulo;
using Papeleria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ImplementacionCasosUso.Articulo
{
    public class AddArticulo : IAddArticulo
    {
        private IRepositorioArticulo _repoArticulos;

        public AddArticulo(IRepositorioArticulo repoArticulos)
        {
            _repoArticulos = repoArticulos;
        }

        public void Ejecutar(DtoArticuloAdd dto)
        {
            if(dto == null) { throw new ArticuloException("El articulo no puede ser nulo"); }
            Papeleria.LogicaNegocio.Entidades.Articulo articulo = ArticuloMapper.FromDtoAgregar(dto);
            _repoArticulos.Add(articulo);
        }

    }
}
