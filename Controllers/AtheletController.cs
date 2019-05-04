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
    
    public class AtheletController : Controller
    {
        private readonly IAtheletService _atheletService;

        public AtheletController(IAtheletService atheletService)
        {
            _atheletService = atheletService;
        }
       


        [HttpGet]
        public IActionResult GetAthelet()
        {
            var listOfAthelet = _atheletService.GetAthelet().Result;
            return Json(listOfAthelet);
        }



        [HttpPost]
        public IActionResult InsertAthleteInTest([FromBody]TestDetailsModel testDetailsModel)
        {

            testDetailsModel.IsActive = true;
            var output = _atheletService.InsertAthleteInTest(testDetailsModel).Result;
            return Json(output);
        }


        [HttpPost]
        public IActionResult UpdateAthleteInTest([FromBody]TestDetailsModel testDetailsModel)
        {
            var output = _atheletService.UpdateAthleteInTest(testDetailsModel).Result;
            return Json(output);
        }


        [HttpPost]
        public IActionResult InActiveAthleteInTest([FromBody]TestDetailsModel testDetailsModel)
        {

            testDetailsModel.IsActive = false;
            var output = _atheletService.InactiveAthleteInTest(testDetailsModel).Result;
            return Json(output);
        }


    }
}
