using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JIST
{
    public partial class Admission_Registration : Form
    {
        //Constructor calling and initializing
        public Admission_Registration()
        {
            InitializeComponent();
            admissoindash.Normalcolor = Color.FromArgb(252, 86, 83);
        }

        //Going to admission and registration form when click on admission from dashboard
        private void admissoindash_Click(object sender, EventArgs e)
        {
            Admission_Registration adr = new Admission_Registration();
            this.Hide();
            adr.ShowDialog();
        }

        //Going to student management form when click on student management button from dashboard
        private void studentdash_Click(object sender, EventArgs e)
        {
            StudentManagement stdm = new StudentManagement();
            this.Hide();
            stdm.ShowDialog();
        }

        //Going to staff management form when click on staffmanagement button from dashboard
        private void staffdash_Click(object sender, EventArgs e)
        {
            StaffManagement stm = new StaffManagement();
            this.Hide();
            stm.ShowDialog();
        }

        //Going to fees form when click on fees button form dashboard
        private void feedash_Click(object sender, EventArgs e)
        {
            Fee_Payment fp = new Fee_Payment();
            this.Hide();
            fp.ShowDialog();
        }

        //Going to exam management form when click on exam management button form dashboard
        private void examdash_Click(object sender, EventArgs e)
        {
            ExamManagement exm = new ExamManagement();
            this.Hide();
            exm.ShowDialog();
        }

        //Going to exam management form when click on exam management button form dashboard
        private void attendancedash_Click(object sender, EventArgs e)
        {
            Attendance at = new Attendance();
            this.Hide();
            at.ShowDialog();
        }

        //Going to exam management form when click on exam management button form dashboard
        private void collectivedash_Click(object sender, EventArgs e)
        {
            CollectiveInformation collinf = new CollectiveInformation();
            this.Hide();
            collinf.ShowDialog();
        }

        //Going to homepage when click on home button from dashboard
        private void homepagedash_Click(object sender, EventArgs e)
        {
            homepage hm = new homepage();
            this.Hide();
            hm.ShowDialog();
        }

        //Form closing 
        private void Admission_Registration_FormClosed(object sender, FormClosedEventArgs e)
        {
          
            Application.Exit();
        }

        //Student from calling when click button1
        private void button1_Click(object sender, EventArgs e)
        {
            Student_Admission student = new Student_Admission();
            this.Hide();
            student.ShowDialog();
        }

        //Back button to homepage
        private void button4_Click(object sender, EventArgs e)
        {
            homepage hom = new homepage();
            this.Hide();
            hom.ShowDialog();
        }

        //Opening Teaching Staff page when click on teaching staff button
        private void button2_Click(object sender, EventArgs e)
        {
            Teaching_Staff_Admission tsd = new Teaching_Staff_Admission();
            this.Hide();
            tsd.ShowDialog();
        }

        //Opening Non Teaching Staff page when click on Non teaching staff button
        private void button3_Click(object sender, EventArgs e)
        {
            Non_Teaching_Admission nad = new Non_Teaching_Admission();
            this.Hide();
            nad.ShowDialog();
        }


        //Sliding window button
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
             
            if (panel8.Width == 65)
            {
                panel8.Visible = false;
                panel8.Width = 334;
                animator1.ShowSync(panel8);
                animator2.ShowSync(pictureBox3);

            }
            else
            {
                animator2.Hide(pictureBox3);
                panel8.Visible = false;
                panel8.Width = 65;
                animator1.ShowSync(panel8);
            }
        }

        
        //Closing form when click on exit button
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Minimize form when click on minimize button
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
