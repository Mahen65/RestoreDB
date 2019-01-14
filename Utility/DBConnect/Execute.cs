using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.IO;

namespace Utility.DBConnect
{
    public class Execute
    {
        private const string checkString = "SELECT name FROM sys.objects WHERE type = 'P' AND name='";

        public  void ExecuteSql<T>(T param,Procedures p)
        {
            SqlCommand cmd = new SqlCommand(p.ToString(),Connection.Connect());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(cmd);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            
            foreach (SqlParameter prr in cmd.Parameters)
            {
                bool found = false;
                if (prr.ParameterName.ToUpper() == "@RETURN_VALUE")
                    continue;
                for (int i = 0; i < Props.Length && !found; i++)
                {
                    string prName = "@" + Props[i].Name;
                    if (prr.ParameterName == prName)
                    {
                        PropertyInfo px = Props[i];
                        prr.Value = Props[i].GetValue(param, null);
                        found = true;
                    }
                }
            }
            try
            {
                cmd.BeginExecuteNonQuery();
            }
            catch (SqlException se)
            {
                //ToDo : Swallow exception log  
            }
            catch (Exception ex)
            {
                //ToDo : Swallow exception log  
            }
    
        }

        private void CallbackFunction(IAsyncResult result)
        {
            try
            {
                //un-box the AsynState back to the SqlCommand  
                //SqlCommand cmd = (SqlCommand)result.AsyncState;
                //SqlDataReader reader = cmd.EndExecuteReader(result);
                //while (reader.Read())
                //{
                //    Dispatcher.BeginInvoke(new delegateAddTextToListbox(AddTextToListbox),
                //    reader.GetString(0));
                //}

                //if (cmd.Connection.State.Equals(ConnectionState.Open))
                //{
                //    cmd.Connection.Close();
                //}
            }
            catch (Exception ex)
            {
                //ToDo : Swallow exception log  
            }
        }

        private void AddTextToListbox(string Text)
        {
            //listboxResult.Items.Add(Text);
        }

        public Tuple<bool,string> checkExists(Procedures p)
        {
            string s;
            bool b;

            SqlCommand cmd = new SqlCommand(checkString + p.ToString() +"'", Connection.Connect());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                b = true;
            }
            else
            {              
                b = false;
            }

            s = p.ToString();

            return new Tuple<bool, string>(b, s);            
        }

        public void ExecuteSqlFormFile(string file)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"StringReader\Resources\"+file+ ".sql");
            string script = File.ReadAllText(path);
            Server server = new Server(new ServerConnection(Connection.Connect()));
            server.ConnectionContext.ExecuteNonQuery(script);
        }
    }
}
