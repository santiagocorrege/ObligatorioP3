﻿using Papeleria.LogicaNegocio.Exceptions.Miembro;
using Papeleria.LogicaNegocio.InterfacesRepositorios;
using SistemaAutenticacion.Entidades;
using SistemaAutenticacion.Exceptions.Usuario;
using SistemaAutenticacion.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.EF
{
    public class RepositorioUsuarioEF : IRepositorioUsuario
    {
        private PapeleriaContext _db;

        public RepositorioUsuarioEF(PapeleriaContext db)
        {
            _db = db;
        }

        public Usuario GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario GetByUsuarioLogin(string email, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) throw new ArgumentException("El usuario y/o contrasenas no pueden ser nulos");
                string pass = Password.Encrypt(password);
                var usuario = _db.Usuarios.AsEnumerable().SingleOrDefault(u => u.Email.Valor.Equals(email) && u.Password.Encriptada.Equals(pass));
                
                if (usuario == null) throw new UsuarioException($"Usuario y/o password invalidos");
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Add(Usuario obj)
        {
            
        }

        public void Update(int id, Usuario obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }
    }

}
