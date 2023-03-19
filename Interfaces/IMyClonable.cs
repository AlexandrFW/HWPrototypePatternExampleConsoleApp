namespace HWPrototypePatternExampleConsoleApp.Interfaces;

internal interface IMyClonable<T> where T : class
{
    public T ThisClone();
}