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
using System.Threading.Tasks;

namespace AngularDotNetCoreNagios.Helpers
{
    public class FileManager : IManageFiles
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ILogger _logger;
        private readonly IHostingEnvironment _env;
        public FileManager(ApplicationDbContext applicationDbContext, IHostingEnvironment env, ILogger<FileManager> logger)
        {
            _applicationDbContext = applicationDbContext;
            _logger = logger;
            _env = env;
        }

        public bool CreateFile(object objectToMap)
        {
            try
            {
                string env = string.Empty;
                string baseFilePath = string.Empty;
                string objectFoler = string.Empty;
                string fullPath = string.Empty;
                string sRaw = string.Empty;

                // Check platform and env path.
                env = RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? Constants.AppSettings.LinuxFilePath.ToLower() : Constants.AppSettings.WindowsFilePath.ToLower();
                
                // get the setting base on env.
                List<Setting> settings = new List<Setting>();
                settings = _applicationDbContext.Settings.ToList();

                // get the base path.
                baseFilePath = settings.Where(c => c.Key.ToLower() == env).FirstOrDefault().Value;

                
                // build out the output path.
                if (objectToMap is Contact)
                {
                    Contact contact = objectToMap as Contact;
                    objectFoler = settings.Where(c => c.Key.ToLower() == Constants.AppSettings.ContactsFilePath.ToLower()).FirstOrDefault().Value;
                    fullPath = Path.Combine(baseFilePath, objectFoler, string.Format("{0}.cfg", contact.Name));
                    // read the template 
                    sRaw = File.ReadAllText(Path.Combine(_env.WebRootPath, "Templates/contactTemplate.cfg"));

                    // replace vars.
                    sRaw = sRaw.Replace("$NAME", contact.Name).Replace("$ALIAS", contact.Alias).Replace("$EMAIL", contact.EmailAddress);
                }
                else if (objectToMap is ContactGroup)
                {
                    ContactGroup contactGroup = objectToMap as ContactGroup;
                    objectFoler = settings.Where(c => c.Key.ToLower() == Constants.AppSettings.ContactGroupsFilePath.ToLower()).FirstOrDefault().Value;
                    fullPath = Path.Combine(baseFilePath, objectFoler, string.Format("{0}.cfg", contactGroup.GroupName));
                    // read the template 
                    sRaw = File.ReadAllText(Path.Combine(_env.WebRootPath, "Templates/contactGroupTemplate.cfg"));

                    // replace vars.
                    sRaw = sRaw.Replace("$GROUPNAME", contactGroup.GroupName).Replace("$ALIAS", contactGroup.Alias).Replace("$MEMBERS", contactGroup.Members);
                }
                else if (objectToMap is Host)
                {
                    Host host = objectToMap as Host;
                    objectFoler = settings.Where(c => c.Key.ToLower() == Constants.AppSettings.ServerFilePath.ToLower()).FirstOrDefault().Value;
                    fullPath = Path.Combine(baseFilePath, objectFoler, string.Format("{0}.cfg", host.HostName));
                    // read the template 
                    sRaw = File.ReadAllText(Path.Combine(_env.WebRootPath, "Templates/hostTemplate.cfg"));

                    // replace vars.
                    sRaw = sRaw.Replace("$HOST", host.HostName).Replace("$ALIAS", host.Alias).Replace("$IPADDRESS", host.IpAddress);
                }
                else if (objectToMap is HostGroup)
                {
                    HostGroup host = objectToMap as HostGroup;
                    objectFoler = settings.Where(c => c.Key.ToLower() == Constants.AppSettings.HostGroupsFilePath.ToLower()).FirstOrDefault().Value;
                    fullPath = Path.Combine(baseFilePath, objectFoler, string.Format("{0}.cfg", host.GroupName));
                    // read the template 
                    sRaw = File.ReadAllText(Path.Combine(_env.WebRootPath, "Templates/hostGroupTemplate.cfg"));

                    // replace vars.
                    sRaw = sRaw.Replace("$GROUPNAME", host.GroupName).Replace("$ALIAS", host.Alias).Replace("$MEMBERS", host.Members);
                }
                else
                {
                    // not any of our defined types, get out
                    return false;
                }

                // check if contact file exists, if it does delete it and recreate it.
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }

                //check if dir exists
                if (!Directory.Exists(Path.Combine(baseFilePath, objectFoler)))
                {
                    Directory.CreateDirectory(Path.Combine(baseFilePath, objectFoler));
                }
                // create file.
                using (StreamWriter file = new StreamWriter(File.Create(fullPath)))
                {
                    file.Write(sRaw);
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error:");
                return false;
            }
        }

        public bool DeletFile(object objectToMap)
        {
            throw new NotImplementedException();
        }
    }
}
