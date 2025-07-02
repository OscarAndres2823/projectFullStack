using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configuration
{
    public class RepuestosConfiguration : IEntityTypeConfiguration<Repuesto>
    {
        public void Configure(EntityTypeBuilder<Repuesto> builder)
        {
            builder.ToTable("repuestos");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                .HasColumnName("repuesto_id")
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnType("int");

            builder.Property(r => r.Nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(r => r.Codigo)
                .HasColumnName("codigo")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(r => r.Descripcion)
                .HasColumnName("descripcion")
                .HasColumnType("text");

            builder.Property(r => r.Stock)
                .HasColumnName("stock")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(r => r.PrecioUnitario)
                .IsRequired()
                .HasColumnType("decimal(10,2)");
        }
    }
}