using System;
using Agronomous;
using Agronomous.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Agronomous.Areas.Identity.IdentityHostingStartup))]
namespace Agronomous.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AgronomousContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AgronomousContextConnection")));

                services.AddDefaultIdentity<user>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<AgronomousContext>();
            });
        }
    }
}