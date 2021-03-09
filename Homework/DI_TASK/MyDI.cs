using DI.App.Abstractions;
using DI.App.Abstractions.BLL;
using DI.App.Abstractions.PL;
using DI.App.Models;
using DI.App.Services;
using DI.App.Services.PL;
using DI.App.Services.PL.Commands;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DI.App
{
    public static  class MyDI
    {
        public static IServiceProvider SetupServices()
           => new ServiceCollection()
            .AddSingleton<IUserStore, UserStore>()
            .AddSingleton<ICommandProcessor, CommandProcessor>()
            .AddSingleton<ICommand, AddUserCommand>()
            .AddSingleton<IDatabaseService, InMemoryDatabaseService>()
            .BuildServiceProvider();
    }
}
