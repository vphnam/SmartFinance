using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Infrastructure.Configurations.Base
{
    public abstract class EntityBaseConfiguration<TEntity, TId> : IEntityTypeConfiguration<TEntity>
        where TEntity : Domain.Shared.Base.EntityBase<TId>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            var tableName = typeof(TEntity).Name;
            var idColumnName = $"{tableName}Id";

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                   .HasColumnName(idColumnName)
                   .IsRequired();
        }
    }
}
