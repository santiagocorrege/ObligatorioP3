using Papeleria.LogicaNegocio.InterfacesRepositorios;
using Papeleria.AccesoDatos.EF;
using Papeleria.LogicaAplicacion.InterfacesCasosUso;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Administrador;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Administrador;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Articulo;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Articulo;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Cliente;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Cliente;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Miembro;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Miembro;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Pedidos;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Pedido;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Usuario;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Usuario;
using Microsoft.EntityFrameworkCore;

namespace MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Lee la conexion desde appsettings.json
            builder.Services.AddDbContext<PapeleriaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionPapeleria")));

            builder.Services.AddSession();

            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();
            builder.Services.AddScoped<IRepositorioAdministrador, RepositorioAdministradorEF>();
            builder.Services.AddScoped<IRepositorioArticulo, RepositorioArticuloEF>();
            builder.Services.AddScoped<IRepositorioCliente, RepositorioClienteEF>();
            builder.Services.AddScoped<IRepositorioMiembro, RepositorioMiembroEF>();
            builder.Services.AddScoped<IRepositorioParametro, RepositorioParametroEF>();
            builder.Services.AddScoped<IRepositorioPedido, RepositorioPedidoEF>();

            //User
            builder.Services.AddScoped<IGetUsuarioLogin, GetUsuarioLogin>();

            //Admin
            builder.Services.AddScoped<IAddAdministrador, AddAdministrador>();
            builder.Services.AddScoped<IDeleteAdministrador, DeleteAdministrador>();
            builder.Services.AddScoped<IGetAdministrador, GetAdministrador>();
            builder.Services.AddScoped<IGetAllAdministrador, GetAllAdministrador>();
            builder.Services.AddScoped<IGetByNombreAdministradores, GetByNombreAdministradores>();
            builder.Services.AddScoped<IUpdateAdministrador, UpdateAdministrador>();

            //Articulo
            builder.Services.AddScoped<IAddArticulo, AddArticulo>();
            builder.Services.AddScoped<IGetArticulosAlfabeticamente,  GetArticulosAlfabeticamente>();

            //Cliente
            builder.Services.AddScoped<IGetAllCliente, GetAllCliente>();
            builder.Services.AddScoped<IGetClienteById, GetClienteById>();
            builder.Services.AddScoped<IGetClienteByNombre, GetClienteByNombre>();
            builder.Services.AddScoped<IGetClientesSuperanMonto, GetClientesSuperanMonto>();

            //Miembro
            builder.Services.AddScoped<IAltaMiembro, AltaMiembro>();
            builder.Services.AddScoped<IEliminarMiembro, EliminarMiembro>();
            builder.Services.AddScoped<IGetAllMiembro, GetAllMiembro>();
            builder.Services.AddScoped<IGetByNombreMiembros, GetByNombreMiembros>();
            builder.Services.AddScoped<IGetMiembro,  GetMiembro>();
            builder.Services.AddScoped<IModificarMiembro,  ModificarMiembro>();

            //Pedidos
            builder.Services.AddScoped<IAddPedido, AddPedido>();
            builder.Services.AddScoped<IGetAllPedido, GetAllPedido>();
            builder.Services.AddScoped<IGetPedidoById, GetPedidoById>();
            builder.Services.AddScoped<IGetPedidosNoEntregadosFecha, GetPedidosNoEntregadosFecha>();
            builder.Services.AddScoped<IAnularPedido, AnularPedido > ();
            builder.Services.AddScoped<IGetPedidosAnulados, GetPedidosAnulados>();

            var app = builder.Build();

            app.UseSession();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Login}");
            ///{id?}
            app.Run();
        }
    }
}
