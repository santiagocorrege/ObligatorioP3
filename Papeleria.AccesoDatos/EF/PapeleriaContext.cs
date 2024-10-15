using Papeleria.LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaAutenticacion.Entidades;
using SistemaAutenticacion.ValueObject;
using Papeleria.LogicaNegocio.ValueObject;
using Papeleria.LogicaNegocio.Entidades.Parametros;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Papeleria.AccesoDatos.Configuraciones;

namespace Papeleria.AccesoDatos.EF
{
    public class PapeleriaContext : DbContext
    {
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Cliente> Clientes{ get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoComun> PedidosComun { get; set; }
        public DbSet<PedidoExpress> PedidosExpress { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Miembro> Miembros { get; set; }

        public DbSet<Parametro> Parametros { get; set;}

        //Especificar la cadena de conexión

        //Las opciones estan en Program.cs en Services.AddDbContext
        public PapeleriaContext(DbContextOptions<PapeleriaContext> options) : base(options) { }


        //Esto se comenta
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer(@"SERVER=(localDb)\MsSqlLocalDb;DATABASE=PapeleriaObligatorio;Integrated Security=true;Encrypt=false"); ERA ESTE
        //    // optionsBuilder.UseSqlServer(@"SERVER=(localDb)\MsSqlLocalDb;Database=LibreriaV3;Integrated Security=true;Encrypt=false");
        //    //optionsBuilder.UseSqlServer(@"SERVER=(localDb)\MsSqlLocalDb;Database=LibreriaV3;User id=Juana;Password=123a");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UsuarioConfiguracion().Configure(modelBuilder.Entity<Usuario>());
            new ClienteConfiguracion().Configure(modelBuilder.Entity<Cliente>());
            new PedidoConfiguracion().Configure(modelBuilder.Entity<Pedido>());

            //modelBuilder.ApplyConfiguration(new UsuarioConfiguration());

            //modelBuilder
            //    .Entity<Usuario>()
            //    .Property(usuario => usuario.Email)
            //    .HasConversion(
            //        v => v.Valor,
            //        v => new Email(v)
            //    );

            //modelBuilder
            //    .Entity<Cliente>()
            //    .Property(cliente => cliente.RUT)
            //    .HasConversion(
            //        r => r.Valor,
            //        r => new RUT(r)
            //    );

            //modelBuilder
            //    .Entity<Pedido>()
            //    .OwnsMany(pedido => pedido.Lineas);

        }


    }
}
