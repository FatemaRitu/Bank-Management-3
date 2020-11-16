using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCBank.Models
{
    public enum Designation
    { Administrator, Executive_Manager, Senior_Officer, Executive_Officer, Junior_Officer, Trainee_Officer }
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Employee Name")]
        [StringLength(80, ErrorMessage = "Employee name can not be longer than 50 chracters")]
        [Column("EmployeeName")]
        public string Name { get; set; }

        [DisplayFormat(NullDisplayText = "Not Assigned")]
        public Designation? Designations { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName ="money")]
        public decimal Salary { get; set; }
        [Display(Name = "Joining Date")]
        [DataType(DataType.Date)]     
        public System.DateTime JoiningDate { get; set; }

        [Display(Name = "Branch")]
        public int BranchId { get; set; }

        public virtual Branch Branch { get; set; }
    }
}