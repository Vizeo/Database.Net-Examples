using System;
using System.IO;

namespace Crud_Operations
{
    class Program
    {
        private const string FILE_NAME = "c:\\temp\\Test.db";

        static void Main(string[] args)
        {
            if(File.Exists(FILE_NAME))
            {
                File.Delete(FILE_NAME);
            }

            Create();
            Read();
            Update();
            Delete();

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public static void Create()
        {
            using (var shopContext = new ShopContext(FILE_NAME))
            {
                var item = shopContext.Items.CreateProxy();
                item.Name = "Pillow";
                item.Price = 45;

                shopContext.Items.Add(item);

                shopContext.SaveChanges();
            }
        }

        public static void Read()
        {
            using (var shopContext = new ShopContext(FILE_NAME))
            {                
                var item = shopContext.Items.First(i => i.Name == "Pillow");
                Console.WriteLine($"ID: {item.ItemId} Name: {item.Name} Price: {item.Price}");
            }
        }

        public static void Update()
        {
            using (var shopContext = new ShopContext(FILE_NAME))
            {
                var item = shopContext.Items.First(i => i.ItemId == 1);
                item.Price = 75;
                shopContext.SaveChanges();
            }
        }

        public static void Delete()
        {
            using (var shopContext = new ShopContext(FILE_NAME))
            {
                var item = shopContext.Items.First(i => i.ItemId == 1);

                shopContext.Items.Remove(item);

                shopContext.SaveChanges();
            }
        }
    }
}
