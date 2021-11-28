using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using DataShopEntityFramework.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace ServerApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ShopDBContext>();
                //Category cat = new Category();
                //cat.Name = "Test category";
                //cat.Description = "Some description";
                //context.Categories.Add(cat);
                //context.SaveChanges();
                //Console.WriteLine("HERE");
                //var list = context.Categories.Where(c => c.Id >= 0).ToList();
                //Console.WriteLine("HERE");
                //foreach (var i in list)
                //{
                //    Console.WriteLine(i.Name);
                //}
            }
            host.Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
           // var port = Environment.GetEnvironmentVariable("PORT");
            return Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureServices(services => services.AddAutofac())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>(); //.UseUrls("http://*:" + port);
                });
        }

    }

}
