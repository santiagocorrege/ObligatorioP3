using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaAplicacion.DTO.DTOS.Cliente;
using Papeleria.LogicaAplicacion.DTO.Mapper;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Cliente;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ImplementacionCasosUso.Cliente
{
    public class GetClientesSuperanMonto : IGetClientesSuperanMonto
    {
        private IRepositorioCliente _repoCliente;

        public GetClientesSuperanMonto(IRepositorioCliente repositorio)
        {
            _repoCliente = repositorio;
        }

        public IEnumerable<DtoClienteCompleto> Ejecutar(int monto)
        {
            try
            {
                var clientes = _repoCliente.GetClientesSuperanMonto(monto);
                return ClienteMapper.FromListaCompleto(clientes);

            }
            catch (DbUpdateException ex)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
