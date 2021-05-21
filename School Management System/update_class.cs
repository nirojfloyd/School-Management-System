using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace School_Management_System
{
    class update_class
    {
        private string connstring = ConfigurationManager.ConnectionStrings["TESTDB"].ConnectionString;



        public string update_srecord(Student s)
        {
            string msg = " ";
            SqlConnection conn = new SqlConnection(connstring);

            try
            {
                SqlCommand cmd = new SqlCommand("update_student", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@std_id ", SqlDbType.Int).Value = s.s_id;
                cmd.Parameters.Add("@std_name ", SqlDbType.NVarChar, 20).Value = s.sname;
                cmd.Parameters.Add("@std_fname ", SqlDbType.NVarChar, 20).Value = s.sfname;
                cmd.Parameters.Add("@std_gender ", SqlDbType.NVarChar, 20).Value = s.sgender;
                cmd.Parameters.Add("@std_address ", SqlDbType.NVarChar, 100).Value = s.saddress;
               
                conn.Open();
                cmd.ExecuteNonQuery();

                msg = "DATA record has been updated successfully.....";
             }
            catch (Exception)
            {
                msg = "data is not updated !!!";

            }

            finally
            {
                conn.Close();
            }

            return msg;


        }



    }
}


