using System;
using Banking.Shared;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Banking.Domain.LoanManagement;
using Banking.Domain.RoleManagement;
using Banking.Domain.CityManagement;
using Banking.Domain.BranchManagement;
using Banking.Domain.DepositManagement;
using Banking.Domain.CountryManagement;
using System.ComponentModel.DataAnnotations;

namespace Banking.Domain.UserManagement
{
    [DataContract]
    public class User : AggregateRoot
    {
        [DataMember]
        [MinLength(2)]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [DataMember]
        [MinLength(2)]
        [MaxLength(50)]
        public string LastName { get; set; }
        [DataMember]
        public byte Gender { get; set; }
        [DataMember]
        [Required]
        [MinLength(11)]
        [MaxLength(11)]
        public string UniqueNumber { get; set; }
        [DataMember]
        public DateTime BirthDay { get; private set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        [Required]
        public string Email { get; set; }
        [DataMember]
        [MinLength(4)]
        [MaxLength(50)]
        public string Phone { get; set; }

        [DataMember]
        public City City { get; set; }
        [DataMember]
        public Country Country { get; set; }

        [DataMember]
        public Role Role { get; set; }

        [DataMember]
        public ICollection<Loan> Loans { get; set; }
        [DataMember]
        public ICollection<Deposit> Deposits { get; set; }

        [DataMember]
        public Branch Branches { get; set; }

        public User()
        {

        }

        public User(string firstName, string lastName, byte gender, string uniqueNumber, DateTime birthDay, string address, string email, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            UniqueNumber = uniqueNumber;
            BirthDay = birthDay;
            Address = address;
            Email = email;
            Phone = phone;
        }
    }
}
