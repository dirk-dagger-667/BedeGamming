using System;
using System.Collections.Generic;

namespace ConsoleApplication1.Logic
{
    public class WinningsCalculator
    {
        public decimal CalcWinnigs(IList<string> slots)
        {
            if (slots == null)
            {
                throw new ArgumentNullException("Slots cannot be null");
            }

            var amount = 0M;

            for (int i = 0; i < slots.Count / 3; i++)
            {
                amount += this.CalcSingleRow(
                    slots[i % 3]
                    , slots[(i + 1) % 3]
                    , slots[(i + 2) % 3]
                    );
            }

            return amount;
        }

        private decimal CalcSingleRow(string first, string second, string third)
        {
            return default(decimal);
        }
    }
}
