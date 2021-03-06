using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class CourseAssignment
    {
        [Column("CourseAssignmentId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Assignmenttitle is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 60 characters.")]
       
        public string Assignmenttitle { get; set; }

        [ForeignKey(nameof(Organization))]
        public Guid OrganizationId { get; set; }

        public Organization Organization { get; set; }
    }
}