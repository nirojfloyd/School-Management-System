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
    public partial class updateform : Form
    {
        private string connstring = ConfigurationManager.ConnectionStrings["TESTDB"].ConnectionString;
        public updateform()
        {
            InitializeComponent();
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
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            s.sname = textBox1.Text;
            s.sfname = textBox2.Text;
            if (radioButton1.Checked == true)
            {
                s.sgender = "Male";

            }
            else
            {
                s.sgender = "Female";

            }
            s.saddress = richTextBox1.Text;
            s.s_id = Convert.ToInt32(textBox3.Text);

            update_class u = new update_class();
            string msg = u.update_srecord(s);
            MessageBox.Show(msg);

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void updateform_Load(object sender, EventArgs e)
        {

        }
    }
}
  
