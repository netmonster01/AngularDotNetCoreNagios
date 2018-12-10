using AngularDotNetCoreNagios.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularDotNetCoreNagios.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
      
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Host> Hosts { get; set; }
        public DbSet<HostGroup> HostGroups { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<ContactGroup> ContactGroups { get; set; }
    }
}
