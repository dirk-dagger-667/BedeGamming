using ConsoleApplication1.Logic;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class Engine
    {
        static void Main(string[] args)
        {
            var winningCalculator = new WinningsCalculator();
            var winnings = winningCalculator.CalcWinnigs(new List<string> { "B", "A", "A", "A", "A", "A", "A", "*", "B", "*", "A", "A" }, 10M);

            var printer = new SlotsPrinter();

            var currentBalanceMessage = printer.GetCurrentBalanceMessage(10);
            var depositMessage = printer.GetDepositMessage(10);
            var stakeMessage = printer.GetStakeAmountMessage(10);
            var winningsMessage = printer.GetWinningsMessage(10);
            var slotsAsString = printer.SlotsAsString(new List<string> { "B", "A", "A", "A", "A", "A", "A", "*", "B", "*", "A", "A" });

            System.Console.WriteLine(currentBalanceMessage);
            System.Console.WriteLine(depositMessage);
            System.Console.WriteLine(stakeMessage);
            System.Console.WriteLine(winningsMessage);
            System.Console.WriteLine(slotsAsString);
        }
    }
}
