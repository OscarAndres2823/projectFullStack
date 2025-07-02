using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("clientes");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("cliente_id")
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnType("int");

            builder.Property(c => c.Nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Telefono)
                .HasColumnName("telefono")
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(c => c.Documento)
                .HasColumnName("documento")
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.HasIndex(c => c.Documento)
                .IsUnique();

            builder.Property(c => c.Correo)
                .HasColumnName("correo")
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");
        }
    }
}