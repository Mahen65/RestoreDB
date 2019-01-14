using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.DBConnect;

namespace Utility.DataService
{
    public class DataService
    {
        public void RestoreDB(Backup b)
        {
            Execute exe = new Execute();

            if (AllProceduresAvailable())
            {
                exe.ExecuteSql<Backup>(b, Procedures.spRestoreFromFolder);    
            }     
        }

        private bool AllProceduresAvailable()
        {
            Execute exe = new Execute();

            foreach (Procedures p in Enum.GetValues(typeof(Procedures)))
            {
                Tuple<bool, string> T = exe.checkExists(p);
                if (!T.Item1)
                {
                    exe.ExecuteSqlFormFile(T.Item2);
                }
            }

            return true;
        }


    }
}
