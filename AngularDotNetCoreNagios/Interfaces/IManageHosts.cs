using AngularDotNetCoreNagios.Models;

namespace AngularDotNetCoreNagios.Interfaces
{
    public interface IManageHosts
    {
        void AddServer(Host host);
        void RemoveServer(Host host);
    }
}