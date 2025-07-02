using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configuration
{
    public class VehiculoConfiguration : IEntityTypeConfiguration<Vehiculo>
    {
        public void Configure(EntityTypeBuilder<Vehiculo> builder)
        {
            builder.ToTable("vehiculos");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                .HasColumnName("vehiculo_id")
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnType("int");

            builder.Property(v => v.ClienteId)
                .HasColumnName("cliente_id")
                .IsRequired()
                .HasColumnType("int");

            builder.Property(v => v.Marca)
                .HasColumnName("marca")
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(v => v.Modelo)
                .HasColumnName("modelo")
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(v => v.Year)
                .HasColumnName("year")
                .IsRequired()
                .HasColumnType("int");

            builder.Property(v => v.Vin)
                .HasColumnName("vin")
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");

            builder.HasIndex(v => v.Vin).IsUnique();

            builder.Property(v => v.Kilometraje)
                .HasColumnName("kilometraje")
                .IsRequired()
                .HasColumnType("decimal(10,2)");
        }
    }
}