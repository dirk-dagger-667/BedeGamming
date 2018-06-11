using ConsoleApplication1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1.Logic
{
    public class SlotGenerator
    {
        private RandomGenerator randomGenerator;

        private static readonly IDictionary<Func<int, bool>, string> chanceDistribution =
            new Dictionary<Func<int, bool>, string>
            {
                { key => key > 0 && key < 46, "A"},
                { key => key > 45 && key < 81, "B"},
                { key => key > 80 && key < 96, "P" },
                { key => key > 95 && key < 101, "*" }
            };

        public SlotGenerator(RandomGenerator randomGenerator)
        {
            this.randomGenerator = randomGenerator;
        }

        public IList<string> GenerateSlots(int numberOfSlots)
        {
            if (numberOfSlots % 3 != 0)
            {
                return null;
            }

            var slots = new List<string>();

            for (int i = 0; i < numberOfSlots; i++)
            {
                var randomNumber = this.randomGenerator.Next(1, 101);
                var slot = chanceDistribution.First(sw => sw.Key(randomNumber)).Value;
                slots.Add(slot);
            }

            return slots;
        }
    }
}
