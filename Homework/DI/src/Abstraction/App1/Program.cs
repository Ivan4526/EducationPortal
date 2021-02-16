using System;
using Membership;
using static App.Settings;

namespace App
{
    internal class Program
    {
        private static void Main()
        {
            // --- lowest (closest) abstraction layer ---
            var myAppUser = new MyAppUser
            {
                Id = 1,
                Name = "John",
                IsAuthenticated = true
            };

            // --- higher abstraction ---
            ApplicationUser appUser = myAppUser;

            appUser.Id = 2;
            appUser.Name = "Jack";
            //appUser.IsAuthenticated = true;

            // --- higher abstraction ---
            User<int> user = myAppUser;
            user.Id = 2;
            //user.Name = "Jack";
            //appUser.IsAuthenticated = true;

            // --- highest (most distant) abstraction ---
            IUser anyUser = myAppUser;
            //anyUser.Id = 2;

            // StringAbstraction();
        }

        private static void StringAbstraction()
        {
            var osSettings = SettingsRepository.GetValue(OsGlobalDirectory);

            Console.WriteLine(osSettings.Value);
        }
    }
}
