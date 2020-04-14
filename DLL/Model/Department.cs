using DLL.Model.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DLL.Model
{
   public class Department : ISoftDelete,ITrackable
    {
        [Key]
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string Code { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        [JsonIgnore]
        public virtual ICollection<Student> Students { get; set; }
    }
}

//private git init;