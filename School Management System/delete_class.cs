using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Management_System
{
    class delete_class
    {
        private string connstring = ConfigurationManager.ConnectionStrings["TESTDB"].ConnectionString;

        public string delete_srecord(string id)
        {
            string msg = " ";
            SqlConnection conn = new SqlConnection(connstring);

            try
            {
                SqlCommand cmd = new SqlCommand("delete_student", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@std_id ", SqlDbType.Int).Value = id;
                

                conn.Open();
                cmd.ExecuteNonQuery();

                msg = "DATA record has been deleted successfully.....";
            }
            catch (Exception)
            {
                msg = "data is not deleted !!!";

            }

            finally
            {
                conn.Close();
            }

            return msg;


        }//method end.....


    }
}
