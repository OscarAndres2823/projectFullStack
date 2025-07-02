using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class AuditoriaConfiguration : IEntityTypeConfiguration<Auditoria>
    {
        public void Configure(EntityTypeBuilder<Auditoria> builder)
        {
            builder.ToTable("auditorias");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .HasColumnName("auditoria_id")
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnType("int");

            builder.Property(a => a.Entidad)
                .HasColumnName("entidad")
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(a => a.Accion)
                .HasColumnName("accion")
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(a => a.UsuarioId)
                .HasColumnName("usuario_id")
                .IsRequired()
                .HasColumnType("int");

            builder.Property(a => a.Fecha)
                .HasColumnName("Fecha")
                .IsRequired()
                .HasColumnType("timestamp");

            builder.HasOne(u => u.Usuario)
                .WithMany(a => a.Auditorias)
                .HasForeignKey(u => u.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}