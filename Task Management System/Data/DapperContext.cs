using System.Data;
using Microsoft.Data.SqlClient;

namespace Task_Management_System.Data
{
    public class DapperContext
    {
        private string _connnectionString;

        public DapperContext(string connnectionString)
        {
            _connnectionString = connnectionString;
        }
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connnectionString);
        }
    }
}
