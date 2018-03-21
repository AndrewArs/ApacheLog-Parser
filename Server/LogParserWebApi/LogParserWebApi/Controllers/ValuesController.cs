using LogParserWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LogParserWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IInitializeService _initializeService;

        public ValuesController(IInitializeService initializeService)
        {
            _initializeService = initializeService;
        }

        [HttpGet]
        public IActionResult Initialize()
        {
            return Ok(_initializeService.Initialize());
        }
        
        [HttpPost]
        public void Post([FromBody]string log)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
