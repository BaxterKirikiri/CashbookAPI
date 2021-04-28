using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dummy.API
{
    public class Transaction
    {
        public Transaction(int id, int sum)
        {
            Id = id;
            Sum = sum;
        }
        public int Id { get; set; }
        public int Sum { get; set; }
    }
}
