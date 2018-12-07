using AngularDotNetCoreNagios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDotNetCoreNagios.Interfaces
{
    public interface IManageCommands
    {
        List<Command> GetCommands();
        Task AddCommand(Command command);
        Task RemoveCommand(string commmandName);
    }
}
