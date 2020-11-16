using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCBank.Models
{
    public enum Type { Current, Savings, FixedDeposit }
    public class Account
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name="Account No")]
        public int AccountId { get; set; }
        [Display(Name = "Account Holder")]
        public int CustomerId { get; set; }

        [Display(Name = "Branch")]
        public int BranchId { get; set; }

        [Display(Name = "Account Type")]
        [DisplayFormat(NullDisplayText ="No Account Type")]
        public Type? AccountType { get; set; }

        [Display(Name = "Opening Balance")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal OpeningBalance { get; set; }
       
        [DataType(DataType.Date)]
        [Display(Name = "Account Created On")]
                public System.DateTime CreateDate { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Customer Customer { get; set; }
    }
}