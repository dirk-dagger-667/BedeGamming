using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1.Logic
{
    public class SlotsPrinter
    {
        private const string WinningsMessage = "You have won: ";
        private const string CurrentBalanceMessage = "Current Balance is: ";
        private const string GameOverMessage = "Game Over!!!";

        public string BeginningDepositMessage
        {
            get { return "Please deposit money you would like to play with:"; }
        }

        public string StakeAmountMessage
        {
            get { return "Enter stake amount:"; }
        }

        public string SlotsAsString(IList<string> slots)
        {
            var sb = new StringBuilder();

            if (slots == null)
            {
                throw new ArgumentNullException("Slots cannot be null");
            }

            for (int i = 0; i < slots.Count; i += 3)
            {
                sb.AppendLine($"{slots[i]}{slots[i + 1]}{slots[i + 2]}");
            }

            return sb.ToString();
        }

        public string GetWinningsMessage(decimal amount) => $@"{WinningsMessage}{amount}";

        public string GetCurrentBalanceMessage(decimal amount) => $@"{CurrentBalanceMessage}{amount}";
    }
}
