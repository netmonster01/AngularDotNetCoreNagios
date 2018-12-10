using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularDotNetCoreNagios.Data;
using AngularDotNetCoreNagios.Models;
using Microsoft.Extensions.Logging;
using AngularDotNetCoreNagios.Interfaces;

namespace AngularDotNetCoreNagios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        private readonly IManageFiles _manageFiles;
        public HostsController(ApplicationDbContext context, ILogger<HostsController> logger, IManageFiles manageFiles)
        {
            _context = context;
            _logger = logger;
            _manageFiles = manageFiles;
        }


        // GET: api/Hosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Host>>> GetHosts()
        {
            return await _context.Hosts.ToListAsync();
        }

        // GET: api/Hosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Host>> GetHost(int id)
        {
            var host = await _context.Hosts.FindAsync(id);

            if (host == null)
            {
                return NotFound();
            }

            return host;
        }

        // PUT: api/Hosts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHost(int id, Host host)
        {
            if (id != host.Id)
            {
                return BadRequest();
            }

            _context.Entry(host).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Hosts
        [HttpPost]
        public async Task<ActionResult<Host>> PostHost(Host host)
        {
            try
            {
                var didAdd = _manageFiles.CreateFile(host);

                if (didAdd)
                {
                    _context.Hosts.Add(host);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return CreatedAtAction("GetHost", new { id = host.Id }, host);
        }

        // DELETE: api/Hosts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Host>> DeleteHost(int id)
        {
            var host = await _context.Hosts.FindAsync(id);
            if (host == null)
            {
                return NotFound();
            }

            _context.Hosts.Remove(host);
            await _context.SaveChangesAsync();

            return host;
        }

        private bool HostExists(int id)
        {
            return _context.Hosts.Any(e => e.Id == id);
        }
    }
}
