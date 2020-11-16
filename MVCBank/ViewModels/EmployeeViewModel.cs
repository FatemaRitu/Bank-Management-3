using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCBank.ViewModels
{
    public enum Desig
    { Administrator, Executive_Manager, Senior_Officer, Executive_Officer, Junior_Officer, Trainee_Officer }

    public class EmployeeViewModel
    {
        public int Id { get; set; }


        [Display(Name ="Employee Name")]
        public string Name { get; set; }

        [DisplayFormat(NullDisplayText = "Not Assigned")]
        public Desig? Designations { get; set; }


        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Salary { get; set; }


        [Display(Name = "Joining Date")]
        public DateTime JoiningDate { get; set; }

        [Display(Name = "Branch")]
        public int BranchId { get; set; }


        [Display(Name = "Branch")]
        public string BranchName { get; set; }

    }
}