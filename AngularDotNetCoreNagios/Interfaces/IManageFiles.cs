namespace AngularDotNetCoreNagios.Interfaces
{
    public  interface IManageFiles
    {
        bool CreateFile(object objectToMap);
        bool DeletFile(object objectToMap);
    }
}