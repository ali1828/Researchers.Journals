using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Researchers.Journals.Models
{
    public class Login
    {
        [Key]
        [Range(00000000, 99999999)]
        public int Id { get; set; }


        [Required]
        [Display(Name = "User Name")]
        [StringLength(200, ErrorMessage = "Value must be 12 characters", MinimumLength = 12)]

        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(100, 
            ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
            MinimumLength = 6)]

        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]

        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Researcher Name")]
        [StringLength(200, ErrorMessage = "Value must be 12 characters", MinimumLength = 12)]

        public string ResearcherName { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        public int ResearcherAddedID { get; set; }
    }
}
