using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class SectionEnrollmentDto
    {
        public Guid Id { get; set; }
        public string OrgName { get; set; }
        public string FullAddress { get; set; }
    }
}