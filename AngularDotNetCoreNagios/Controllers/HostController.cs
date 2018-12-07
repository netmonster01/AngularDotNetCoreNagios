using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularDotNetCoreNagios.Interfaces;
using AngularDotNetCoreNagios.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularDotNetCoreNagios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostController : ControllerBase
    {
        private IManageHosts _hostManager;
        public HostController(IManageHosts hostManager)
        {
            _hostManager = hostManager;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{hostName}")]
        public void Delete(string hostName)
        {
        }

        [HttpPost]
        [Route("AddServer")]
        public void AddServer([FromBody] Host host)
        {
            _hostManager.AddServer(host);
        }
    }
}
