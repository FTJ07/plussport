using evaluation.DB;
using evaluation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evaluation.Services
{
    public class TestService:ITestService
    {
        private readonly ITestDb _testDb;
        public TestService(ITestDb testDb)
        {
            _testDb = testDb;
        }

     
        public async Task<int> InsertTest(TestModel testModel)
        {
          return await _testDb.InsertTestAsync(testModel);
        }

        public async Task<List<TestTypeModel>> GetTestType()
        {
           return await _testDb.GetTestTypeAsync();
        }


        public async Task<List<TestListModel>> GetListOfTestDetails()
        {
            return await _testDb.GetListOfTestDetailsAsync();
        }


        public async Task<int> InactiveTest(int testId)
        {
            return await _testDb.InactiveTestAsync(testId);
        }

        public async Task<List<TestDetailsModel>> GetTestDetails(int testId)
        {
            return await _testDb.GetTestDetailsAsync(testId);
        }

        public async Task<int> InactiveAthlete(int testId, int userId)
        {
            return await _testDb.InactiveAthleteAsync(testId, userId);
        }

        public async Task<int> InsertAthleteInTest(TestDetailsModel testDetailsModel)
        {
            return await _testDb.InsertAthleteInTestAsync(testDetailsModel);
        }

    }
}
