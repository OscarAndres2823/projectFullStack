using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configuration
{
    public class RolUsuarioConfiguration : IEntityTypeConfiguration<RolUsuario>
    {
        public void Configure(EntityTypeBuilder<RolUsuario> builder)
        {
            builder.ToTable("roles_usuarios");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                .HasColumnName("rol_id")
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnType("int");

            builder.Property(r => r.Nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.HasMany(r => r.Usuarios)
                .WithOne(u => u.RolUsuario)
                .HasForeignKey(u => u.RolUsuarioId);
        }
    }
}