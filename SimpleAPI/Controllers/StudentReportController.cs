using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SimpleAPI.Controllers
{
    public class StudentReportController : APIConnectionController
    {
        private readonly IStudentService _studentService;
        private readonly ICourseEnrollService _courseEnrollService;

        public StudentReportController(IStudentService studentService, ICourseEnrollService courseEnrollService)
        {
            _studentService = studentService;
            _courseEnrollService = courseEnrollService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllStudentDepartmentAsync()
        {
            return Ok(await _studentService.GetAllStudentDepartmentReportAsync());
        }

        [HttpGet("GetAllStudentCourseEnrollAsync")]
        public async Task<ActionResult> GetAllStudentCourseEnrollAsync()
        {
            return Ok(await _courseEnrollService.GetAllStudentCourseEnrollReportAsync());
        }

    }
}