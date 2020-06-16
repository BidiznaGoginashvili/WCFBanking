using Banking.Shared;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Banking.Domain.UserManagement;

namespace Banking.Domain.BranchManagement
{
    [DataContract]
    public class Branch : AggregateRoot
    {
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }

        public Branch(string name)
        {
            Name = name;
        }
    }
}
