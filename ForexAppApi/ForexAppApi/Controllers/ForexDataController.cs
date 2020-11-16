﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ForexAppApi.Services;
using ForexAppApi.Model;
using System.Text.Json;


namespace ForexAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForexDataController : ControllerBase
    {
        private readonly IForexDataService _forexDataService;

        public ForexDataController(IForexDataService forexDataService)
        {
            _forexDataService = forexDataService;
        }


        [HttpGet]
        public IEnumerable<ForexDetail> Get()
        {
            return _forexDataService.FindAll();
        }


        // url: api/ForexData/forexDetail
        [HttpPost("forexDetail")]
        public void Post([FromBody] string forexDetailStr)
        {
            var forexDetail = JsonSerializer.Deserialize<ForexDetail>(forexDetailStr);
            _forexDataService.Add(forexDetail);

        }
    }
}
