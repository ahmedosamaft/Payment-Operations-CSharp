using CSharp.Revision.AppError;
using CSharp.Revision.Model;

namespace CSharp.Revision
{
    internal class Program
    {


        private static void SubscribeEvent ( )
        {
            Card.Event += (Operation op) =>
            {
                if (op == Operation.pay)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Paying Operation!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                } else if (op == Operation.withdraw)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Withdrawing Operation!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                } else if (op == Operation.deposit)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Depositing Operation!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            };
        }

        private static void Main (string[] args)
        {
            SubscribeEvent();

            MyWallets myWallets = [new Visa("Ahmed Osama", 10m),
                new Mastercard("Ahmed Osama", 50.5m),
                new Visa("Mohamed Tamer", 30.78m),
                new Visa("Mohamed Abdelhady", 73.80m)];

            foreach (var wallet in myWallets)
                Console.WriteLine(wallet);
            Console.WriteLine("================================");

            myWallets.Sort();
            foreach (var wallet in myWallets)
                Console.WriteLine(wallet);

            Console.WriteLine("================================");
            NotSufficientBalance.Wrapper(( ) => myWallets[0].Deposit(500));
            NotSufficientBalance.Wrapper(( ) => myWallets[2].Withdraw(10));
            NotSufficientBalance.Wrapper(( ) => myWallets[1].Pay(30));
            Console.WriteLine("================================");

            myWallets.Sort();
            foreach (var wallet in myWallets)
            {
                Console.WriteLine(wallet);
            }
        }
    }

}
