using Banking.Shared;
using System.Runtime.Serialization;

namespace Banking.Domain.LoanManagement
{
    [DataContract]
    public class Guarantor : AggregateRoot
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Phone { get; set; }
        //to enum
        [DataMember]
        public string Relationship { get; set; }

        public Guarantor()
        {

        }

        public Guarantor(string firstName, string lastName, string phone, string relationship)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Relationship = relationship;
        }
    }
}
