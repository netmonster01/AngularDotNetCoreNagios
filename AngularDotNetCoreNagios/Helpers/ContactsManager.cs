using AngularDotNetCoreNagios.Data;
using AngularDotNetCoreNagios.Interfaces;
using AngularDotNetCoreNagios.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace AngularDotNetCoreNagios.Helpers
{
    public class ContactsManager : IManageContacts
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IHostingEnvironment _env;
        private readonly ILogger _logger;
        private readonly IManageFiles _manageFiles;

        public ContactsManager(ApplicationDbContext applicationDbContext, IHostingEnvironment env, ILogger<ContactsManager> logger, IManageFiles manageFiles)
        {
            _applicationDbContext = applicationDbContext;
            _env = env;
            _logger = logger;
            _manageFiles = manageFiles;
        }

        public bool AddNewContact(Contact contact)
        {
            try
            {
             
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error:");
                return false;
            }
        }

        public bool DeleteContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Contact UpdateNewContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
