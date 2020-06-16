using System.Runtime.Serialization;

namespace BankingSystemService.Command.UserCommands
{
    [DataContract]
    public class LoginUserCommand
    {
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}