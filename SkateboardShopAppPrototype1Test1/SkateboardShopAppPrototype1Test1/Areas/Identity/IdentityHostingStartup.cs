using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkateboardShopAppPrototype1Test1.Data;

[assembly: HostingStartup(typeof(SkateboardShopAppPrototype1Test1.Areas.Identity.IdentityHostingStartup))]
namespace SkateboardShopAppPrototype1Test1.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}