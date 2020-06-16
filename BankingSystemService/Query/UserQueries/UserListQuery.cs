using System.Runtime.Serialization;

namespace BankingSystemService.Query.UserQueries
{
    [DataContract]
    public class UserListQuery
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string Email { get; set; }
    }
}