using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class UserForCreationDto
    {
        [Required(ErrorMessage = "User name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        [MinLength(5, ErrorMessage = "Minimum length for the Name is 5 characters.")]
        public string OrgName { get; set; }

        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 26 characters.")]
        [MinLength(1, ErrorMessage = "Minimum length for the Name is 1 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Email is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Email is 60 characters.")]
        [MinLength(1, ErrorMessage = "Minimum length for the Email is 1 characters.")]
        public string Country { get; set; }
    }
}
