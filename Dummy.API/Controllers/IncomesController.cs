using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Dummy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomesController : ControllerBase
    {
        [HttpGet]
        public List<Income> GetAll()
        {
            return Data.Incomes;
        }

        [HttpGet("{id}")]
        public Income GetOne(int id)
        {
            return Data.Incomes.Single(x => x.Id == id);
        }

        [HttpPost]
        public void Create([FromBody] Income transaction) 
        {
            transaction.Id = Data.Incomes.Max(x => x.Id) + 1;
            Data.Incomes.Add(transaction);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            Data.Incomes = Data.Incomes.Where(x => x.Id != id).ToList();
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] Income transaction)
        {
            Income t = Data.Incomes.Single(x => x.Id == id);
            t.HourlyRate = transaction.HourlyRate;
            t.NumberOfHours = transaction.NumberOfHours;
        }
    }
}
