using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Utility.DBConnect
{
    public static class Connection
    {
        public static SqlConnection Conn { get; set; }
        static StringBuilder sb = new StringBuilder();

        public static string getConnectionString()
        {
            return ConnectionStringBuilder.BuildConnectionString("localhost");
        }
        public static SqlConnection Connect()
        {
            if (Conn!=null&& Conn.State==ConnectionState.Closed)
            {
                Conn.Open();              
            }
            else
            {
                Conn = new SqlConnection(getConnectionString());
                Conn.Open();
            }
            return Conn;         
        }


    }
}
