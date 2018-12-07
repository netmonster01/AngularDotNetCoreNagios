using System.Collections.Generic;
using AngularDotNetCoreNagios.Interfaces;
using AngularDotNetCoreNagios.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularDotNetCoreNagios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private IManageCommands _manageCommands;
        public CommandsController(IManageCommands manageCommands)
        {
            _manageCommands = manageCommands;
        }

        // GET: api/Commands
        [HttpGet]
        public IEnumerable<Command> Get()
        {
           return _manageCommands.GetCommands();
        }

        // GET: api/Commands/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Commands
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Commands/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
