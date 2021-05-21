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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            insertform obj = new insertform();
            obj.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            updateform obj = new updateform();
            obj.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            deleteform obj = new deleteform();
            obj.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            viewform obj = new viewform();
            obj.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
