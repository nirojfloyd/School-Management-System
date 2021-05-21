using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Management_System
{
    public partial class Feesform : Form
    {

        private string connstring = ConfigurationManager.ConnectionStrings["TESTDB"].ConnectionString;

        public Feesform()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connstring);
            string sql = "select s.std_id,s.std_name,sa.sa_id,sa.sa_class_id,sa.sa_year, c.class_name,c.fees from student s inner join student_status sa on sa.sa_st_id=s.std_id inner join classes c on c.class_id=sa.sa_class_id where sa.sa_year='"+System.DateTime.Now.Year+"' and s.std_id=" + textBox1.Text;
            try
            {
                label2.Text = " ";
                label4.Text = "  ";
                label5.Text = " ";
                label6.Text = " ";

                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    label2.Text =reader.GetValue(1).ToString();
                    label4.Text =reader.GetValue(5).ToString();
                    label5.Text =reader.GetValue(6).ToString();
                    label6.Text =reader.GetValue(2).ToString();

                }
                connection.Close();

            }

            catch (Exception)
            {

                MessageBox.Show("NO RECORDS WERE FOUND !!!");
            }


            returnclass rc = new returnclass();
            string pathquerry = rc.scalarReturn("select img_path from student_img where img_fk=" + textBox1.Text);
            if (pathquerry == " ")
            {
                pictureBox1.Image = Image.FromFile(@"C:\Users\user\source\repos\School Management System\School Management System\Resources\profile.png");
            }
            else
            {
                pictureBox1.Image = Image.FromFile(pathquerry);
            }
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
       
        private void button2_Click_1(object sender, EventArgs e)
        {
            student_status_class sa = new student_status_class();
            sa.status_student_id = Convert.ToInt32(label6.Text);
            sa.class_fees = label5.Text;
            sa.class_name = label4.Text;
            insert i = new insert();
            i.insert_Fees(sa, textBox1.Text);

        }
    }





}
