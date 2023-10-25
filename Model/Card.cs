using CSharp.Revision.AppError;

namespace CSharp.Revision.Model
{
    abstract class Card(string holder, decimal amount) : IPayment
    {
        public delegate void EventEmitter(Operation op);
        public static event EventEmitter Event;
        public string Holder { get; set; } = holder;
        public decimal Balance { get; set; } = amount;

        public virtual void Deposit(decimal amount)
        {
            Event?.Invoke(Operation.deposit);
        }

        public virtual void Pay(decimal amount)
        {
            if (Balance < amount)
                throw new NotSufficientBalance("Your Balance isn't sufficient", this);
            Event?.Invoke(Operation.pay);
        }

        public virtual void Withdraw(decimal amount)
        {
            if (Balance < amount)
                throw new NotSufficientBalance("Your Balance isn't sufficient", this);
            Event?.Invoke(Operation.withdraw);
        }


        public int CompareTo(object? obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
            Card payment = obj as Card ?? throw new ArgumentException("Object must be of Card type!");
            return Balance.CompareTo(payment.Balance);
        }

    }

}
