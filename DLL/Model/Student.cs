using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using DLL.Model.Interfaces;

namespace DLL.Model
{
   public class Student : ITrackable,ISoftDelete
    {
        [Key]
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string RollNo { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public int DeptID { get; set; }

        [ForeignKey("DeptID")]
        public Department Department { get; set; }
    }
}
