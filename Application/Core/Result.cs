namespace Application.Core;

public class Result<T>
{
  private Result() { }

  public bool IsSuccess { get; private set; }
  public T Value { get; private set; }
  public string Error { get; private set; }

  public static Result<T> Success(T value) => new Result<T> { IsSuccess = true, Value = value };

  public static Result<T> Failure(string error) =>
    new Result<T> { IsSuccess = false, Error = error };
}
