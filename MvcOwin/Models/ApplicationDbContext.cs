using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcOwin.Models
{
    public class ApplicationDbContext
    {
        private string _connectionString;
        public ApplicationDbContext()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        }
        public void TryOnConnection(Action<SqlConnection> action)
        {
            using (SqlConnection dbCon = new SqlConnection(_connectionString))
            {
                action(dbCon);
            }
        }
    }
}