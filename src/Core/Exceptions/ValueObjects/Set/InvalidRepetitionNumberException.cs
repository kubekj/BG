namespace Core.Exceptions.ValueObjects.Set;

public class InvalidRepetitionNumberException : CoreException
{
    public InvalidRepetitionNumberException(int value, int minRepetition, int maxRepetition) : base(
        $"Repetitions should be in range from {minRepetition} to {maxRepetition} but is {value}")
    {
        Repetition = value;
    }

    public int Repetition { get; }
}