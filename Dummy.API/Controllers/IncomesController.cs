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
            int highestId = FindHighestId();
            transaction.Id = highestId + 1;
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

        private int FindHighestId()
        {
            int highest = 0;
            foreach (Income t in Data.Incomes)
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
