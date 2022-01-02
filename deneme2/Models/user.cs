using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace deneme2.Models
{
    public class User
    {
        public int UserId
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Please provide username", AllowEmptyStrings = false)]
        public string UserName
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Please provide Password", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Password must be minimum 4 characters long.")]
        public string Password
        {
            get;
            set;
        }
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Confirm password does not match.")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string ConfirmPassword
        {
            get;
            set;
        }
    }
}