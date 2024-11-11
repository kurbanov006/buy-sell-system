public class Result<T>
{
    public bool IsSuccess { get; set; }
    public Error Error { get; set; }
    public T? Value { get; init; }

    protected Result(bool isSuccess, Error error, T? value)
    {
        IsSuccess = isSuccess;
        Value = value;
        Error = error;
    }

    public static Result<T> Success(T? value) => new(true, Error.None(), value);

    public static Result<T> Failure(Error error) => new(false, error, default);
}