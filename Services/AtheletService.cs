using evaluation.DB;
using evaluation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evaluation.Services
{
    public class AtheletService:IAtheletService
    {
        private readonly IAtheletDb _atheletDb;
        public AtheletService(IAtheletDb atheletDb)
        {
            _atheletDb = atheletDb;
        }
        public async Task<List<UserModel>> GetAthelet()
        {
            return await _atheletDb.GetAtheletAsync();
        }

        public async Task<int> InactiveAthleteInTest(TestDetailsModel testDetailsModel)
        {
            return await _atheletDb.InactiveAthleteInTestAsync(testDetailsModel);
        }

        public async Task<int> InsertAthleteInTest(TestDetailsModel testDetailsModel)
        {
            return await _atheletDb.InsertAthleteInTestAsync(testDetailsModel);
        }

        public async Task<int> UpdateAthleteInTest(TestDetailsModel testDetailsModel)
        {
            return await _atheletDb.UpdateAthleteInTestAsync(testDetailsModel);
        }
    }


}
