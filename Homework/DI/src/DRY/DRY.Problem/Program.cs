using System;
using System.Globalization;

namespace DRY.Problem
{
    internal class Program
    {
        private static void Main()
        {
            var format = "Local";

            var now = format == "Local"
                ? DateTime.Now.ToString(CultureInfo.InvariantCulture)
                : format == "Utc"
                    ? DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)
                    : throw new NotSupportedException($"Format {format} is not supported");

            Console.WriteLine(now);

            // do something...

            format = "Local";

            now = format == "Local"
                ? DateTime.Now.ToString(CultureInfo.InvariantCulture)
                : format == "Utc"
                    ? DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)
                    : throw new NotSupportedException($"Format {format} is not supported");

            Console.WriteLine(now);

            // do something

            format = "Utc";

            now = format == "Local"
                ? DateTime.Now.ToString(CultureInfo.InvariantCulture)
                : format == "Utc"
                    ? DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)
                    : throw new NotSupportedException($"Format {format} is not supported");

            Console.WriteLine(now);
        }
    }
}
