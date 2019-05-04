using evaluation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evaluation.Services
{
   public interface IAtheletService
    {
        Task<List<UserModel>> GetAthelet();

        Task<int> InsertAthleteInTest(TestDetailsModel testDetailsModel);
        Task<int> InactiveAthleteInTest(TestDetailsModel testDetailsModel);

        Task<int> UpdateAthleteInTest(TestDetailsModel testDetailsModel);

       
    }
}
