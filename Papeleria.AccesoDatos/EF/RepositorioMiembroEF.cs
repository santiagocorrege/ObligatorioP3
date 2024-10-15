using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Exceptions.Administrador;
using Papeleria.LogicaNegocio.Exceptions.Miembro;
using Papeleria.LogicaNegocio.InterfacesRepositorios;
using SistemaAutenticacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.EF
{
    public class RepositorioMiembroEF : IRepositorioMiembro
    {
        private PapeleriaContext _db;

        public RepositorioMiembroEF(PapeleriaContext db)
        {
            _db = db;
        }
        public void Add(Miembro miembro)
        {
            if (miembro == null)
                throw new ArgumentNullException("El miembro no puede ser nulo");
            try
            {
                _db.Miembros.Add(miembro);
                _db.SaveChanges(); 
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null)
                {
                    SqlException exSql = ex.InnerException as SqlException;
                    if (exSql.Number == 2601)
                        throw new Exception("Ya existe un miembro con ese email");
                }
                throw;
            }
            catch (Exception ex)
            {
                throw new MiembroException($"No se puede agregar el miembro. error: {ex.Message}");
            }
        }

        public IEnumerable<Miembro> GetAll()
        {
            try
            {
                return _db.Miembros.ToList();
            }
            catch (Exception ex)
            {
                throw new MiembroException($"No se pudo recuperar la lista error: {ex.Message}");
            }
        }

        public Miembro GetById(int id)
        {
            try
            {
                var miembro = _db.Miembros.Find(id);
                if (miembro == null) throw new MiembroException($"No existe el miembro con el id {id}");
                return miembro;
            }
            catch (Exception ex)
            {
                throw new MiembroException($"Error: {id}: {ex.Message}");
            }
        }

        public IEnumerable<Miembro> GetByNombre(string nombre)
        {
            try
            {
                if (string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre))
                {
                    throw new MiembroException("El nombre no puede ser nulo");
                }
                nombre = nombre.ToLower();
                if (nombre.Split(" ").Length > 1)
                {
                    var miembro = _db.Miembros.Where(a => (a.Nombre.ToLower() + " " + a.Apellido.ToLower()).Contains(nombre)).ToList();
                    return miembro;
                }
                else
                {
                    var miembro = _db.Miembros.Where(a => a.Nombre.ToLower().Contains(nombre) || a.Apellido.ToLower().Contains(nombre)).ToList();
                    return miembro;
                }
            }
            catch (Exception ex)
            {
                throw new AdministradorException($"Error: {ex.Message}");
            }
        }
        public void Remove(int id)
        {
            try
            {
                var miembro = _db.Miembros.Find(id);
                if (miembro == null) throw new MiembroException($"No existe el miembro con el id {id}");
                _db.Miembros.Remove(miembro);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new MiembroException($"No se pudo eliminar el miembro con id: {id}: {ex.Message}");
            }
        }

        public void Remove(Miembro miembro)
        {
            try
            {
                if (miembro == null) throw new ArgumentNullException();
                _db.Miembros.Remove(miembro);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new MiembroException($"No se pudo eliminar el miembro con id: {miembro.Id}: {ex.Message}");
            }
        }

        public void Update(int id, Miembro miembroModificado)
        {
            try
            {
                var miembro = _db.Miembros.Find(id);
                if (id == null)
                    throw new MiembroException($"No existe el miembro con el id {id}");
                if(miembro == null)
                    throw new MiembroException($"Miembro no valido");
                miembro.Modificar(miembroModificado);
                _db.Miembros.Update(miembro);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
