using evaluation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evaluation.DB
{
    public interface ITestDb
    {
        Task<int> InsertTestAsync(TestModel testModel);
        Task<List<TestTypeModel>> GetTestTypeAsync();
        Task<List<TestListModel>> GetListOfTestDetailsAsync();
        Task<List<TestDetailsModel>> GetTestDetailsAsync(int testId);
        Task<int> InactiveTestAsync(int testId);

        Task<int> InsertAthleteInTestAsync(TestDetailsModel testDetailsModel);
        Task<int> InactiveAthleteAsync(int testId, int userId);
    }
}
