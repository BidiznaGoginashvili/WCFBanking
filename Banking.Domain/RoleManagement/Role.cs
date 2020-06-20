using Banking.Shared;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Banking.Domain.UserManagement;

namespace Banking.Domain.RoleManagement
{
    [DataContract]
    public class Role : AggregateRoot
    {
        //To Refactor
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public ICollection<User> Users{ get; set; }

        public Role()
        {
            Users = new List<User>();
        }
    }
}
