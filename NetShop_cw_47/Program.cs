using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NetShop_cw_47.Models;
using Newtonsoft.Json;

namespace NetShop_cw_47
{
    public class Program
    {
        //static Currencies[] currencies { get; set; }
        public static void Main(string[] args)
        {
            var webHost = BuildWebHost(args);
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<MobileContext>();
                    ModelData.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Error while initializing model data");
                }
            }

            Currencies[] currencies = new Currencies[] 
            {
                new Currencies (){CurrencyCode = "RUB", CurrencyName = "Рубль", CurrencyRate = 57},
                new Currencies (){CurrencyCode = "KGS", CurrencyName = "Сом", CurrencyRate = 68},
                new Currencies (){CurrencyCode = "EUR", CurrencyName = "Евро", CurrencyRate = 0.83}
            };

            File.WriteAllText("wwwroot/Currencies.json", JsonConvert.SerializeObject(currencies));
            //DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Currencies[]));

            //using (FileStream fs = new FileStream("wwwroot/Currencies.json", FileMode.OpenOrCreate))
            //{
            //    jsonFormatter.WriteObject(fs, currencies);
            //}

            webHost.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
