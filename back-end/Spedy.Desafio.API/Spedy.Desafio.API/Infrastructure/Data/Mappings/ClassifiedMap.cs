using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spedy.Desafio.API.Models.Entities;

namespace Spedy.Desafio.API.Infrastructure.Data.Mappings
{
    public class ClassifiedMap : IEntityTypeConfiguration<Classified>
    {
        public void Configure(EntityTypeBuilder<Classified> builder)
        {
            builder.ToTable("TB_CLASSIFICADO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_CLASSIFICADO");

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("NM_TITULO");

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("DS_DESCRICAO");

            builder.Property(x => x.Date)
                .HasMaxLength(50)
                .HasColumnName("DT_DATA");

            builder.Property(x => x.Active)
                .HasDefaultValue(false)
                .HasColumnName("FL_ATIVO");
        }
    }
}
