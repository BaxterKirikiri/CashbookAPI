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
    public class TransactionsController : ControllerBase
    {
        private static List<Transaction> Transactions = new List<Transaction> { new Transaction(1, 200), new Transaction(2, 400) };

        [HttpGet]
        public List<Transaction> GetAll()
        {
            return Transactions;
        }

        [HttpGet("{id}")]
        public Transaction GetOne(int id)
        {
            return Transactions.Single(x => x.Id == id);
        }

        [HttpPost]
        public void Create([FromBody] Transaction transaction)
        {
            Transactions.Add(transaction);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            Transactions = Transactions.Where(x => x.Id != id).ToList();
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] Transaction transaction)
        {
            Transaction t = Transactions.Single(x => x.Id == id);
            t.Sum = transaction.Sum;
        }
    }
}
