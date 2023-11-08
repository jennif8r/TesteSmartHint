using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(p => p.Documento)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(p => p.Mail)
               .IsRequired()
               .HasColumnType("varchar(150)");

            builder.Property(p => p.Telefone)
               .IsRequired()
               .HasColumnType("varchar(11)");

            builder.Property(p => p.InscricaoEstadual)
           .HasColumnType("varchar(12)")
           .IsRequired(false);

            builder.Property(p => p.Senha)
              .IsRequired()
              .HasColumnType("varchar(15)");

            builder.Property(p => p.DataNascimento)
            .HasColumnType("date")
            .IsRequired(false);

            builder.ToTable("Clientes");
        }
    }
}