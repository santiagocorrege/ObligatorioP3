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
using Papeleria.LogicaNegocio.ValueObject;

namespace Papeleria.AccesoDatos.Configuraciones
{
    public class ClienteConfiguracion : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            var rutConverter = new ValueConverter<RUT, long>
                (
                    r => r.Valor,
                    r => new RUT(r)
                );

            builder.Property(u => u.RUT).HasConversion(rutConverter);
        }
    }
}
