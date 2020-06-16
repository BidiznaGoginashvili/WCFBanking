using System.Runtime.Serialization;

namespace Banking.Application.Query.UserQueries
{
    [DataContract]
    public class UserDetailsQuery
    {
        [DataMember]
        public int Id { get; set; }
    }
}