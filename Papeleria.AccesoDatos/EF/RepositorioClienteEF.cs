using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones.Articulo;
using Papeleria.LogicaNegocio.Excepciones.Cliente;
using Papeleria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Papeleria.AccesoDatos.EF
{
    public class RepositorioClienteEF : IRepositorioCliente
    {
        private PapeleriaContext _db;

        public RepositorioClienteEF(PapeleriaContext db)
        {
            _db = db;
        }
        public void Add(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> GetAll()
        {
            try
            {
                return _db.Clientes.ToList();
            }
            catch (Exception ex)
            {
                throw new ClienteException($"No se ha podido recuperar la lista de clientes error: ${ex.Message}");
            }
        }

        public Cliente GetById(int id)
        {
            try
            {
                var cliente = _db.Clientes.Find(id);
                if (cliente == null)
                {
                    throw new ArticuloException("El cliente con ese id no existe");
                }
                return cliente;
            }
            catch (Exception e)
            {
                throw new ArticuloException($"No se ha podido encontrar el articulo con id {id}. Mas info: {e.Message}");
            }
        }

        public IEnumerable<Cliente> GetClientesByNombre(string nombre)
        {
            try
            {
                if (string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre))
                {
                    throw new ClienteException("El nombre no puede ser nulo");
                }
                nombre = nombre.ToLower();

                var clientes = _db.Clientes.Where(a => (a.RazonSocial.ToLower()).Contains(nombre)).ToList();
                return clientes;

            }
            catch (Exception ex)
            {
                throw new ClienteException($"Error: {ex.Message}");
            }
        }
        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Cliente obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> GetClientesSuperanMonto(int monto)
        {
            try
            {
                var query = _db.Pedidos
                    .GroupBy(p => p.Cliente.Id)
                    .Select(g => new
                    {
                        ClienteId = g.Key,
                        TotalCosto = g.Sum(p => p.CostoPedido)
                    })
                    .Where(x => x.TotalCosto > monto)
                    .Select(x => x.ClienteId)
                    .ToList();

                // Now retrieve full Cliente objects based on the ClienteIds obtained from the first query
                var clientes = _db.Clientes
                    .Where(c => query.Contains(c.Id))
                    .ToList();

                return clientes;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
