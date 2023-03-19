using HWPrototypePatternExampleConsoleApp.Interfaces;

namespace HWPrototypePatternExampleConsoleApp.Model;

public class Person : IMyClonable<Person>, ICloneable
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public Person()
    {
        
    }

    private Person(string FirstName, string LastName)
    {
        this.FirstName = FirstName;
        this.LastName = LastName;
    }

    public Person ThisClone()
    {
        return new Person(FirstName, LastName);
    }

    public object Clone()
    {
        return ThisClone();
    }
}