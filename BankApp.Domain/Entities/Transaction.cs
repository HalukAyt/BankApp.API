using BankApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public string TransactionUniqueReference { get; set; } 
        public decimal TransactionAmount { get; set; }
        public TranStatus TransactionStatus { get; set; }
        public bool IsSuccessful => TransactionStatus.Equals(TranStatus.Success); 
        public string TransactionSourceAccount { get; set; } 
        public string TransactionDestinationAccount { get; set;}
        public string TransactionParticulars { get; set; }
        public TranType TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }

    }

    public enum TranStatus
    {
        Failed,
        Success,
        Error
    }
    
    public enum TranType
    {
        Deposit,
        Withdrawal,
        Transfer
    }
}
