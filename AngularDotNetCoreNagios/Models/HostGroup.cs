using System.ComponentModel.DataAnnotations;

namespace AngularDotNetCoreNagios.Models
{
    public class HostGroup
    {
        [Key]
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string Alias { get; set; }
        public string Members { get; set; }
    }
}