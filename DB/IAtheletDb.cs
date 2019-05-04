using evaluation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evaluation.DB
{
    public interface IAtheletDb
    {
        Task<List<UserModel>> GetAtheletAsync();

        Task<int> InsertAthleteInTestAsync(TestDetailsModel testDetailsModel);

        Task<int> UpdateAthleteInTestAsync(TestDetailsModel testDetailsModel);
        Task<int> InactiveAthleteInTestAsync(TestDetailsModel testDetailsModel);

        Task<bool> CheckAthleteInTestAsync(TestDetailsModel testDetailsModel);
    }
}
