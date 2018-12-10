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
    public class ContactGroupsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        private readonly IManageFiles _manageFiles;
        public ContactGroupsController(ApplicationDbContext context, ILogger<ContactGroupsController> logger, IManageFiles manageFiles)
        {
            _context = context;
            _manageFiles = manageFiles;
            _logger = logger;
        }

        // GET: api/ContactGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactGroup>>> GetContactGroups()
        {
            return await _context.ContactGroups.ToListAsync();
        }

        // GET: api/ContactGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactGroup>> GetContactGroup(int id)
        {
            var contactGroup = await _context.ContactGroups.FindAsync(id);

            if (contactGroup == null)
            {
                return NotFound();
            }

            return contactGroup;
        }

        // PUT: api/ContactGroups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactGroup(int id, ContactGroup contactGroup)
        {
            if (id != contactGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(contactGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactGroupExists(id))
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

        // POST: api/ContactGroups
        [HttpPost]
        public async Task<ActionResult<ContactGroup>> PostContactGroup(ContactGroup contactGroup)
        {
            try
            {
                var didAdd = _manageFiles.CreateFile(contactGroup);

                if (didAdd)
                {
                    _context.ContactGroups.Add(contactGroup);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
            }

            return CreatedAtAction("GetContactGroup", new { id = contactGroup.Id }, contactGroup);
        }

        // DELETE: api/ContactGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContactGroup>> DeleteContactGroup(int id)
        {
            var contactGroup = await _context.ContactGroups.FindAsync(id);
            if (contactGroup == null)
            {
                return NotFound();
            }

            _context.ContactGroups.Remove(contactGroup);
            await _context.SaveChangesAsync();

            return contactGroup;
        }

        private bool ContactGroupExists(int id)
        {
            return _context.ContactGroups.Any(e => e.Id == id);
        }
    }
}
