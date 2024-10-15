using Papeleria.LogicaAplicacion.DTO.DTOS.Cliente;
using Papeleria.LogicaAplicacion.DTO.Mapper;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Cliente;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones.Cliente;
using Papeleria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ImplementacionCasosUso.Cliente
{
    public class GetAllCliente : IGetAllCliente
    {
        private IRepositorioCliente _repoCliente;

        public GetAllCliente(IRepositorioCliente repoCliente) 
        {
            _repoCliente = repoCliente;
        }

        //Aproveche la existencia de este dto ya que me servia porque utiliza los mismos atributos
        public IEnumerable<DtoClienteCompleto> Ejecutar()
        {
            var clientes = _repoCliente.GetAll();
            if (clientes == null || clientes.Count() == 0)
            {
                throw new ClienteException("No existen clientes registrados");
            }
            else
            {
                return ClienteMapper.FromListaCompleto(clientes);
            }
        }
    }
}
