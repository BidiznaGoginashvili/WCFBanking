using System.Runtime.Serialization;

namespace BankingSystemService.Command.UserCommands
{
    [DataContract]
    public class DeleteUserCommand
    {
        [DataMember]
        public int Id { get; set; }
    }
}