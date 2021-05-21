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
    public partial class insertform : Form
    {
        insert i = new insert();
        public insertform()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            s.sfk = Form1.fk_ad;
            s.sdate = System.DateTime.Now.ToShortDateString();
            s.sname = textBox4.Text;
            s.sfname = textBox3.Text;
            if (radioButton4.Checked==true)
            {
                s.sgender = "Male";

            }
            else if(radioButton3.Checked == true)
            {
                s.sgender = "Female";

            }
            else
            {
                MessageBox.Show("Please select your gender!");

            }
            s.saddress = richTextBox2.Text;


            
            MessageBox.Show(i.insert_srecord(s));

            returnclass r = new returnclass();
            student_status_class sa = new student_status_class();
            sa.year = System.DateTime.Now.Year.ToString();
            sa.class_id = Convert.ToInt16(comboBox1.SelectedValue.ToString());
            sa.status_student_id = Convert.ToInt32(r.scalarReturn("select max(std_id) from student"));
            i.insert_student_status(sa);



        }

        private void insertform_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'schoolDataSet.classes' table. You can move, or remove it, as needed.
            this.classesTableAdapter.Fill(this.schoolDataSet.classes);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
               open.Filter="Image Files(*.jpg;*.jpeg;*.gif;*.bmp)|*.jpg;*.jpeg;*.gif;*.bmp";

            if (open.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(open.FileName);
                textBox5.Text = open.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            std_img_class img = new std_img_class();
            img.s_id = Convert.ToInt32(textBox6.Text);
            img.img_path = textBox5.Text;
            i.insert_img(img);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            returnclass r = new returnclass();
            student_status_class sa = new student_status_class();
            sa.year = System.DateTime.Now.Year.ToString();
            sa.class_id = Convert.ToInt16(comboBox1.SelectedValue.ToString());
            sa.status_student_id = Convert.ToInt32(textBox7.Text);
            i.insert_student_status(sa);
           
        }
    }
}
