using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Request
{
    public class CourseEnrollmentReport
    {
        public string StudentName { get; set; }
        public string StudentRollNo { get; set; }
        public string StudentEmail { get; set; }

        public string CourseName { get; set; }
        public string CourseCode { get; set; }
    }
}
