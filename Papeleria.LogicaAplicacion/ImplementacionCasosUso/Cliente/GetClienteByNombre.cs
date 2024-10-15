using Papeleria.LogicaAplicacion.DTO.DTOS.Cliente;
using Papeleria.LogicaAplicacion.DTO.Mapper;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Cliente;
using Papeleria.LogicaNegocio.Excepciones.Cliente;
using Papeleria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ImplementacionCasosUso.Cliente
{
    public class GetClienteByNombre : IGetClienteByNombre
    {
        private IRepositorioCliente _repoCliente;

        public GetClienteByNombre(IRepositorioCliente repoCliente)
        {
            _repoCliente = repoCliente;
        }

        public IEnumerable<DtoClienteCompleto> Ejecutar(string nombre)
        {
            var clientes = _repoCliente.GetClientesByNombre(nombre);
            if (clientes == null) throw new ClienteException("No existen clientes con ese nombre");
            return ClienteMapper.FromListaCompleto(clientes);

        }
    }
}
