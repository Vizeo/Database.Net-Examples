using Database.NET;
using Database.NET.Relational;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud_Operations
{
    public class ShopContext : DbContext
    {
        public ShopContext(string filePath)
            : base(filePath, TextEncodingType.ASCII)
        {
        }

        public DbSet<Item> Items { get; set; }
    }
}
