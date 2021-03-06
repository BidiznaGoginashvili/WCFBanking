﻿using System;
using Banking.Shared;
using System.Runtime.Serialization;

namespace Banking.Domain.LoanManagement
{
    [DataContract]
    public class Loan : AggregateRoot
    {
        [DataMember]
        public decimal Amount { get; private set; }
        [DataMember]
        public decimal MonthlyPay { get; private set; }
        [DataMember]
        public DateTime StartDate { get; private set; }
        [DataMember]
        public DateTime FinishDate { get; private set; }

        [DataMember]
        public int? GuarantorId { get; set; }
        [DataMember]
        public Guarantor Guarantor { get; set; }

        [DataMember]
        public int? UserId { get; set; }
        [DataMember]
        public UserManagement.User User { get; set; }

        public Loan()
        {

        }

        public Loan(decimal amount, decimal monthlyPay, DateTime startDate, DateTime finishDate)
        {
            Amount = amount;
            MonthlyPay = monthlyPay;
            StartDate = startDate;
            FinishDate = finishDate;
        }
    }
}
