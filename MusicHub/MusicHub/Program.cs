using MusicHub.Data;
using System;

namespace MusicHub
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new MusicHubContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
