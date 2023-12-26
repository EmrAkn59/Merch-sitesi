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
    public class OrderMap : CoreMap<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.ProductOrders).WithOne(x => x.Order).HasForeignKey(x => x.OrderId);

            base.Configure(builder);
        }
    }
}
