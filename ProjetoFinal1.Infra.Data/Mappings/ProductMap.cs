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
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("PRODUCT"); //table name

            builder.HasKey(p => p.Id); //primary key

            builder.Property(p => p.Id).HasColumnName("ID");

            builder.Property(p => p.Name).HasColumnName("NAME")
                .IsRequired();

            builder.Property(p => p.Price).HasColumnName("PRICE")
                .HasColumnType("decimal(10,2)").IsRequired();

            builder.Property(p => p.Quantity).HasColumnName("QUANTITY")
                .IsRequired();

            builder.Property(p => p.SupplierId).HasColumnName("SUPPLIER ID")
                .IsRequired();

            builder.HasOne(p => p.Supplier) //One product has one supplier
                .WithMany(s => s.Products) //One Supplier has many products
                .HasForeignKey(p => p.SupplierId) //Foreign key
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
