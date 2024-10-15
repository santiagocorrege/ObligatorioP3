using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones.Pedido;
using Papeleria.LogicaNegocio.Exceptions.Miembro;
using Papeleria.LogicaNegocio.InterfacesRepositorios;
using SistemaAutenticacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Papeleria.AccesoDatos.EF
{
    public class RepositorioPedidoEF : IRepositorioPedido
    {
        private PapeleriaContext _db;

        public RepositorioPedidoEF(PapeleriaContext db)
        {
            _db = db;
        }

        public void Add(Pedido pedido)
        {
            if (pedido == null)
                throw new PedidoException("El Pedido no puede ser nulo");
            try
            {
                if (pedido.Cliente != null)
                {
                    _db.Entry(pedido.Cliente).State = EntityState.Unchanged;
                }
                foreach (var linea in pedido.Lineas)
                {
                    if(linea.Articulo != null)
                    {
                        _db.Entry(linea.Articulo).State = EntityState.Unchanged;
                    }
                    
                }
                _db.Pedidos.Add(pedido);
                _db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new PedidoException($"Pedido no valido. error: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new PedidoException($"No se puede agregar el pedido. error: {ex.Message}");
            }
        }

        public IEnumerable<Pedido> GetAll()
        {
            try
            {
                var pedidos = _db.Pedidos
                    .Include(pedido => pedido.Cliente)
                    .Include(pedido => pedido.Lineas)
                    .ThenInclude(linea => linea.Articulo)
                    .ToList();
                if (pedidos == null || pedidos.Count == 0) throw new PedidoException("No hay pedidos registrados");
                return pedidos;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public Pedido GetById(int id)
        {
            try
            {
                if (id == null || id == 0) throw new PedidoException("El id del pedido que desea buscar no es valido");
                var pedido = _db.Pedidos
                    .Include(pedido => pedido.Cliente)
                    .Include(pedido => pedido.Lineas)
                    .ThenInclude(linea => linea.Articulo)
                    .FirstOrDefault(p => p.Id == id);
                if (pedido == null) throw new PedidoException("El pedido que esta buscando no existe");
                return pedido;
            }
            catch(Exception ex)
            {
                throw new PedidoException("No existe un pedido con ese id");
            }
        }

        IEnumerable<Pedido> IRepositorioPedido.GetNoEntregadosFecha(DateTime date)
        {
            try
            {
                var pedidos = _db.Pedidos
                    .Where(p => p.FechaPedido == date && p.FechaEntrega >= DateTime.Today.Date && p.Valido == true)
                    .Include(pedido => pedido.Cliente)
                    .ToList();
                if (pedidos == null || pedidos.Count == 0) throw new PedidoException("No hay pedidos registrados para la fecha ingresada");
                return pedidos;
            }
            catch (Exception ex)
            {
                throw;
            };
        }

        public IEnumerable<Pedido> GetPedidosAnulados()
        {
            try
            {
                var pedidos = _db.Pedidos
                    .Where(p => p.Valido == false)
                    .Include(pedido => pedido.Cliente)
                    .OrderBy(pedido => pedido.FechaPedido)
                    .ToList();
                if (pedidos == null || pedidos.Count == 0) throw new PedidoException("No hay pedidos registrados para la fecha ingresada");
                return pedidos;
            }
            catch (Exception ex)
            {
                throw;
            };
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Pedido obj)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public void AnularPedidoById(int id)
        {
            try
            {
                if (id == null)
                    throw new PedidoException($"No existe el pedido con el id {id}");
                var pedido = _db.Pedidos.FirstOrDefault(p => p.Id == id && p.Valido == true);
                if (pedido == null)
                    throw new PedidoException($"Miembro no valido");
                pedido.Anular();
                _db.Pedidos.Update(pedido);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public decimal GetMontoPedido(int id)
        {
            throw new NotImplementedException();
        }


    }
}
