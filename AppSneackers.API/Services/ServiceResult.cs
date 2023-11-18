using FluentValidation.Results;

namespace AppSneackers.API.Services
{
    public class ServiceResult
    {
        public string ErrorMessage { get; private set; }
        public Type? ExceptionType { get; private set; }
        public object? Data { get; private set; }

        public ServiceResult()
        {
            
        }

        public ServiceResult(Exception ex)
        {
            ErrorMessage = ex.Message;
            ExceptionType = ex.GetType();
            Data = ex.Data;
        }

        public ServiceResult(object data)
        {
            ErrorMessage = "";
            ExceptionType = null;
            Data = data;
        }

        public ServiceResult(IList<ValidationFailure> errors)
        {
            ErrorMessage = "Entity validation errors encountered";
            ExceptionType = new InvalidDataException().GetType();
            Data = errors;
        }
    }
}
