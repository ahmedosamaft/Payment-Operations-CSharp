using System.Collections;

namespace CSharp.Revision.Model
{
    public class MyWallets : IEnumerable
    {
        private readonly List<IPayment> _list;

        public MyWallets()
        {
            _list = [];
        }
        public List<IPayment> Wallets => _list;

        public void Add(IPayment wallet) { _list.Add(wallet); }

        public IEnumerator GetEnumerator()
        {
            foreach (IPayment wallet in _list)
            {
                yield return wallet;
            }
        }

        public void Sort()
        {
            _list.Sort();
        }

        public IPayment this[int index]
        {
            get { return _list[index]; }
            set { _list[index] = value; }
        }



    }
}
