﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBank.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "User Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(50, MinimumLength = 3)]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}