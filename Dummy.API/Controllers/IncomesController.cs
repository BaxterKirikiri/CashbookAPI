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
    public class IncomesController : ControllerBase
    {
        private static List<Income> Incomes = new List<Income> { };

        [HttpGet]
        public List<Income> GetAll()
        {
            return Incomes;
        }

        [HttpGet("{id}")]
        public Income GetOne(int id)
        {
            return Incomes.Single(x => x.Id == id);
        }

        [HttpPost]
        public void Create([FromBody] Income transaction) 
        {
            int highestId = FindHighestId();
            transaction.Id = highestId + 1;
            Incomes.Add(transaction);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            Incomes = Incomes.Where(x => x.Id != id).ToList();
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] Income transaction)
        {
            Income t = Incomes.Single(x => x.Id == id);
            t.HourlyRate = transaction.HourlyRate;
            t.NumberOfHours = transaction.NumberOfHours;
        }

        private int FindHighestId()
        {
            int highest = 0;
            foreach (Income t in Incomes)
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
