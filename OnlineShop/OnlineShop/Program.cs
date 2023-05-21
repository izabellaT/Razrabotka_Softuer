using OnlineShop.Data;
using System;

namespace OnlineShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new OnlineShopContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
