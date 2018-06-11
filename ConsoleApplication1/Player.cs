namespace ConsoleApplication1
{
    public class Player
    {
        public decimal Balance { get; set; }

        public void Deposit(decimal amount) => this.Balance = amount;

        public void Stake(decimal amount) => this.Balance -= amount;

        public void Win(decimal amount) => this.Balance += amount;
    }
}
