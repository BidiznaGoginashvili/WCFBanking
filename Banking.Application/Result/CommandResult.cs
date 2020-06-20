using System.Runtime.Serialization;

namespace Banking.Application.Result
{
    [DataContract]
    public class CommandResult
    {
        [DataMember]
        public int EntityId { get; set; }
        [DataMember]
        public bool Success { get; set; }
        [DataMember]
        public string Message { get; set; }

        public CommandResult(bool success, string message = null, int entityId = 0)
        {
            Success = success;
            Message = message;
            EntityId = entityId;
        }
    }
}