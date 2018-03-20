﻿using System.Collections.Generic;
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

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _initializeService.Initialize();
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
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