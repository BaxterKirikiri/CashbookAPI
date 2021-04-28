using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dummy.API
{
    public class Transaction
    {
        public Transaction(int id, int sum, string transactiontype)
        {
            Id = id;
            Sum = sum;
            TransactionType = transactiontype;
        }
        public int Id { get; set; }
        public int Sum { get; set; }
        public string TransactionType { get; set; }
    }
}
