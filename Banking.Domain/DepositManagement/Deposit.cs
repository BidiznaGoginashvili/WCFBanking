using Banking.Shared;
using System.Runtime.Serialization;

namespace Banking.Domain.DepositManagement
{
    [DataContract]
    public class Deposit : AggregateRoot
    {
        [DataMember]
        public decimal Balance { get; private set; }
        [DataMember]
        public decimal MonthlyPay { get; private set; }

        [DataMember]
        public int? UserId { get; set; }
        [DataMember]
        public UserManagement.User User { get; set; }

        public Deposit()
        {

        }

        public Deposit(decimal balance, decimal monthlyPay)
        {
            Balance = balance;
            MonthlyPay = monthlyPay;
        }
    }
}
