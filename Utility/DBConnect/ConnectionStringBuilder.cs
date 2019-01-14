using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.DBConnect
{
    public static class ConnectionStringBuilder
    {
        public static string BuildConnectionString(string dataSource)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.InitialCatalog = "master";
            builder.DataSource = dataSource;
            builder.IntegratedSecurity = true;
            return builder.ConnectionString;
        }
    }
}
