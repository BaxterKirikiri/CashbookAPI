using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Dummy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpGet]
        public List<Expense> GetAll()
        {
            return Data.Expenses;
        }

        [HttpGet("{id}")]
        public Expense GetOne(int id)
        {
            return Data.Expenses.Single(x => x.Id == id);
        }

        [HttpPost]
        public void Create([FromBody] Expense transaction) 
        {
            int highestId = FindHighestId();
            transaction.Id = highestId + 1;
            Data.Expenses.Add(transaction);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            Data.Expenses = Data.Expenses.Where(x => x.Id != id).ToList();
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] Expense transaction)
        {
            Expense t = Data.Expenses.Single(x => x.Id == id);
            t.AmmountInclGst = transaction.AmmountInclGst;
        }

        private int FindHighestId()
        {
            int highest = 0;
            foreach (Expense t in Data.Expenses)
            {
                if(t.Id > highest)
                {
                    highest = t.Id;
                }
            }
            return highest;
        }
    }
}
