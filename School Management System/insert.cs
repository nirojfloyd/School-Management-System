using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace School_Management_System
{
    class insert
    {
        private string connstring = ConfigurationManager.ConnectionStrings["TESTDB"].ConnectionString;

        public string insert_srecord(Student s)
        {
            string msg = " ";
            SqlConnection conn = new SqlConnection(connstring);

            try
            {
                SqlCommand cmd = new SqlCommand("insert_student", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@std_name ", SqlDbType.NVarChar, 20).Value = s.sname;
                cmd.Parameters.Add("@std_fname ", SqlDbType.NVarChar, 20).Value =s.sfname ;
                cmd.Parameters.Add("@std_gender ", SqlDbType.NVarChar, 20).Value = s.sgender;
                cmd.Parameters.Add("@std_address ", SqlDbType.NVarChar, 100).Value =s.saddress;
                cmd.Parameters.Add("@std_addmissiondate ", SqlDbType.NVarChar, 20).Value = s.sdate;
                cmd.Parameters.Add("@std_ad_fk_id ", SqlDbType.NVarChar, 20).Value = s.sfk;

                conn.Open();
                cmd.ExecuteNonQuery();

                msg= "DATA record has been inserted successfully.....";
            }
            catch (Exception)
            { 
                msg= "data is not inserted !!!";

            }

            finally
            {
                conn.Close();
            }

            return msg;


        }//method end.....



        public void insert_img(std_img_class img)
        {
            
            SqlConnection conn = new SqlConnection(connstring);

            try
            {
                SqlCommand cmd = new SqlCommand("insert_student_img", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@img_path ", SqlDbType.NVarChar).Value = img.img_path;
                cmd.Parameters.Add("@img_fk ", SqlDbType.Int).Value = img.s_id;
               
                conn.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("DATA record has been inserted successfully.....");
            }
            catch (Exception)
            {
                MessageBox.Show("data is not inserted !!!");

            }

            finally
            {
                conn.Close();
            }

           


        }//method end...

        public void insert_student_status(student_status_class sa)
        {

            SqlConnection conn = new SqlConnection(connstring);

            try
            {
                SqlCommand cmd = new SqlCommand("insert_student_status", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@sa_st_id", SqlDbType.Int).Value = sa.status_student_id;
                cmd.Parameters.Add("@sa_class_id", SqlDbType.Int).Value = sa.class_id;
                cmd.Parameters.Add("@sa_year", SqlDbType.Int).Value = sa.year;

                conn.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("DATA record has been inserted successfully.....");
            }
            catch (Exception)
            {
                MessageBox.Show("data is not inserted !!!");

            }

            finally
            {
                conn.Close();
            }




        }//method end...

        public void insert_Fees(student_status_class sa, string id)
        {

            SqlConnection conn = new SqlConnection(connstring);

            try
            {
                SqlCommand cmd = new SqlCommand("insert_tblfees", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@fee_amount", SqlDbType.Float).Value = sa.class_fees;
                cmd.Parameters.Add("@fee_date", SqlDbType.NVarChar).Value = System.DateTime.Now.ToShortDateString();
                cmd.Parameters.Add("@fee_fk_std_id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@@sa_st_id", SqlDbType.Int).Value = sa.status_student_id;

                conn.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("DATA record has been inserted successfully.....");
            }
            catch (Exception)
            {
                MessageBox.Show("data is not inserted !!!");

            }

            finally
            {
                conn.Close();
            }




        }//method end...




    }
}

