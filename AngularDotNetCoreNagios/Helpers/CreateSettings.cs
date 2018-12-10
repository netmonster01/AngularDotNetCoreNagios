using AngularDotNetCoreNagios.Data;
using AngularDotNetCoreNagios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDotNetCoreNagios.Helpers
{
    public static  class CreateSettings
    {
      


        public static void GenerateSettings(ApplicationDbContext applicationDbContext)
        {
            applicationDbContext.Database.EnsureCreated();
            if(applicationDbContext.Settings.Any())
            {
                return;
            }

            try
            {
                List<Setting> settings = new List<Setting>();

                settings.Add(new Setting { Key = Constants.AppSettings.WindowsFilePath.ToLower(), Value = @"C:\Users\NetDev\source\repos\AngularDotNetCoreNagios\AngularDotNetCoreNagios\Outputs" });
                settings.Add(new Setting { Key = Constants.AppSettings.LinuxFilePath.ToLower(), Value = "/etc/local/nagios/etc" });
                settings.Add(new Setting { Key = Constants.AppSettings.ServerFilePath.ToLower(), Value = "servers" });
                settings.Add(new Setting { Key = Constants.AppSettings.ContactsFilePath.ToLower(), Value = "contacts" });
                settings.Add(new Setting { Key = Constants.AppSettings.ContactGroupsFilePath.ToLower(), Value = "contact_groups" });
                settings.Add(new Setting { Key = Constants.AppSettings.HostGroupsFilePath.ToLower(), Value = "host_groups" });
                settings.Add(new Setting { Key = Constants.AppSettings.ServiceGroupsFilePath.ToLower(), Value = "service_groups" });

                applicationDbContext.Settings.AddRange(settings);
                applicationDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
