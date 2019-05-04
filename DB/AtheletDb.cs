using evaluation.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace evaluation.DB
{
    public class AtheletDb : IAtheletDb
    {
        private readonly DbConfig _dbConfig;

        public AtheletDb(DbConfig dbConfig)
        {
            _dbConfig = dbConfig;
        }

        public async Task<List<UserModel>> GetAtheletAsync()
        {
            List<UserModel> list = new List<UserModel>();
            try
            {
                var cmd = new MySqlCommand();
                cmd.CommandText = @"SELECT * FROM plussport.user where UserType=2";

                cmd.Connection = _dbConfig.Connection;
                _dbConfig.Connection.Open();

                var reader = await cmd.ExecuteReaderAsync();
                while (reader.Read())
                {
                    list.Add(new UserModel()
                    {
                        UserId = Convert.ToInt32(reader["UserId"]),
                        UserName = reader["UserName"].ToString()
                    });
                };

                _dbConfig.Connection.Close();
            }
            catch (Exception ex)
            {

            }
            return list;
        }


         public async Task<int> InsertAthleteInTestAsync(TestDetailsModel testDetailsModel)
         {
            var Id = 0;
            if (!CheckAthleteInTestAsync(testDetailsModel).Result)
            {
              
                try
                {
                    var cmd = new MySqlCommand();
                    cmd.CommandText = @"INSERT INTO `testdetails` (`UserId`, `TestId`,`Result`,`IsActive`) VALUES (@UserId, @TestId, @Result, @IsActive);";
                    cmd.Parameters.Add(new MySqlParameter { ParameterName = "@UserId", DbType = DbType.Int16, Value = testDetailsModel.UserId });
                    cmd.Parameters.Add(new MySqlParameter { ParameterName = "@TestId", DbType = DbType.Int16, Value = testDetailsModel.TestId });
                    cmd.Parameters.Add(new MySqlParameter { ParameterName = "@Result", DbType = DbType.Int16, Value = testDetailsModel.Result });
                    cmd.Parameters.Add(new MySqlParameter { ParameterName = "@IsActive", DbType = DbType.Boolean, Value = testDetailsModel.IsActive });
                    cmd.Connection = _dbConfig.Connection;
                    _dbConfig.Connection.Open();
                    await cmd.ExecuteNonQueryAsync();
                    Id = (int)cmd.LastInsertedId;
                    _dbConfig.Connection.Close();
                }
                catch (Exception ex)
                {

                }

                
            }
            return Id;

        }


        public async Task<bool> CheckAthleteInTestAsync(TestDetailsModel testDetailsModel)
        {
            var isExist = false;
            try
            {
                var cmd = new MySqlCommand();
                cmd.CommandText = @"Select * from `testdetails` where TestId = "+testDetailsModel.TestId +" and UserId = "+testDetailsModel.UserId+";";

                cmd.Connection = _dbConfig.Connection;
                _dbConfig.Connection.Open();
                var reader = await cmd.ExecuteReaderAsync();
                while (reader.Read())
                {
                    isExist = true;


                };

                _dbConfig.Connection.Close();
            }
            catch (Exception ex)
            {

            }

            return isExist;

        }



        public async Task<int> InactiveAthleteInTestAsync(TestDetailsModel testDetailsModel)
        {
            var result = 0;
            try
            {
                var cmd = new MySqlCommand();
                cmd.CommandText = @"Delete from testdetails where TestId = " + testDetailsModel.TestId + " and UserId = "+ testDetailsModel.UserId + ";";
                cmd.Connection = _dbConfig.Connection;
                _dbConfig.Connection.Open();
                result = await cmd.ExecuteNonQueryAsync();

            }
            catch (Exception ex)
            {

            }

            return result;

        }


        public async Task<int> UpdateAthleteInTestAsync(TestDetailsModel testDetailsModel)
        {
            var result = 0;
            try
            {
                var cmd = new MySqlCommand();
                cmd.CommandText = @"Update `testdetails` Set Result = "+testDetailsModel.Result+" where UserId ="+ testDetailsModel.UserId + " and TestId = "+testDetailsModel.TestId + ";";

                cmd.Connection = _dbConfig.Connection;
                _dbConfig.Connection.Open();
                result = await cmd.ExecuteNonQueryAsync();
                _dbConfig.Connection.Close();
            }
            catch (Exception ex)
            {

            }

            return result;

        }

    }
}
