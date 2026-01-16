namespace CleanArchitecture.Domain.Abstractions;

public class Result
{
    protected internal Result(bool isSucces, Error error)
    {
        if (isSucces && error != Error.None)
        {
            throw new InvalidOperationException();
        }

        if (!isSucces && error == Error.None)
        {
            throw new InvalidOperationException();
        }
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }
    public static Result Success() => new(true, Error.None);
    public static Result Failure(Error error) => new(false, error);
}