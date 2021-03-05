using GameFacto.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameFacto.Data.Configuration
{
    public class ProductConfiguration : BaseConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Category)
           .WithMany(x => x.ProductList)
           .HasForeignKey(x => x.CategoryId);
        }
    }
}
