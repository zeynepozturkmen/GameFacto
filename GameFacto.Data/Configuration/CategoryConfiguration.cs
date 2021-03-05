using GameFacto.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameFacto.Data.Configuration
{
    public class CategoryConfiguration : BaseConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder.Metadata.FindNavigation(nameof(Category.ProductList)).SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
