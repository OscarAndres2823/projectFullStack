using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuarios");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("usuario_id")
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnType("int");

            builder.Property(u => u.RolUsuarioId)
                .HasColumnName("rol_id")
                .IsRequired()
                .HasColumnType("int");

            builder.Property(u => u.Correo)
                .HasColumnName("correo")
                .IsRequired()
                .HasColumnType("text");

            builder.Property(u => u.Nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(u => u.Password)
                .HasColumnName("password")
                .IsRequired()
                .HasColumnType("text");

            builder.Property(u => u.Documento)
                .HasColumnName("documento")
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnType("varchar(15)");

            builder.Property(u => u.Telefono)
                .HasColumnName("telefono")
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.HasOne(r => r.RolUsuario)
                .WithMany(u=> u.Usuarios)
                .HasForeignKey(r => r.RolUsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(u => u.Correo).IsUnique();
        }
    }
}