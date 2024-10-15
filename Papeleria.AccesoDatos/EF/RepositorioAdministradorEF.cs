using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Exceptions.Administrador;
using Papeleria.LogicaNegocio.Exceptions.Miembro;
using Papeleria.LogicaNegocio.InterfacesRepositorios;
using SistemaAutenticacion.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.EF
{
    public class RepositorioAdministradorEF : IRepositorioAdministrador
    {
        //Le quitamos el new y lo recibimos
        private PapeleriaContext _db;

        public RepositorioAdministradorEF(PapeleriaContext db)
        {
            _db = db;
        }

        public void Add(Administrador admin)
        {
            if (admin == null) throw new AdministradorException("El administrador no puede ser nulo");
            try
            {
                _db.Administradores.Add(admin);
                _db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null)
                {
                    SqlException exSql = ex.InnerException as SqlException;
                    if (exSql.Number == 2601)
                        throw new Exception("Ya existe un administrador con ese email");
                }
                throw;
            }
        }

        public IEnumerable<Administrador> GetAll()
        {
            try 
            { 
                return _db.Administradores.ToList();
            } 
            catch(Exception ex)
            {
                throw new AdministradorException($"No se ha podido recuperar la lista de administradores error: ${ex.Message}");
            }
        }

        public Administrador GetById(int id)
        {
            try
            {
                var administrador = _db.Administradores.Find(id);
                if (administrador == null) throw new AdministradorException("No existen administradores con ese id");
                return administrador;
            } 
            catch(Exception ex)
            {
                throw new AdministradorException($"Error: {ex.Message}");
            }
        }

        public IEnumerable<Administrador> GetByNombre(string nombre)
        {
            try
            {
                if (string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre)){
                    throw new AdministradorException("El nombre no puede ser nulo");
                }
                //Si el parametro incluye apellido busco un administrador que coincida el nombre y apellido
                nombre = nombre.ToLower();
                if (nombre.Split(" ").Length > 1)
                {
                    var administrador = _db.Administradores.Where(a => (a.Nombre.ToLower() + " " + a.Apellido.ToLower()).Contains(nombre)).ToList();
                    return administrador;
                }
                else
                {
                    var administrador = _db.Administradores.Where(a => a.Nombre.ToLower().Contains(nombre) || a.Apellido.ToLower().Contains(nombre)).ToList();
                    return administrador;
                }
            }
            catch(Exception ex)
            {
                throw new AdministradorException($"Error: {ex.Message}");
            }
        }

        public void Remove(int id)
        {
            try
            {
                //GetById ya lanza Exceptiones en caso de que no exista el mismo
                var administrador = GetById(id);
                _db.Remove(administrador);
                _db.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new AdministradorException($"Error eliminando administrador con id {id} : {ex.Message}");
            }
        }

        public void Remove(Administrador administrador)
        {
            try
            {
                if (administrador == null) throw new AdministradorException("El administrador que se intenta eliminar no puede ser nulo");
                _db.Remove(administrador);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AdministradorException($"Error al intentar eliminar el administrador: {ex.Message}");
            }
        }

        public void Update(int id, Administrador administradorModificado)
        {
            try
            {
                var administrador = _db.Administradores.Find(id);
                if (id == null)
                    throw new MiembroException($"No existe el miembro con el id {id}");
                if (administrador == null)
                    throw new MiembroException($"Miembro no valido");
                administrador.Modificar(administradorModificado);
                _db.Update(administrador);
                _db.SaveChanges();
            }
            catch( Exception ex)
            {
                throw new AdministradorException($"Error al actualizar el administrador con id {id}: {ex.Message}");
            }
        }
    }
}
