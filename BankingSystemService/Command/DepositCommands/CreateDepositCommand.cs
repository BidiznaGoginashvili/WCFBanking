using System.Runtime.Serialization;

namespace BankingSystemService.Command.DepositCommands
{
    [DataContract]
    public class CreateDepositCommand
    {
        [DataMember]
        public decimal Balance { get; set; }
        [DataMember]
        public decimal MonthlyPay { get; set; }

        [DataMember]
        public int UserId { get; set; }
    }
}