using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Request;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SimpleAPI.Controllers
{
    
    public class CourseEnrollController : APIConnectionController
    {
        private readonly ICourseEnrollService _courseEnrolService;

        public CourseEnrollController(ICourseEnrollService courseEnrolService)
        {
            _courseEnrolService = courseEnrolService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Staff")]
        public async Task<ActionResult> AddCourseEnrollAsync(CourseEnrollInsertRequest aCourseEnroll)
        {
            return Ok(await _courseEnrolService.AddCourseEnrollAsync(aCourseEnroll));
        }
    }
}