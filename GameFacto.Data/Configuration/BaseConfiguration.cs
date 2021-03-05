using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GameFacto.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameFacto.Data.Configuration
{
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            //Primary key belirtiliyor
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
        }
    }
}
