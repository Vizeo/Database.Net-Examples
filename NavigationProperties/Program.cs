using System;
using System.IO;
using System.Linq;

namespace NavigationProperties
{
    class Program
    {
        private const string FILE_NAME = "c:\\temp\\Test.db";

        static void Main(string[] args)
        {
            if (File.Exists(FILE_NAME))
            {
                File.Delete(FILE_NAME);
            }

            CreateItems();
            CreateOrder();
            DisplayOrder();
            RemoveItem();
            DisplayOrder();

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public static void CreateItems()
        {
            using (var shopContext = new ShopContext(FILE_NAME))
            {
                var pillow = shopContext.Items.CreateProxy();
                pillow.Name = "Pillow";
                pillow.Price = 45;
                shopContext.Items.Add(pillow);

                var blanket = shopContext.Items.CreateProxy();
                blanket.Name = "Blanket";
                blanket.Price = (decimal)20.5;

                shopContext.Items.Add(blanket);

                shopContext.SaveChanges();
            }
        }

        public static void CreateOrder()
        {
            using (var shopContext = new ShopContext(FILE_NAME))
            {
                var order = shopContext.Orders.CreateProxy();
                order.CustomerName = "John Doe";

                var pillow = shopContext.Items.First(i => i.Name == "Pillow");
                var blanket = shopContext.Items.First(i => i.Name == "Blanket");

                var orderItem1 = shopContext.OrderItems.CreateProxy();
                orderItem1.Item = pillow;
                orderItem1.Quantity = 2;
                order.OrderItems.Add(orderItem1);

                var orderItem2 = shopContext.OrderItems.CreateProxy();
                orderItem2.Item = blanket;
                orderItem2.Quantity = 1;
                order.OrderItems.Add(orderItem2);

                shopContext.Orders.Add(order);

                shopContext.SaveChanges();
            }
        }

        public static void DisplayOrder()
        {
            using (var shopContext = new ShopContext(FILE_NAME))
            {
                var order = shopContext.Orders.First();
                DisplayOrderItems(order);
            }
        }

        public static void RemoveItem()
        {
            using (var shopContext = new ShopContext(FILE_NAME))
            {
                var order = shopContext.Orders.First();

                var orderItem = order.OrderItems.First(i => i.Item.Name == "Pillow");

                //Does not delete the item from the database but set the foreign key to the default value
                order.OrderItems.Remove(orderItem); 

                shopContext.SaveChanges();

                Console.WriteLine($"ID: {orderItem.Item.ItemId} Name: {orderItem.Item.Name} OrderId: {orderItem.Order_Id}");

                //If you want to delete the item from both the order and the database do this line
                shopContext.OrderItems.Remove(orderItem);

                shopContext.SaveChanges();
            }
        }

        private static void DisplayOrderItems(Order order)
        {
            Console.WriteLine("Order Items");
            foreach(var orderItem in order.OrderItems)
            {
                Console.WriteLine($"ID: {orderItem.Item.ItemId} Name: {orderItem.Item.Name} Price: {orderItem.Item.Price} OrderId: {orderItem.Order.OrderId} Quantity: {orderItem.Quantity}");
            }
        }
    }
}
