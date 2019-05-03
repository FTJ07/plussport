using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evaluation.DB
{
    public class DbConfig: IDisposable
    {
        public MySqlConnection Connection;

        public DbConfig(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}
