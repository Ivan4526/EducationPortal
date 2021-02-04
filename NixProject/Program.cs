using Interfaces;
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
            //.AddSingleton<IRepository<User>>(x => new JsonRepository<User>(@"D:\json\Users.json"))
            .AddSingleton<IRepository<Course>>(x => new JsonRepository<Course>(@"D:\json\Courses.json"))
            .AddSingleton<IRepository<User>, ADORepository<User>>()
            .AddSingleton<IUserService, UserService>()
            .AddSingleton<ICourseService, CourseService>()
            .AddSingleton<IPasswordHasher, MD5Hasher>()
            .BuildServiceProvider();
        static void Main(string[] args)
        {
            var service = SetupServices();
            ICourseService courseService = service.GetService<ICourseService>();
            IUserService userService = service.GetService<IUserService>();
            Console.WriteLine("Choose option:\n1 - Registration\n2 - Login");
            string input = Console.ReadLine();
            bool mustLogin = true;
            while (mustLogin)
            {
                if (input == "1")
                {
                    Console.WriteLine("Id:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Password:");
                    string password = Console.ReadLine();
                    userService.CreateUser(new User { Id = id, Name = name, Password = password, Role = new Role { Id = 1, Name = "Default" } });
                    mustLogin = false;
                }
                else if (input == "2")
                {
                    Console.WriteLine("Id:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Password:");
                    string password = Console.ReadLine();
                    //User newUser = new User { Id = id, Name = name, Password = password };
                    var user = userService.GetUser(id);
                    if (user == null)
                        Console.WriteLine("There is no user with this data");
                    else
                    {
                        Console.WriteLine("Success login!");
                        mustLogin = false;
                    }
                }
            }
            Console.WriteLine("Choose option:\n1 - upload course");
            string input1 = Console.ReadLine();
            if (input1 == "1")
            {
                Console.WriteLine("Id:");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Name of course:");
                string courseName = Console.ReadLine();
                Console.WriteLine("Briefly description:");
                string description = Console.ReadLine();
                courseService.CreateCourse(new Course { Id = id, Name = courseName, Description = description });
            }

        }
    }
}
