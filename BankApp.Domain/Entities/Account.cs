using BankApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Domain.Entities
{
    public class Account : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AccountName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public decimal? CurrentAccountBalance {  get; set; }
        public AccountType? AccountType { get; set; }
        public string? AccountNumberGenerated { get; set; }
        public byte[]? PinHash { get; set; }
        public byte[]? PinSalt { get; set;}
        public DateTime DateCreated { get; set; }
        public DateTime DateLastUpdated { get; set; }

        //random
        Random rand = new Random();

        public Account()
        {
            AccountNumberGenerated = Convert.ToString((long)rand.NextDouble() * 9_000_000_000L + 1_000_000_000L);     //random sayı
            AccountName = $"{FirstName} {LastName}";                                                                  //hesapadı
        }
    }

    public enum AccountType //hesaptürü
    {
        Savings,
        Current,
        Corporate,
        Government
    }

}
