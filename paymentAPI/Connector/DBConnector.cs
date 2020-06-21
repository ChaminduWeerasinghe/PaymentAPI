using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace paymentAPI.Connector
{
    public class DBConnector : IDBConnector
    {
        private IConfiguration _configuration;
        private string _connectionString;
        public IDbConnection connection
        {
            get
            {
                Console.WriteLine("Connection String :"+ _connectionString);
                return new SqlConnection(_connectionString);
            }
        }

        public DBConnector(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("paf-2020.database.windows.net");
        }

    }
}
