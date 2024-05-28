using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhenWhere.Core.Enums;

namespace WhenWhere.Core.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "FirstName can't be blank")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName can't be blank")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email can't be blank")]
        [EmailAddress]
        [Remote(action: "IsEmailAlreadyRegistered", controller: "Account", ErrorMessage = "Email is already taken")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password can't be blank")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password can't be blank")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Phone can't be blank")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone numbers should contain numbers only")]
        public string Phone { get; set; }
        [BindNever]
        public UserTypeOptions UserType { get; set; } = UserTypeOptions.User;

    }
}
