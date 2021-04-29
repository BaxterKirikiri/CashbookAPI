using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dummy.API
{
    public class Income
    {
        public int Id { get; set; }
        public decimal AmmountInlcGst { get { return HourlyRate * NumberOfHours; } }
        public string Details { get; set; }
        public DateTime InvoiceDate { get; set; }

        public DateTime PaymentDate { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal NumberOfHours { get; set; }
    }
}
