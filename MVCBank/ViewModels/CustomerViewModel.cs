using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBank.ViewModels
{
    public class CustomerViewModel
    {
        [Key]
        [Display(Name = "Customer Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "First name can not be longer than 50 chracters")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "Last name can not be longer than 50 chracters")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public System.DateTime DOB { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Display(Name = "Image Name")]

        public string ImageName { get; set; }
        [Display(Name ="Image")]
        public string ImageUrl { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
        [Display(Name = "Customer Name")]

        public string CustomerName
        {
            get
            {
                return FirstName + " " + LastName;
            }

        }
    }
}