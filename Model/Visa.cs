namespace CSharp.Revision.Model
{
    class Visa(string holder, decimal amount) : Card(holder, amount)
    {
        public override void Pay(decimal amount)
        {
            base.Pay(amount);
            Console.WriteLine("Paying {0:C2} from Visa", amount);
            Balance -= amount;
        }
        public override void Withdraw(decimal amount)
        {

            base.Withdraw(amount);
            Balance -= amount;
            Console.WriteLine("Withdrawing {0:C2} from Visa", amount);
        }

        public override void Deposit(decimal amount)
        {
            base.Deposit(amount);
            Console.WriteLine("Deposit {0:C2} is Done to your Visa", amount);
            Balance += amount;
        }

        public override string ToString()
        {
            return $"Type: Visa - Holder: {Holder} - Balance: {Balance:C2}";
        }
    }

}
