using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1.Logic
{
    public class WinningsCalculator
    {
        private const string Wildcard = "*";
        private const string Apple = "A";
        private const string Banana = "B";
        private const string Pineapple = "P";

        private readonly IDictionary<string, decimal> coeficientMap = new Dictionary<string, decimal>
        {
            { "A", 0.4M },
            { "B", 0.6M },
            { "P", 0.8M },
            { "*", 0 },
        };

        public decimal CalcWinnigs(IList<string> slots, decimal stake)
        {
            if (slots == null)
            {
                throw new ArgumentNullException("Slots cannot be null");
            }

            var coeficient = 0M;

            for (int i = 0; i < slots.Count; i += 3)
            {
                coeficient += this.CalcSingleRow(
                    slots[i]
                    , slots[i + 1]
                    , slots[i + 2]
                    );
            }

            return coeficient * stake;
        }

        private decimal CalcSingleRow(string first, string second, string third)
        {
            var distribution = this.GetRowSlotDistribution(first, second, third);
            var repeatingSlotTwice = distribution.FirstOrDefault(pair => pair.Value == 2).Key;
            var repeatingSlotThrice = distribution.FirstOrDefault(pair => pair.Value == 3).Key;
            var wildcardCount = distribution[Wildcard];

            if (wildcardCount == 3)
            {
                return 0;
            }

            if (wildcardCount == 2)
            {
                var keySlot = distribution.FirstOrDefault(pair => pair.Value == 1).Key;

                return this.coeficientMap[keySlot];
            }

            if (!string.IsNullOrWhiteSpace(repeatingSlotThrice) 
                && repeatingSlotThrice != Wildcard)
            {
                return 3 * this.coeficientMap[repeatingSlotThrice];
            }

            if (!string.IsNullOrWhiteSpace(repeatingSlotTwice)
                && repeatingSlotTwice != Wildcard
                && wildcardCount == 1)
            {
                return 2 * this.coeficientMap[repeatingSlotTwice];
            }

            return default(decimal);
        }

        private IDictionary<string, int> GetRowSlotDistribution(string first, string second, string third)
        {
            var distributionDictionary = new Dictionary<string, int>
            {
                { "A", 0 },
                { "B", 0 },
                { "P", 0 },
                { "*", 0 },
            };

            distributionDictionary[first]++;
            distributionDictionary[second]++;
            distributionDictionary[third]++;

            return distributionDictionary;
        }
    }
}
