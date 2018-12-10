using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularDotNetCoreNagios.Models
{
    public class ContactGroup
    {
        [Key]
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string Alias { get; set; }
        public string Members { get; set; }
    }
}