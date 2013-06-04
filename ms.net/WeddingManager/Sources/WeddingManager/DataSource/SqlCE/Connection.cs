using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.IO;
using System.Data;
using System.Diagnostics;

namespace DataSource.SqlCE
{
    public static class Connection
    {
        private static SqlCeConnection _connection;
        private static string _applicationPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        private static string _connectionString = "Data Source=" + _applicationPath + "\\SqlCE\\WeddingManagerData.sdf;Persist Security Info=False;";
        
        public static bool TestConnection()
        {
            try
            {
                GetConnection();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static IDbConnection GetConnection()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
                return _connection;

            _connection = new SqlCeConnection(_connectionString);

            //try
            //{
                _connection.Open();
            //}
            //catch (SqlCeInvalidDatabaseFormatException)
            //{
            //    //TODO: Use messages handling system
            //    Trace.WriteLine("Warning: SqlCeInvalidDatabaseFormatException was occured");
            //    new SqlCeEngine(_connectionString).Upgrade();
            //    Trace.WriteLine("Warning: Data base version upgraded");
            //    _connection.Open();
            //}

            return _connection;
        }

    }
}
