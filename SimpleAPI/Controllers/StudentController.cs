using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLL.Repository;
using DLL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using BLL.Request;
using Microsoft.AspNetCore.Authorization;

namespace SimpleAPI.Controllers
{

    public class StudentController : APIConnectionController
    {
       
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            
            _studentService = studentService;
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _studentService.GetAllStudentAsync());
        }

        [HttpGet]
        [Authorize]
        [Route(template: "{rollNo}")]
        public async Task<ActionResult> GetSingleStudent(string rollNo)
        {
            return Ok(await _studentService.FindAStudentAsync(rollNo));
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Staff")]
        public async Task<ActionResult> AddStudent(StudentInsertRequest aStudent)
        {
            return Ok(await _studentService.AddStudentAsync(aStudent));
        }

        [HttpDelete]
        [Authorize(Roles = "Admin, Staff")]
        [Route(template: "{rollNo}")]
        public async Task<ActionResult> Delete(string rollNo)
        {
            return Ok(await _studentService.DeleteAStudentAsync(rollNo));
        }

        [HttpPut]
        [Authorize(Roles = "Admin, Teacher")]
        [Route(template: "{rollNo}")]
        public async Task<ActionResult> Update(string rollNo, StudentUpdateRequest aStudent)
        {
            return Ok(await _studentService.UpdateStudentAsync(rollNo, aStudent));
        }


    }
}