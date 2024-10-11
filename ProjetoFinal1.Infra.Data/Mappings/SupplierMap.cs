using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoFinal1.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal1.Infra.Data.Mappings
{
    public class SupplierMap : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("SUPPLIERS"); //table name

            builder.HasKey(s => s.Id); //primary key

            builder.Property(s => s.Id).HasColumnName("ID");

            builder.Property(s => s.Name).HasColumnName("NAME")
                .HasMaxLength(50).IsRequired();

            builder.HasIndex(s => s.Name).IsUnique();
        }
    }
}
