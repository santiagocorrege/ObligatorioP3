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
    public class GetClienteById : IGetClienteById
    {
        private IRepositorioCliente _repoCliente;

        public GetClienteById(IRepositorioCliente repoCliente)
        {
            _repoCliente = repoCliente;
        }


        public DtoClienteCompleto Ejecutar(int id)
        {
            if (id == 0) throw new ArgumentNullException("Id no valido");
            var cliente = _repoCliente.GetById(id);
            if(cliente == null)
            {
                throw new ClienteException("No existe un cliente con ese id");
            }
            return ClienteMapper.ToDtoClienteCompleto(cliente);
        }
    }
}
