using Database.NET;
using Database.NET.Relational;
using Migrations.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Migrations
{
    public class ShopContext : DbContext
    {
        public ShopContext(string filePath)
            : base(filePath, TextEncodingType.ASCII, new IMigration[] {
                new AddOrderNumberMigration() //Adds the order number if it is not there 
            })
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
