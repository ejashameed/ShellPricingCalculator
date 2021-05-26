using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PricingCalculator.BusinessServices.Handlers;
using PricingCalculator.BusinessServices.Models;
using PricingCalculator.BusinessServices.Processors;
using PricingCalculator.BusinessServices.Processors.DiscountProcessors;
using PricingCalculator.BusinessServices.Processors.OrderProcessors;
using PricingCalculator.BusinessServices.Validators;
using PricingCalculator.DataServices.Repositories;
using PricingCalculator.OutputProcessors;
using Serilog;
using System;
using System.IO;


namespace PricingCalculator
{

    class Program
    {
        static void Main(string [] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            // use serilog for console output & logging
            Log.Logger = new LoggerConfiguration()                
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            Log.Logger.Information("Starting ShoppingBasket.com");

            // register classes in the DI container
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IOrderRequestHandler, OrderRequestHandler>();
                    services.AddTransient<IOrderProcessor, ShoppingBasketProcessor>();
                    services.AddTransient<IDbContext, DbContext>();
                    services.AddTransient<IDiscountProcessor, DiscountProcessor>();
                    services.AddTransient<WeeklyDiscountProcessor>();
                    services.AddTransient<BuyXGetYDiscountProcessor>();
                    services.AddTransient<OrderValidator>();
                    services.AddTransient<IOutputTextFormatter, BaseTextFormatter>();
                    services.AddTransient<OutputTextRegular>();
                    services.AddTransient<OutputTextWithOffer>();
                })
                .UseSerilog()
                .Build();

            // activate startup class
            var svc = ActivatorUtilities.CreateInstance<OrderRequestHandler>(host.Services);

            try
            {
                // receive order items and add it to a list
                if (args.Length > 0)
                {

                    string [] items = { };
                    var orderItems = new OrderItemModel();

                    for (int i = 0; i < args.Length; i++)
                    {
                        orderItems.itemList.Add(args [i].ToString());
                    }

                    // start processing of order items for pricing                    
                    Log.Logger.Information(svc.HandleRequest(orderItems));

                    Console.WriteLine("Press any key to exit");
                    Console.ReadLine();
                }
                else
                {
                    throw new Exception("Please enter the order items to process");
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error("An error occured while processing your order.");
                Log.Logger.Error(ex.Message);
            }

        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            // load appsettings.json - any configuration can be stored here.
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
        }
    }

}
