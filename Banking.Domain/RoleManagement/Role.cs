using Banking.Shared;
using System.Runtime.Serialization;
using Banking.Domain.UserManagement;

namespace Banking.Domain.RoleManagement
{
    [DataContract]
    public class Role : AggregateRoot
    {
        [DataMember]
        public string Name { get; set; }
        public Role(string name)
        {
            Name = name;
        }
    }
}
