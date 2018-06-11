using System;

namespace ConsoleApplication1.Utils
{
    public sealed class RandomGenerator
    {
        private static readonly Lazy<RandomGenerator> lazy =
            new Lazy<RandomGenerator>(() => new RandomGenerator());

        public static RandomGenerator Instance { get { return lazy.Value; } }

        private static Random random;

        private RandomGenerator()
        {
            random = new Random();
        }

        public int Next(int from, int to)
        {
            return random.Next(from, to);
        }
    }
}
