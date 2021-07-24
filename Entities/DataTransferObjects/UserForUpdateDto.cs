using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class UserForUpdateDto
    {
        [Required(ErrorMessage = "User name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        [MinLength(5, ErrorMessage = "Minimum length for the Name is 1 characters.")]
        public string OrgName { get; set; }

        [Required(ErrorMessage = "Org Name is a required field.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is a required field.")]
        public string Email { get; set; }
    }
}
