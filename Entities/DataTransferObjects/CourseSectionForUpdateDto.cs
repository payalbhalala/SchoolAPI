using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class CourseSectionForUpdateDto
    {
        [Required(ErrorMessage = "Org name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        [MinLength(5, ErrorMessage = "Minimum length for the Name is 60 characters.")]
        public string OrgName { get; set; }

        [Required(ErrorMessage = "CourseId is a required field.")]
        public string CourseId { get; set; }
    }
}

