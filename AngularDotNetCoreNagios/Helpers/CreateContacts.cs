using AngularDotNetCoreNagios.Data;
using AngularDotNetCoreNagios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDotNetCoreNagios.Helpers
{
    public static class CreateContacts
    {

        public static void GenerateContacts(ApplicationDbContext applicationDbContext)
        {
            if(applicationDbContext.Contacts.Any())
            {
                return;
            }

            List<Contact> contacts = new List<Contact>
            {
                new Contact{ Alias ="Windows Admin", Name="postmaster", CreatedDate= DateTime.Now, EmailAddress ="postmaster@cavitt.net"},
                new Contact{ Alias ="Kris Cavitt", Name="kris_cavitt", CreatedDate= DateTime.Now, EmailAddress ="postmaster@cavitt.net"},
            };

            try
            {
                applicationDbContext.AddRange(contacts);
                applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
