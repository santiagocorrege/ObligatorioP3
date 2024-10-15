
using Papeleria.LogicaAplicacion.DTO.DTOS.Administrador;
using Papeleria.LogicaAplicacion.DTO.DTOS.Cliente;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones.Cliente;
using Papeleria.LogicaNegocio.Exceptions.Administrador;
using Papeleria.LogicaNegocio.ValueObject;
using SistemaAutenticacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTO.Mapper
{
    public class ClienteMapper
    {

        public static DtoClienteCompleto ToDtoClienteCompleto(Cliente cliente)
        {
            if (cliente == null) throw new ClienteException("Error el cliente no puede ser nulo");
            return new DtoClienteCompleto()
            {
                Id = cliente.Id,
                RazonSocial = cliente.RazonSocial,
                RUT = cliente.RUT.Valor,
                Calle = cliente.Direccion.Calle,
                Numero = cliente.Direccion.Numero,
                Ciudad = cliente.Direccion.Ciudad,
                Distancia = cliente.Direccion.Distancia,
            };
        }

        public static IEnumerable<DtoClienteCompleto> FromListaCompleto(IEnumerable<Cliente> clientes)
        {
            if (clientes == null) throw new ClienteException("No se pueden mappear los clientes");
            return clientes.Select(a => ToDtoClienteCompleto(a));
        }

        public static Cliente FromDto(DtoClienteCompleto dto)
        {
            if (dto == null) throw new ClienteException("Error el cliente no puede ser nulo");
            Cliente cliente = new Cliente(dto.RazonSocial, dto.RUT, dto.Calle, dto.Numero, dto.Ciudad, dto.Distancia);
            return cliente;
        }
    }
}
