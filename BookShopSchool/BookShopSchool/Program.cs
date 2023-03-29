
using BookShopSchool.Data;
using System;

namespace BookShopSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new BookShopSchoolContext();
            context.Database.EnsureCreated();
        }
    }
}
