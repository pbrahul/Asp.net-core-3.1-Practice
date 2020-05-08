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
   
    public class CourseController : APIConnectionController
    {
       
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            
            _courseService = courseService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetAllCourseAsync()
        {
            return Ok(await _courseService.GetAllCourseAsync());
        }

        [HttpGet]
        [Route(template: "{code}")]
        [Authorize]
        public async Task<ActionResult> GetACourseAsync(string code)
        {
            return Ok(await _courseService.FindACourseAsync(code));
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Staff")]
        public async Task<ActionResult> AddCourseAsync(CourseInsertRequest aCourse)
        {
            return Ok(await _courseService.AddCourseAsync(aCourse));
        }

        [HttpDelete]
        [Authorize(Roles = "Admin, Staff")]
        [Route(template: "{code}")]
        public async Task<ActionResult> Delete(string code)
        {
            return Ok(await _courseService.DeleteACourseAsync(code));
        }

        [HttpPut]
        [Authorize(Roles = "Admin, Staff")]
        [Route(template: "{code}")]
        public async Task<ActionResult> Update(string code, CourseUpdateRequest aCourse)
        {
            return Ok(await _courseService.UpdateCourseAsync(code, aCourse));
        }


    }
}