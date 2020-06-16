using System.Runtime.Serialization;

namespace Banking.Application.Command.UserCommands
{
    [DataContract]
    public class DeleteUserCommand
    {
        [DataMember]
        public int Id { get; set; }
    }
}