using ConsoleApplication1.Logic;
using ConsoleApplication1.Utils;
using System;

namespace ConsoleApplication1
{
    public class Engine
    {
        private const int NumberOfSlots = 12;

        public static void Main(string[] args)
        {
            var randomGenerator = RandomGenerator.Instance;
            var slotGenerator = new SlotGenerator(randomGenerator);
            var winningCalculator = new WinningsCalculator();
            var slotsPrinter = new SlotsPrinter();
            var player = new Player();

            decimal balance;
            UserInputValidation(slotsPrinter.BeginningDepositMessage, player.Deposit, out balance);
            
            while (player.Balance > 0)
            {
                decimal stake;
                UserInputValidation(slotsPrinter.StakeAmountMessage, player.Stake, out stake);

                var slots = slotGenerator.GenerateSlots(NumberOfSlots);
                Console.WriteLine(slotsPrinter.SlotsAsString(slots));

                var winnigs = winningCalculator.CalcWinnigs(slots, stake);
                player.Win(winnigs);
                Console.WriteLine(slotsPrinter.GetWinningsMessage(winnigs));

                Console.WriteLine(slotsPrinter.GetCurrentBalanceMessage(player.Balance));
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static void UserInputValidation(string message, Action<decimal> playerAction, out decimal amount)
        {
            while (true)
            {
                System.Console.WriteLine(message);
                decimal depositAmount;
                if (decimal.TryParse(System.Console.ReadLine(), out depositAmount))
                {
                    amount = depositAmount;
                    playerAction(depositAmount);
                    break;
                }

                System.Console.WriteLine("You've entered an invalid amount!");
            }
        }
    }
}
