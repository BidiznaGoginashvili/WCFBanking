using System.Runtime.Serialization;

namespace Banking.Application.Command.UserCommands
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