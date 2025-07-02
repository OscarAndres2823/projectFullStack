using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configuration
{
    public class FacturaConfiguration : IEntityTypeConfiguration<Factura>
    {
         public void Configure(EntityTypeBuilder<Factura> builder)
        {
            builder.ToTable("facturas");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id)
                .HasColumnName("factura_id")
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnType("int");

            builder.HasOne(o => o.OrdenServicio)
                .WithMany(f => f.Facturas)
                .HasForeignKey(o => o.OrdenServicioId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(f => f.MontoTotal)
                .HasColumnName("monto_total")
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder.Property(f => f.ManoObra)
                .HasColumnName("mano_obra")
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder.Property(f => f.ValorTotal)
                .HasColumnName("valor_total")
                .IsRequired()
                .HasColumnType("decimal(10,2)");
        }
    }
}