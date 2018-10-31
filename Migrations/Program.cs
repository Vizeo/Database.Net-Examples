using System;

namespace Migrations
{
    class Program
    {
        private const string FILE_NAME = "c:\\temp\\Test.db";

        static void Main(string[] args)
        {
            using (var shopContext = new ShopContext(FILE_NAME))
            {
            }
        }
    }
}
