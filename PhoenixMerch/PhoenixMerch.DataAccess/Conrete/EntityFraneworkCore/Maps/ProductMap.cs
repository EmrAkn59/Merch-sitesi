using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoenixMerch.Core.Maps;
using PhoenixMerch.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixMerch.DataAccess.Conrete.EntityFraneworkCore.Maps
{
    public class ProductMap : CoreMap<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired();

            builder.HasMany(x => x.ProductOrders).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);

            base.Configure(builder);
        }
    }
}
