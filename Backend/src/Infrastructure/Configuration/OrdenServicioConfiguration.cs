using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configuration
{
    public class OrdenServicioConfiguration : IEntityTypeConfiguration<OrdenServicio>
    {
        public void Configure(EntityTypeBuilder<OrdenServicio> builder)
        {
            builder.ToTable("ordenes_servicios");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .HasColumnName("orden_id")
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnType("int");

            builder.Property(o => o.VehiculoId)
                .HasColumnName("vehiculo_id")
                .IsRequired()
                .HasColumnType("int");

            builder.Property(o => o.TipoServicioId)
                .HasColumnName("tipo_servicio_id")
                .IsRequired()
                .HasColumnType("int");

            builder.Property(o => o.UsuarioId)
                .HasColumnName("usuario_id")
                .IsRequired(false)
                .HasColumnType("int");

            builder.Property(o => o.FechaIngreso)
                .HasColumnName("fecha_ingreso")
                .IsRequired()
                .HasColumnType("timestamp");

            builder.Property(o => o.FechaEstimada)
                .HasColumnName("fecha_estimada")
                .IsRequired(false)
                .HasColumnType("timestamp");

            builder.HasOne(o => o.Vehiculo)
                .WithMany(v => v.OrdenesServicios)
                .HasForeignKey(o => o.VehiculoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.TipoServicio)
                .WithMany(ts => ts.OrdenServicios)
                .HasForeignKey(o => o.TipoServicioId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.Usuario)
                .WithMany(u => u.OrdenServicios)
                .HasForeignKey(o => o.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}