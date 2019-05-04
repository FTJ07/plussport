using evaluation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evaluation.Services
{
   public interface ITestService
    {
        Task<int> InsertTest(TestModel testModel);
        Task<List<TestTypeModel>> GetTestType();
        Task<List<TestListModel>> GetListOfTestDetails();
        Task<List<TestDetailsModel>> GetTestDetails(int testId);
        Task<int> InactiveTest(int testId);

    }
}
