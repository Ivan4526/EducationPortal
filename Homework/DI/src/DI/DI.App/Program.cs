using DI.App.Abstractions;
using DI.App.Abstractions.BLL;
using DI.App.Abstractions.PL;
using DI.App.Services;
using DI.App.Services.PL;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DI.App
{
    interface IRepository<T>
    {

    }

    internal class Program
    {
        private static void Main()
        {

            // Inversion of Control
            IServiceProvider services = MyDI.SetupServices();
            //var manager = new CommandManager();
            var manager = services.GetService<ICommandManager>();

            manager.Start();



        }
    }
}
