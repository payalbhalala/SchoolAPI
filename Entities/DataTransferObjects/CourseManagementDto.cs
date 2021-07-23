using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class CourseManagementDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FullAddress { get; set; }
    }
}