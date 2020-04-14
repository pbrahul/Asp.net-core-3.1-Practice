using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Request
{
    public class StudentUpdateRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string RollNo { get; set; }
        public int DeptId { get; set; }
    }
}
