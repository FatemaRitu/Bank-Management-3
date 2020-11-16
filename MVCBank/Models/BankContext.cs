using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCBank.Models
{
    public class BankContext:DbContext
    {
        public BankContext() : base("name=NewBankDB")
        {

        }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public System.Data.Entity.DbSet<MVCBank.ViewModels.EmployeeViewModel> EmployeeViewModels { get; set; }

        public System.Data.Entity.DbSet<MVCBank.ViewModels.UserViewModel> UserViewModels { get; set; }
    }
}