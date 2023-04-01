using System;
using TestierMask.Data;

namespace TestierMask
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new TeisterMaskContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
