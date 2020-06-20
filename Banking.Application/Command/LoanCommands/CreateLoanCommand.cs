using System;
using System.Runtime.Serialization;

namespace Banking.Application.Command.LoanCommands
{
    [DataContract]
    public class CreateLoanCommand
    {
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public decimal MonthlyPay { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime FinishDate { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string GuarantorFirstName { get; set; }
        [DataMember]
        public string GuarantorLastName { get; set; }
        [DataMember]
        public string Relationship { get; set; }
        [DataMember]
        public string Phone { get; set; }
    }
}