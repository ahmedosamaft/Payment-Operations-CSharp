using CSharp.Revision.Model;

namespace CSharp.Revision.AppError
{
    class NotSufficientBalance(string message, Card payment) : Exception(message)
    {
        public Card Payment { get; set; } = payment;
        static public void Wrapper (Action op)
        {
            try
            {
                op();
            }
            catch (NotSufficientBalance e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

    }

}
