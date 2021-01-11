using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models;
using Repository;
using Service;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace NixProject
{
    class Program
    {
        static IServiceProvider SetupServices()
            => new ServiceCollection()
            .AddSingleton<IRepository<User>, UserJsonRepository<User>>()
            .AddSingleton<IUserService, UserService>()
            .AddSingleton<IPasswordHasher, MD5Hasher>()
            .BuildServiceProvider();
        static void Main(string[] args)
        {
            var service = SetupServices();
            IUserService userService = service.GetService<IUserService>();
            IPasswordHasher hasher = service.GetService<IPasswordHasher>();
            Console.WriteLine("Choose option:\n1 - Registration\n2 - Login");
            bool mustLogin = true;
            while (mustLogin) { 
            string input = Console.ReadLine();
            if (input == "1")
            {
                Console.WriteLine("Id:");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Password:");
                string password = Console.ReadLine();
                userService.AddUser(new User { Id = id, Name = name, Password = password, Role = new Role { Id = 1, Name = "Default" } });
            }
            else if (input == "2")
            {
                Console.WriteLine("Id:");
                int id = Convert.ToInt32(Console.ReadLine()); 
                Console.WriteLine("Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Password:");
                string password = Console.ReadLine();
                password = hasher.ComputeHash(password);
                var user = userService.GetUser(u => u.Id == id && u.Name == name && u.Password == password);
                if (user == null)
                    Console.WriteLine("There is no user with this data");
                else
                    Console.WriteLine("Success login!");
                    mustLogin = false;
            }
            }
            Console.WriteLine("Choose option:\n1 - upload course");
            string input1 = Console.ReadLine();
            if (input1 == "1")
            {
                Console.WriteLine("Name of course:");
                string courseName = Console.ReadLine();
                Console.WriteLine("Briefly description:");
                string description = Console.ReadLine();

                
            }

        }
    }
}
