using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configuration
{
    public class TipoServicioConfiguration : IEntityTypeConfiguration<TipoServicio>
    {
        public void Configure(EntityTypeBuilder<TipoServicio> builder)
        {
            builder.ToTable("tipos_servicios");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("tipo_servicio_id")
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnType("int");

            builder.Property(t => t.Nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.HasMany(t => t.OrdenServicios)
                .WithOne(os => os.TipoServicio)
                .HasForeignKey(os => os.TipoServicioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}