using System.Runtime.Serialization;

namespace BankingSystemService.Query.UserQueries
{
    [DataContract]
    public class UserDetailsQuery
    {
        [DataMember]
        public int Id { get; set; }
    }
}