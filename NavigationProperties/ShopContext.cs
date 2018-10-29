using Database.NET;
using Database.NET.Relational;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavigationProperties
{
    public class ShopContext : DbContext
    {
        public ShopContext(string filePath)
            : base(filePath, TextEncodingType.ASCII)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
