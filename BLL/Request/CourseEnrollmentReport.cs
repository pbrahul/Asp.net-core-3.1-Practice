using DLL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BLL.Request
{
    public class CourseEnrollmentReport
    {
        public string StudentName { get; set; }
        public string StudentRollNo { get; set; }
        public string StudentEmail { get; set; }
        //public string CourseName { get; set; }
        //public string CourseCode { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Student> Students { get; set; }
        //[JsonIgnore]
        public ICollection<CourseStudent> CourseStusents { get; set; }
    }
}
