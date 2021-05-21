using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace School_Management_System
{
    class returnclass
    {
        private string connstring = ConfigurationManager.ConnectionStrings["TESTDB"].ConnectionString;
        public string scalarReturn(string q)
        {
            string s;
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(q, conn);
                s = cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {

                s = " ";
            }
            
            return s;

        }

    }
}
