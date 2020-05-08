using System.Threading.Tasks;
using BLL.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Controllers;
using Utility.Helpers;

namespace SimpleAPI.Controllers
{
    public class TestController : APIConnectionController
    {
        private readonly ITestService _testService;
        private readonly TaposRSA _taposRSA;

        public TestController(ITestService testService, TaposRSA taposRSA)
        {
            _testService = testService;
            _taposRSA = taposRSA;
        }  

        //[HttpPost]
        ////[System.Obsolete]
        //public async Task<IActionResult> Index()
        //{
        //    _taposRSA.GenerateRsaKey("v1");
        //    await _testService.SaveAllData();
        //    return Ok("Hello");

        //}

        [HttpGet]
        public async Task<IActionResult> Index()
        {
        
            //_taposRSA.GenerateRsaKey("v1");
            //await _testService.SaveAllData();
            await _testService.UpdateBalance();
            return Ok("Hello");

        }
    }
}