using System;

namespace Dummy.API
{
    public static class BusinessRules
    {
        public static bool IsTaxYear(DateTime date, int year)
        {
            var startDate = new DateTime(year - 1, 4, 1);
            var endDate = new DateTime(year, 3, 31);
            return date >= startDate && date <= endDate;
        }

        public static decimal CalculateGst(decimal ammountInclGst)
        {
            return (ammountInclGst * 3)/23;
        }
    }
}
