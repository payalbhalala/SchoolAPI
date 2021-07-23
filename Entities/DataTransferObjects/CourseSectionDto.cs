using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class CourseSectionDto
    {
        public Guid Id { get; set; }
        public string CourseId { get; set; }
        public string FullAddress { get; set; }
    }
}