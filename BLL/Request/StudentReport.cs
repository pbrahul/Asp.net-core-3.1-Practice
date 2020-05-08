using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Request
{
    public class StudentReport
    {
        public string StudentName { get; set; }
        public string StudentRollNo { get; set; }
        public string StudentEmail { get; set; }

        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
    }
}
