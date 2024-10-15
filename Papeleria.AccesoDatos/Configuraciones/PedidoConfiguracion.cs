using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using SistemaAutenticacion.Entidades;
using SistemaAutenticacion.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Papeleria.LogicaNegocio.Entidades;

namespace Papeleria.AccesoDatos.Configuraciones
{
    public class PedidoConfiguracion : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.OwnsMany(pedido => pedido.Lineas);
        }
    }
}
