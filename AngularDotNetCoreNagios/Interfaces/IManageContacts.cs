using AngularDotNetCoreNagios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDotNetCoreNagios.Interfaces
{
    public interface IManageContacts
    {
        bool AddNewContact(Contact contact);
        Contact UpdateNewContact(Contact contact);
        bool DeleteContact(Contact contact);
    }
}
