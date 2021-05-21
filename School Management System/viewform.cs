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
    public partial class viewform : Form
    {
        view_class vc = new view_class();
        string q;
        public viewform()
        {
            InitializeComponent();
        }
        

        private void viewform_Load(object sender, EventArgs e)
        {
            
            q = "select s.std_id as 'ID',s.std_name as 'Last Name',s.std_fname as 'First Name',s.std_gender as 'Gender',s.std_address as 'Address',s.std_addmissiondate as 'Date of Addmission',a.ad_name as 'Admin' from student s inner join administrator a on a.ad_id=s.std_ad_fk_id";
            dataGridView1.DataSource = vc.showrecord(q);
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            q = "select s.std_id as 'ID',s.std_name as 'Last Name',s.std_fname as 'First Name',s.std_gender as 'Gender',s.std_address as 'Address',s.std_addmissiondate as 'Date of Addmission',a.ad_name as 'Admin' from student s inner join administrator a on a.ad_id=s.std_ad_fk_id where s.std_fname like '" +textBox1.Text+"%'";
            dataGridView1.DataSource = vc.showrecord(q);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            q = "select s.std_id as 'ID',s.std_name as 'Last Name',s.std_fname as 'First Name',s.std_gender as 'Gender',s.std_address as 'Address',s.std_addmissiondate as 'Date of Addmission',a.ad_name as 'Admin' from student s inner join administrator a on a.ad_id=s.std_ad_fk_id where s.std_id ="+textBox2.Text;
            dataGridView1.DataSource = vc.showrecord(q);

            returnclass rc = new returnclass();
           string pathquerry= rc.scalarReturn("select img_path from student_img where img_fk=" + textBox2.Text);
            if (pathquerry==" ")
            {
                pictureBox1.Image = Image.FromFile(@"C:\Users\user\source\repos\School Management System\School Management System\Resources\profile.png");
            }
            else
            {
                pictureBox1.Image = Image.FromFile(pathquerry);
            }
            
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        
    }
}