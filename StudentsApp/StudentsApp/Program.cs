
using StudentsApp.Data;
using System;

namespace StudentsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SchoolContext();
            context.Database.EnsureCreated();
        }
    }
}
