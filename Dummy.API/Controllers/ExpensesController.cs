using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dummy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private static List<Expense> Expenses = new List<Expense> { };

        [HttpGet]
        public List<Expense> GetAll()
        {
            return Expenses;
        }

        [HttpGet("{id}")]
        public Expense GetOne(int id)
        {
            return Expenses.Single(x => x.Id == id);
        }

        [HttpPost]
        public void Create([FromBody] Expense transaction) 
        {
            int highestId = FindHighestId();
            transaction.Id = highestId + 1;
            Expenses.Add(transaction);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            Expenses = Expenses.Where(x => x.Id != id).ToList();
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] Expense transaction)
        {
            Expense t = Expenses.Single(x => x.Id == id);
            t.AmmountInclGst = transaction.AmmountInclGst;
        }

        private int FindHighestId()
        {
            int highest = 0;
            foreach (Expense t in Expenses)
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
