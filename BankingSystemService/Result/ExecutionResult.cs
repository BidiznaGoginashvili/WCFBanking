using System;
using System.Runtime.Serialization;

namespace BankingSystemService.Result
{
    [DataContract]
    public class ExecutionResult<TEntity> 
    {
        [DataMember]
        public bool Success { get; set; }
        [DataMember]
        public Exception Exception { get; set; }
        [DataMember]
        public TEntity Entity { get; set; }
    }
}