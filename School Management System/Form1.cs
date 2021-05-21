using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Management_System
{
    public partial class Form1 : Form
    {
        public static string fk_ad;
        public Form1()
        {
            InitializeComponent();
        }

        private void Login_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string usernamedb, passworddb;
            returnclass rc = new returnclass();
            usernamedb = rc.scalarReturn("select count(ad_id) from administrator where ad_name = '" + username + "'");


                if (usernamedb.Equals("0"))
            {

                MessageBox.Show("Invalid Username! Please try again.");
            }
                else
            {
                passworddb=rc.scalarReturn("select ad_password from administrator where ad_name='"+username+"'");

                    if(passworddb.Equals(password))
                {
                    fk_ad=rc.scalarReturn("select ad_id from administrator where ad_name='" + username + "'");
                    Form2 f = new Form2();
                    f.Show();
                }
                    else
                {
                    MessageBox.Show("Invalid Password! Please try again.");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
