using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dummy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YearsController : ControllerBase
    {
        private bool IsTaxYear(DateTime date, int year)
        {
            var startDate = new DateTime(year - 1, 4, 1);
            var endDate = new DateTime(year, 3, 31);
            return date >= startDate && date <= endDate;
        }

        [HttpGet("{year}/incomes")]
        public List<Income> GetIncomeByYear(int year)
        {
            return Data.Incomes.Where(x => IsTaxYear(x.InvoiceDate, year)).ToList();
        }

        [HttpGet("{year}/expenses")]
        public List<Expense> GetExpensesByYear(int year)
        {
            return Data.Expenses.Where(x => IsTaxYear(x.InvoiceDate, year)).ToList();
        }
    }
}
