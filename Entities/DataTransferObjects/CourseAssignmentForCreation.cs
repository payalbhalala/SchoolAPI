using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class CourseAssignmentForCreationDto
    {
        [Required(ErrorMessage = "Org name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        [MinLength(5, ErrorMessage = "Minimum length for the Name is 5 characters.")]
        public string OrgName { get; set; }

        [Required(ErrorMessage = "Assignmenttitle is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the CourseId is 20 characters.")]
        [MinLength(1, ErrorMessage = "Minimum length for the CourseId is 1 characters.")]
        public string Assignmenttitle { get; set; }
    }
}

  