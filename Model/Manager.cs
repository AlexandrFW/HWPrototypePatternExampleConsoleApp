using HWPrototypePatternExampleConsoleApp.Interfaces;

namespace HWPrototypePatternExampleConsoleApp.Model;

internal class Manager : Employee, IMyClonable<Manager>, ICloneable
{
    public string ManagerType { get; set; } = string.Empty;

    public Manager()
    {
        
    }

    private Manager(Manager manager)
    {
        FirstName = manager.FirstName;
        LastName = manager.LastName;
        EmailAddress = manager.EmailAddress;
        ManagerType = manager.ManagerType;
    }

    public new Manager ThisClone()
    {
        return new Manager(this);
    }

    public new object Clone()
    {
        return ThisClone();
    }
}