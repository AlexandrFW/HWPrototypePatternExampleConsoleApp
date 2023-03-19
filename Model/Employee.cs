using HWPrototypePatternExampleConsoleApp.Interfaces;

namespace HWPrototypePatternExampleConsoleApp.Model;

public class Employee : Person, IMyClonable<Employee>, ICloneable
{
    public string EmailAddress { get; set; } = string.Empty;

    public Employee()
    {
        
    }

    private Employee(Employee employee)
    {
        FirstName = employee.FirstName;
        LastName = employee.LastName;
        EmailAddress = employee.EmailAddress;
    }

    public new Employee ThisClone()
    {
        return new Employee(this);
    }

    public new object Clone()
    {
        return ThisClone();
    }
}