using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDotNetCoreNagios.Models
{
    public class Host
    {
        public string HostName { get; set; }
        public string IpAddress { get; set; }
        public List<Command> Commands { get; set; }
    }
}
