using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static App.Settings;

namespace App
{
    public class SettingsRepository
    {
        public static Settings GetValue(string name)
        {
            return SettingsFactory.TryGetValue(name, out var factory) 
                ? factory() 
                : null;
        }

        private static readonly Dictionary<string, Func<Settings>> SettingsFactory = 
            new Dictionary<string, Func<Settings>>
            {
                [OsGlobalDirectory] = GetOsGlobalDirectory
            };

        private static Settings GetOsGlobalDirectory()
        {
            string globalDirectory;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                globalDirectory = RuntimeInformation.OSArchitecture == Architecture.X64
                    ? "Program Files"
                    : "Program Files (x86)";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                globalDirectory = @"usr/local";
            }
            else
            {
                throw new NotSupportedException("OS os not suppoerted");
            }

            return new Settings
            {
                Name = OsGlobalDirectory,
                Value = globalDirectory
            };
        }
    }
}