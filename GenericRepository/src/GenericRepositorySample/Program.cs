﻿using System.IO;
using GenericRepositorySample.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GenericRepositorySample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var sample = new Startup(Directory.GetCurrentDirectory());

            var serviceCollection = new ServiceCollection();
            sample.ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            sample.Configure(serviceProvider.GetService<ILoggerFactory>());

            sample.Run(serviceProvider);
        }
    }
 
}
