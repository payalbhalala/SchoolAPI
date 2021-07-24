using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class SectionEnrollmentForCreationDto
    {
        [Required(ErrorMessage = "Org name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        [MinLength(5, ErrorMessage = "Minimum length for the Name is 5 characters.")]
        public string OrgName { get; set; }

        [Required(ErrorMessage = "SectionId is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 26 characters.")]
        [MinLength(1, ErrorMessage = "Minimum length for the Name is 1 characters.")]
        public string SectionId { get; set; }

        
    }
}
