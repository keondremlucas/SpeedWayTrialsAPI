using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Web
{
    public class Program
    {   
      
        public static void Main(string[] args)
        {   
         
           var host = CreateWebHostBuilder(args).Build();
           
           using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
 
                var context = services.GetRequiredService<Database>();

                PopulateDatabase.Populate(context);
            }
            host.Run();

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
    }
}
