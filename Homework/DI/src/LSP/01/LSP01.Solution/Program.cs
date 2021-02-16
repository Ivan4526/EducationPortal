using System.Collections.Generic;
using System.Linq;

namespace LSP01.Solution
{
    internal class Program
    {
        private static void Main()
        {
            var birds = new Bird[]
            {
                new Duck(),
                new Colibri(),
                new Penguin(),
                new Ostrich()
            };

            FlyBirdsFly(birds);
        }

        private static void FlyBirdsFly(IEnumerable<Bird> birds)
        {
            var flyableBirds = birds
                .Where(b => b is FlyableBird)
                .Cast<FlyableBird>();

            foreach (var bird in flyableBirds)
            {
                bird.Fly();
            }
        }
    }
}
