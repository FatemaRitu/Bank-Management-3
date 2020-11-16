using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBank.Models
{
    public class Branch
    {
        public Branch()
        {
            this.Accounts = new HashSet<Account>();
            this.Employees = new HashSet<Employee>();
            this.Transactions = new HashSet<Transaction>();
        }

        [Key]
        [Display(Name = "Branch Id")]
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 3)]
        [Required]
        [Display(Name ="Branch Name")]
        public string BranchName { get; set; }
        [Required]
        [Display(Name = "Branch Address")]
        public string BranchAddress { get; set; }
        [Required]
        [Display(Name = "Branch Phone")]
        public string BranchPhone { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}