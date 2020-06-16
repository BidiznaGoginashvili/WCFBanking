using System.Runtime.Serialization;

namespace Banking.Application.Result
{
    [DataContract]
    public class CommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public CommandResult(bool success, string message = null)
        {
            Success = success;
            Message = message;
        }
    }
}