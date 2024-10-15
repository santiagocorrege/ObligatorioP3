using Papeleria.LogicaAplicacion.DTO.DTOS.Administrador;
using Papeleria.LogicaAplicacion.DTO.DTOS.Cliente;
using Papeleria.LogicaAplicacion.DTO.Mapper;
using Papeleria.LogicaNegocio.Excepciones.Cliente;
using Papeleria.LogicaNegocio.Exceptions.Administrador;
using Papeleria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ImplementacionCasosUso.Cliente
{
    internal class AddCliente
    {
        private IRepositorioCliente _repoCliente;

        public AddCliente(IRepositorioCliente repoCliente)
        {
            _repoCliente = repoCliente;
        }
        public void Ejecutar(DtoClienteCompleto dto)
        {
            if (dto == null)
            {
                throw new ClienteException("El cliente a agregar tiene campos vacios");
            }
            else
            {
                var cliente = ClienteMapper.FromDto(dto);
                _repoCliente.Add(cliente);
            }
        }
    }
}
