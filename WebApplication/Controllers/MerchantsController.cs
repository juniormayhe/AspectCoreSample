using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Shared;
using Application.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace InterceptionByAttribute.WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantsController : ControllerBase
    {
        private readonly IRepository repository;

        public MerchantsController(IRepository repository)
        {
            this.repository = repository;
        }

        // GET api/values
        [HttpGet("tenant/{tenantId}")]
        public ActionResult<IEnumerable<Merchant>> GetByTenant(int tenantId)
        {
            var list = repository.GetMerchants(tenantId) ?? new List<Merchant>();
            
            return list.ToList();
        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
