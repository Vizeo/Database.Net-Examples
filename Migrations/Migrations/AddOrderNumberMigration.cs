using Database.NET.Relational;
using System;
using System.Collections.Generic;
using System.Text;

namespace Migrations.Migrations
{
    public class AddOrderNumberMigration : IMigration
    {
        public int MigrationOrder => 1;

        public void Run(SchemaAlter schemaAlter, MigrationTransaction transaction)
        {
            schemaAlter.AlterTable<Order>("Orders", (row, order) => {
                order.OrderNumber = ((int)row["OrderId"]) + 1000;
            }, transaction);
        }
    }
}
