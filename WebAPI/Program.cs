
using Microsoft.EntityFrameworkCore;
using Papeleria.AccesoDatos.EF;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Articulo;
using Papeleria.LogicaAplicacion.ImplementacionCasosUso.Pedido;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Articulo;
using Papeleria.LogicaAplicacion.InterfacesCasosUso.Pedidos;
using Papeleria.LogicaNegocio.InterfacesRepositorios;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<PapeleriaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionPapeleria")));

            builder.Services.AddSession();

            builder.Services.AddScoped<IRepositorioArticulo, RepositorioArticuloEF>();
            builder.Services.AddScoped<IRepositorioPedido, RepositorioPedidoEF>();

            //Articulo
            builder.Services.AddScoped<IGetArticulosAlfabeticamente, GetArticulosAlfabeticamente>();

            //Pedido 
            builder.Services.AddScoped<IGetPedidosAnulados, GetPedidosAnulados>();


            builder.Services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.None;
                options.HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always;
                options.Secure = CookieSecurePolicy.Always;
            });
            builder.Services.AddAntiforgery(options =>
            {
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.SameSite = SameSiteMode.Strict;
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
