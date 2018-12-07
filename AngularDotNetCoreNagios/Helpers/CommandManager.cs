using AngularDotNetCoreNagios.Interfaces;
using AngularDotNetCoreNagios.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AngularDotNetCoreNagios.Helpers
{
    public class CommandManager : IManageCommands
    {
        private IHostingEnvironment _env;

        public CommandManager(IHostingEnvironment env)
        {
            _env = env;
        }

        public Task AddCommand(Command command)
        {
            throw new NotImplementedException();
        }

        public List<Command> GetCommands()
        {
            List<Command> commands = new List<Command>();
            string sRaw = File.ReadAllText(Path.Combine(_env.WebRootPath, "Templates/commands.cfg")).Replace("\n\n    ", "").Replace("\n","");

            string[] commandList = sRaw.Split("define command {", StringSplitOptions.RemoveEmptyEntries);

            // remove the first item is its just information
            commandList = commandList.Skip(1).ToArray();
            commandList = commandList.Take(commandList.Count() - 1).ToArray();
            foreach (var command in commandList)
            {
                string[] commandsArray = command.Split("    ");
                commands.Add(new Command { Command_Name = commandsArray[1]});
            }

            return commands;
        }

        public Task RemoveCommand(string commmandName)
        {
            throw new NotImplementedException();
        }
    }
}
