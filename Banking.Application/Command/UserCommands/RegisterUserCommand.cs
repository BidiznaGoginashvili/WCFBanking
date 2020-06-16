using System;
using System.Runtime.Serialization;

namespace Banking.Application.Command.UserCommands
{
    [DataContract]
    public class RegisterUserCommand
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public byte Gender { get; set; }
        [DataMember]
        public string UniqueNumber { get; set; }
        [DataMember]
        public DateTime BirthDay { get; private set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public int BranchId { get; set; }
        [DataMember]
        public int CountryId { get; set; }
        [DataMember]
        public int CityId { get; set; }
    }
}