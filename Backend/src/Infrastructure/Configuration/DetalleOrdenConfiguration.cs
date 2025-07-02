using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configuration
{
    public class DetalleOrdenConfiguration : IEntityTypeConfiguration<DetalleOrden>
    {
        public void Configure(EntityTypeBuilder<DetalleOrden> builder)
        {
            builder.ToTable("detalles_ordenes");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .HasColumnName("detalle_orden_id")
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnType("int");

            builder.Property(d => d.Cantidad)
                .HasColumnName("cantidad")
                .IsRequired()
                .HasColumnType("int");

            builder.Property(c => c.PrecioTotal)
                .HasColumnName("precio_total")
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder.HasOne(o => o.OrdenServicio)
            .WithMany(d => d.DetalleOrdenes)
            .HasForeignKey(o => o.OrdenServicioId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.Repuesto)
                .WithMany(d => d.DetalleOrdenes)
                .HasForeignKey(r => r.RepuestoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}