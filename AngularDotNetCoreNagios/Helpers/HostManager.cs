using AngularDotNetCoreNagios.Models;
using AngularDotNetCoreNagios.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;

namespace AngularDotNetCoreNagios.Helpers
{
    public class HostManager : IManageHosts
    {
        private IHostingEnvironment _env;

        public HostManager(IHostingEnvironment env)
        {
            _env = env;
        }

        public void AddServer(Host host)
        {
            string outPutDir = _env.WebRootPath;
            // Load and replace host and ipaddress
            string sRaw = File.ReadAllText(Path.Combine(_env.WebRootPath, "Templates/serverTemplate.cfg"));
            string sModifiedConfig = sRaw.Replace("$HOST", host.HostName).Replace("$IPADDRESS", host.IpAddress);

            // Save file to output location
            using (StreamWriter writer = File.AppendText(Path.Combine(outPutDir, string.Format("{0}.cfg", host.HostName))))
            {
                writer.Write(sModifiedConfig);
            }
        }

        public void RemoveServer(Host host)
        {
            throw new NotImplementedException();
        }
    }
}
