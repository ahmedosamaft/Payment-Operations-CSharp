namespace CSharp.Revision.Model
{
    public interface IPayment : IComparable
    {
        void Pay(decimal amount);
        void Withdraw(decimal amount);
        void Deposit(decimal amount);
    }
}
