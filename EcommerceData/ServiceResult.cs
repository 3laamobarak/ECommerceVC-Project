namespace EcommercModels;

public class ServiceResult
{ 
    public bool Success { get; set; } 
    public string Message { get; set; }
    public static ServiceResult SuccessResult() => new ServiceResult { Success = true, Message = "Operation successful." };
    public static ServiceResult FailureResult(string message) => new ServiceResult { Success = false, Message = message };
}