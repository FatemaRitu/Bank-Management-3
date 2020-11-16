using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCBank.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Account No")]
        public int AccountId { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Deposit { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Withdraw { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Transaction Date")]
        public System.DateTime TransactionDate { get; set; }
        [Display(Name = "Branch")]
        public int BranchId { get; set; }

        public virtual Branch Branch { get; set; }
    }
}