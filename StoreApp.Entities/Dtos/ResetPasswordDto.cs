using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Entities.Dtos
{
    public record class ResetPasswordDto
    {

        public String? UserName { get; init; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        public String? Password { get; init; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "ConfirmPassword is required.")]
        [Compare("Password", ErrorMessage = "Password and ConfirmPassword must be match.")]
        public String? ConfirmPassword { get; init; }   
    }
}
