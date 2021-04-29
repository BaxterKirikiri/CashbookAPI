using System;

namespace Dummy.API
{
    public class Expense
    {
        public int Id { get; set; }
        public decimal AmmountInclGst { get; set; }
        public string Details { get; set; }
        public ExpenseType Type { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
