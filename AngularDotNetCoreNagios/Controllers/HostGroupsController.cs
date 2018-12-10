using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class HostGroupsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        private readonly IManageFiles _manageFiles;

        public HostGroupsController(ApplicationDbContext context, ILogger<HostGroupsController> logger, IManageFiles manageFiles)
        {
            _context = context;
            _manageFiles = manageFiles;
            _logger = logger;
        }

        // GET: api/HostGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HostGroup>>> GetHostGroups()
        {
            return await _context.HostGroups.ToListAsync();
        }

        // GET: api/HostGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HostGroup>> GetHostGroup(int id)
        {
            var hostGroup = await _context.HostGroups.FindAsync(id);

            if (hostGroup == null)
            {
                return NotFound();
            }

            return hostGroup;
        }

        // PUT: api/HostGroups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHostGroup(int id, HostGroup hostGroup)
        {
            if (id != hostGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(hostGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HostGroupExists(id))
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

        // POST: api/HostGroups
        [HttpPost]
        public async Task<ActionResult<HostGroup>> PostHostGroup(HostGroup hostGroup)
        {
            try
            {
                var didAdd = _manageFiles.CreateFile(hostGroup);

                if (didAdd)
                {
                    _context.HostGroups.Add(hostGroup);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error:");
                throw;
            }

            return CreatedAtAction("GetHostGroup", new { id = hostGroup.Id }, hostGroup);
        }

        // DELETE: api/HostGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HostGroup>> DeleteHostGroup(int id)
        {
            var hostGroup = await _context.HostGroups.FindAsync(id);
            if (hostGroup == null)
            {
                return NotFound();
            }

            _context.HostGroups.Remove(hostGroup);
            await _context.SaveChangesAsync();

            return hostGroup;
        }

        private bool HostGroupExists(int id)
        {
            return _context.HostGroups.Any(e => e.Id == id);
        }
    }
}
