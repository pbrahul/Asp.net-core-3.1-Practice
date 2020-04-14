using System.Threading.Tasks;
using BLL.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Controllers;

namespace SimpleAPI.Controllers
{
    public class TestController : APIConnectionController
    {
        private readonly ITestService _testService;
        
        public TestController(ITestService testService)
        {
            _testService = testService;
            
        }

        [HttpPost]
        public async Task<IActionResult> Index()
        {
            await _testService.SaveAllData();
            return Ok("Hello");

        }
    }
}