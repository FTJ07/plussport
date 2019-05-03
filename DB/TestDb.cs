using evaluation.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace evaluation.DB
{
    public class TestDb: ITestDb
    {
        private readonly DbConfig _dbConfig;

        public TestDb(DbConfig dbConfig)
        {
            _dbConfig = dbConfig;
        }

        public async Task<int> InsertTestAsync(TestModel testModel)
        {
            var Id = 0;
            try
            {
                var cmd = new MySqlCommand();
                cmd.CommandText = @"INSERT INTO `test` (`CreatedDate`, `IsActive`,`TestType`,`TestName`) VALUES (@CreatedDate, @IsActive, @TestType,@TestName);";
                cmd.Parameters.Add(new MySqlParameter { ParameterName = "@CreatedDate", DbType = DbType.Date, Value = testModel.CreateDate });
                cmd.Parameters.Add(new MySqlParameter { ParameterName = "@IsActive", DbType = DbType.Boolean, Value = testModel.IsActive });
                cmd.Parameters.Add(new MySqlParameter { ParameterName = "@TestType", DbType = DbType.Int16, Value = testModel.TestType });
                cmd.Parameters.Add(new MySqlParameter { ParameterName = "@TestName", DbType = DbType.String, Value = testModel.TestName });
                cmd.Connection = _dbConfig.Connection;
                _dbConfig.Connection.Open();
                await cmd.ExecuteNonQueryAsync();
                Id = (int)cmd.LastInsertedId;
            }catch(Exception ex)
            {

            }

            return Id;
            
        }


        public async Task<List<TestTypeModel>> GetTestTypeAsync()
        {
            List<TestTypeModel> list = new List<TestTypeModel>();
            try
            {
                var cmd = new MySqlCommand();
                cmd.CommandText = @"Select * from testype;";

                cmd.Connection = _dbConfig.Connection;
                _dbConfig.Connection.Open();

                var reader = await cmd.ExecuteReaderAsync();
                while (reader.Read())
                {
                    list.Add(new TestTypeModel()
                    {
                        TestTypeId = Convert.ToInt32(reader["TestTypeId"]),
                        TestTypeName = reader["TestTypeName"].ToString()
                    });
                }
                _dbConfig.Connection.Close();
            }
            catch (Exception ex)
            {

            }
            return list;
        }



        public async Task<List<TestListModel>> GetListOfTestDetailsAsync()
        {
            List<TestListModel> list = new List<TestListModel>();
            try
            {
                var cmd = new MySqlCommand();
                cmd.CommandText = @"SELECT *,count(td.UserId) as Participate FROM plussport.test  as t
                                    LEFT  JOIN plussport.testdetails as td
                                    on t.TestId = td.TestId
                                    Left Join plussport.testype tt
                                    on t.TestType = tt.TestTypeId
                                    Where t.IsActive=true
                                    Group by t.TestId;";

                cmd.Connection = _dbConfig.Connection;
                _dbConfig.Connection.Open();

                var reader = await cmd.ExecuteReaderAsync();
                while (reader.Read())
                {
                    list.Add(new TestListModel()
                    {
                        TestId = Convert.ToInt32(reader["TestId"]),
                        TestName = reader["TestName"].ToString(),
                        TestTypeName = reader["TestTypeName"].ToString(),
                        Participate = Convert.ToInt32(reader["Participate"])
                    });
                };

                _dbConfig.Connection.Close();
            }
            catch (Exception ex)
            {

            }
            return list;
        }



        public async Task<List<TestDetailsModel>> GetTestDetailsAsync(int testId)
        {
            List<TestDetailsModel> list = new List<TestDetailsModel>();
            try
            {
                var cmd = new MySqlCommand();
                cmd.CommandText = @"SELECT * FROM plussport.testdetails as td
                            Left join plussport.user as u
                            On td.UserId = u.UserId
                            Where td.TestId = "+ testId +";";

                cmd.Connection = _dbConfig.Connection;
                _dbConfig.Connection.Open();

                var reader = await cmd.ExecuteReaderAsync();
                while (reader.Read())
                {
                    list.Add(new TestDetailsModel()
                    {
                        TestId = Convert.ToInt32(reader["TestId"]),
                        TestDetailsId = Convert.ToInt32(reader["TestDetailsId"]),
                        UserId = Convert.ToInt32(reader["TestDetailsId"]),
                        UserName = reader["UserName"].ToString(),
                        Result = Convert.ToInt32(reader["Result"])
                    });
                };

                _dbConfig.Connection.Close();
            }
            catch (Exception ex)
            {

            }
            return list;
        }


        

        public async Task<int> InactiveTestAsync(int testId)
        {
            var result = 0;
            try
            {
                var cmd = new MySqlCommand();
                cmd.CommandText = @"Update test SET IsActive = false where TestId =" + testId+";";
                cmd.Connection = _dbConfig.Connection;
                _dbConfig.Connection.Open();
                result = await cmd.ExecuteNonQueryAsync();
               
            }
            catch (Exception ex)
            {

            }

            return result;

        }


        public async Task<int> InsertAthleteInTestAsync(TestDetailsModel testDetailsModel)
        {
            var Id = 0;
            try
            {
                var cmd = new MySqlCommand();
                cmd.CommandText = @"INSERT INTO `testdetails` (`UserId`, `TestId`,`Result`,`IsActive`) VALUES (@UserId, @TestId, @Result, @IsActive);";
                cmd.Parameters.Add(new MySqlParameter { ParameterName = "@UserId", DbType = DbType.Int16, Value =testDetailsModel.UserId });
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

            return Id;

        }

        public async Task<int> InactiveAthleteAsync(int testId, int userId)
        {
            var result = 0;
            try
            {
                var cmd = new MySqlCommand();
                cmd.CommandText = @"Update testdetails SET IsActive = false where TestId =" + testId + " and UserId "+ userId + ";";
                cmd.Connection = _dbConfig.Connection;
                _dbConfig.Connection.Open();
                result = await cmd.ExecuteNonQueryAsync();

            }
            catch (Exception ex)
            {

            }

            return result;

        }


    }
}
