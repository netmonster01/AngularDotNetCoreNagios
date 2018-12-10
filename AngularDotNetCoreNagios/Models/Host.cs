using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDotNetCoreNagios.Models
{
    public class Host
    {
        [Key]
        public int Id { get; set; }
        public string Alias { get; set; }
        public string HostName { get; set; }
        public string IpAddress { get; set; }
    }
}
