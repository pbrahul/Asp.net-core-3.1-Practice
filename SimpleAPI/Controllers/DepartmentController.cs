using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Request;
using BLL.Services;
using DLL.Model;
using DLL.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleAPI.Controllers
{
   
    public class DepartmentController : APIConnectionController
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetAllDepartmentAsync()
        {
            return Ok(await _departmentService.GetAllDepartmentAsync());
        }

        [HttpGet]
        [Route(template: "{code}")]
        [Authorize]
        public async Task<ActionResult> GetADepartmentAsync(string code)
        {
            return Ok(await _departmentService.FindADepartmentAsync(code));
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Staff")]
        public async Task<ActionResult> AddDepartmentAsync(DepartmentInsertRequest aDepartment)
        {
            return Ok(await _departmentService.AddDepartmentAsync(aDepartment));
        }

        [HttpDelete]
        [Authorize(Roles = "Admin, Staff")]
        [Route(template: "{code}")]
        public async Task<ActionResult> Delete(string code)
        {
            return Ok(await _departmentService.DeleteADepartmentAsync(code));
        }

        [HttpPut]
        [Authorize(Roles = "Admin, Staff")]
        [Route(template: "{code}")]
        public async Task<ActionResult> Update(string code, DepartmentUpdateRequest aDepartment)
        {
            return Ok(await _departmentService.UpdateDepartmentAsync(code, aDepartment));
        }


    }
}
