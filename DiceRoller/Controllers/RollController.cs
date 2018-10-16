using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiceRoller.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiceRoller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RollController : ControllerBase
    {
        // GET: api/Roll
        [HttpGet("{input}")]
        public string Get(string input)
        {
            var rollSets = RollUtil.ProcessInput(input);
            var result = RollUtil.ExecuteResults(rollSets);
            return result;
        }
    }
}
