namespace Core.Exceptions.ValueObjects.User;

public class InvalidLastNameException : CoreException
{
    public InvalidLastNameException() : base("Last name should contain value !")
    {
    }
}