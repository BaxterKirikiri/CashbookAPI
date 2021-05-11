using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Dummy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YearsController : ControllerBase
    {
        [HttpGet("{year}/incomes")]
        public List<Income> GetIncomeByYear(int year)
        {
            return Data.Incomes.Where(x => BusinessRules.IsTaxYear(x.InvoiceDate, year)).ToList();
        }

        [HttpGet("{year}/expenses")]
        public List<Expense> GetExpensesByYear(int year)
        {
            return Data.Expenses.Where(x => BusinessRules.IsTaxYear(x.InvoiceDate, year)).ToList();
        }
    }
}
