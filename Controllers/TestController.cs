using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using evaluation.Models;
using evaluation.Services;
using evaluation.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace evaluation.Controllers
{
  
    public class TestController : Controller
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }
        public IActionResult Index()
        {
           var listOfTestDetials = _testService.GetListOfTestDetails().Result;

            return View(listOfTestDetials);
        }


        [HttpGet]
        public IActionResult GetTest()
        {
            var testViewModel = new TestViewModel();
            testViewModel.TestTypeList = _testService.GetTestType().Result;

            return View(testViewModel);
        }


        [HttpGet]
        public IActionResult GetTestDetails(int id)
        {

            @ViewBag.ID = id;
            var testDetials = _testService.GetTestDetails(id).Result;
            return View(testDetials);
        }

        [HttpGet]
        public IActionResult DeleteTest(int id)
        {

            var result = _testService.InactiveTest(id).Result;

            return RedirectToAction("Index", "Test");
  
        }



        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult InsertTest(TestViewModel testViewModel)
        {
            TestModel testModel = new TestModel();
            testModel.CreateDate = testViewModel.CreatedDate;
            testModel.TestType = testViewModel.TestType;
            testModel.IsActive = true;
            testModel.TestName = testViewModel.TestName;

            var result = _testService.InsertTest(testModel).Result;
            if (result > 0)
            {
                return RedirectToAction("Index", "Test");
            }
            else
            {
                return RedirectToAction("GetTest", "Test", new { err = "true" });
            }
          
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
