namespace DailyTaskManager.Domain.Common;

public class ServiceResult<T>
{
  public bool Succeeded { get; set; }
  public T? Value { get; set; }
  public string? Error { get; set; }

  public static ServiceResult<T> Success(T value)
  {
    return new ServiceResult<T>
    {
      Succeeded = true,
      Value = value
    };
  }

  public static ServiceResult<T> Failure(string error)
  {
    return new ServiceResult<T>
    {
      Succeeded = false,
      Error = error
    };
  }
}