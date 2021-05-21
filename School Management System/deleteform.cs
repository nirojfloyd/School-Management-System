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
    public partial class deleteform : Form
    {
        private string connstring = ConfigurationManager.ConnectionStrings["TESTDB"].ConnectionString;

        public deleteform()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            richTextBox1.Text = " ";

            SqlConnection connection = new SqlConnection(connstring);
            string sql = "select std_name,std_fname,std_gender,std_address from student where std_id=" + textBox3.Text;
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    textBox1.Text = reader.GetValue(0).ToString();
                    textBox2.Text = reader.GetValue(1).ToString();
                    if (reader.GetValue(2).ToString().Equals("Male"))
                    {
                        radioButton1.Checked = true;
                    }
                    else
                    {
                        radioButton2.Checked = true;
                    }
                    richTextBox1.Text = reader.GetValue(3).ToString();

                }
                connection.Close();

            }

            catch (Exception)
            {

                MessageBox.Show("NO RECORDS WERE FOUND !!!");
            }


            returnclass rc = new returnclass();
            string pathquerry = rc.scalarReturn("select img_path from student_img where img_fk=" + textBox3.Text);

            if (pathquerry != " ")
            {
                pictureBox1.Image = Image.FromFile(pathquerry);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pictureBox1.Image = Image.FromFile(@"C:\Users\user\source\repos\School Management System\School Management System\Resources\profile.png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            delete_class d = new delete_class();
            string msg=d.delete_srecord(textBox3.Text);
            MessageBox.Show(msg);
        }
    }
}
