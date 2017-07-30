using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Text.RegularExpressions;
using System.IO;

namespace JIST
{
    public partial class Teaching_Staff_Admission : Form
    {
        int i, teachcurvalue,percurvalue;
        int em, m, p;
        int name1, name2, name3, fname1, fname2, fname3, mname1, mname2, mname3;
        string departid, picpath;
        char gender;
        //Constructor calling and initializing
        public Teaching_Staff_Admission()
        {
            InitializeComponent();
            i = 0;
            teachcurvalue = percurvalue = 0;
            name1 = name2 = name3 = fname1 = fname2 = fname3 = mname1 = mname2 = mname3 = 0;
            departid = null;
            picpath = null;
            gender = ' ';
            em = m = p = 0;
            connection();
            department();
            DateTimepicker();
            button3.Enabled = false;
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

        //Form closing
        private void Teaching_Staff_Admission_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Back Button
        private void button4_Click(object sender, EventArgs e)
        {
            Admission_Registration ad = new Admission_Registration();
            this.Hide();
            ad.ShowDialog();
        }

        //Connnection checking
        void connection()
        {
            // checking database connectivity

            try
            {
                string str = "DATA SOURCE=localhost:1521/xe;USER ID = IMS; Password=enteryourchoice";
                OracleConnection mycon = new OracleConnection(str);
                mycon.Open();
                mycon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Date Time picker format and current date
        void DateTimepicker()
        {

            dateTimePicker1.CustomFormat = "dd-MMM-yyyy";

            dateTimePicker2.CustomFormat = "dd-MMM-yyyy";

            dateTimePicker1.MaxDate = DateTime.Today.AddYears(-22);
            dateTimePicker2.Value = DateTime.Now;
            i = 1;

        }

        //checking minimum phone number
        private void textBox3_Leave(object sender, EventArgs e)
        {
            string pattern = "^[0-9]{10}$";
            Regex obj = new Regex(pattern);
            if (obj.IsMatch(textBox3.Text))
            {
                m = 0;
                errorProvider1.Clear();
                if (em == 0 && m == 0 && p == 0)
                    button5.Enabled = true;
            }
            else
            {
                errorProvider1.SetError(this.textBox3, "Enter a valid number");
                button5.Enabled = false;
                m = 1;
            }

        }

        //checking pincode minimum
        private void textBox18_Leave(object sender, EventArgs e)
        {
            string pattern = "^[0-9]{6}$";
            Regex obj = new Regex(pattern);
            if (obj.IsMatch(textBox18.Text))
            {
                p = 0;
                errorProvider2.Clear();
                if (em == 0 && m == 0 && p == 0)
                    button5.Enabled = true;
            }
            else
            {
                errorProvider2.SetError(this.textBox18, "Enter a valid pincode");
                button5.Enabled = false;
                p = 1;
            }
        }

        //checking email validate
        private void textBox21_Leave(object sender, EventArgs e)
        {
            string pattern = "^[a-zA-Z0-9]{1,20}@[a-zA-Z]{1,10}.(com|org)$";
            Regex obj = new Regex(pattern);
            if (obj.IsMatch(textBox21.Text))
            {
                em = 0;
                errorProvider3.Clear();
                if (em == 0 && m == 0 && p == 0)
                    button5.Enabled = true;
            }
            else
            {
                errorProvider3.SetError(this.textBox21, "Please provide a valid email address");
                button5.Enabled = false;
                em = 1;
                return;
            }

        }


        //inserting department name in combobox1
        void department()
        {
            //inserting department name in combobox1

            string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "Select deptname from Department order by deptname";

            OracleCommand cmd = new OracleCommand(query, con);
            OracleDataReader rdr;
            try
            {
                con.Open();
                rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    string dept = rdr.GetString(0);
                    comboBox1.Items.Add(dept);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Teaching_Staff_Admission_Load(object sender, EventArgs e)
        {

        }

        //Making designation,salray,specialization,teacherid null when selecting Department
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox10.Text = null;
            textBox24.Text = null;
            textBox25.Text = null;
            comboBox2.Text = null;
            button3.Enabled = true;
        }

        //Applicant fname null by clicking on textbox
        private void textBox1_Click(object sender, EventArgs e)
        {
            //Applicant fname null by clicking on textbox
            if (name1 == 0)
            {
                textBox1.Text = null;
                name1 = 1;
            }
        }

        // Applicant mname null by clicking on textbox
        private void textBox4_Click(object sender, EventArgs e)
        {
            // Applicant mname null by clicking on textbox
            if (name2 == 0)
                textBox4.Text = null;
            name2 = 1;
        }

        //Applicant lname null by clicking on textbox
        private void textBox5_Click(object sender, EventArgs e)
        {
            //Applicant lname null by clicking on textbox
            if (name3 == 0)
                textBox5.Text = null;
            name3 = 1;
        }

        //Father fname null by clicking on textbox
        private void textBox6_Click(object sender, EventArgs e)
        {
            //Father fname null by clicking on textbox
            if (fname1 == 0)
                textBox6.Text = null;
            fname1 = 1;

        }

        //Father mname null by clicking on textbox
        private void textBox7_Click(object sender, EventArgs e)
        {
            //Father mname null by clicking on textbox
            if (fname2 == 0)
                textBox7.Text = null;
            fname2 = 1;
        }

        //Fathe lname null by clicking on textbox
        private void textBox8_Click(object sender, EventArgs e)
        {
            //Fathe lname null by clicking on textbox
            if (fname3 == 0)
                textBox8.Text = null;
            fname3 = 1;

        }

        //Mother fname null by clicking on textbox
        private void textBox9_Click(object sender, EventArgs e)
        {
            //Mother fname null by clicking on textbox
            if (mname1 == 0)
                textBox9.Text = null;
            mname1 = 1;
        }

        //Mother mname null by clickign on textbox
        private void textBox19_Click(object sender, EventArgs e)
        {
            //Mother mname null by clickign on textbox
            if (mname2 == 0)
                textBox19.Text = null;
            mname2 = 1;
        }

        //Mother lnamne null by clicking on textbox
        private void textBox22_Click(object sender, EventArgs e)
        {
            //Mother lnamne null by clicking on textbox
            if (mname3 == 0)
                textBox22.Text = null;
            mname3 = 1;
        }


        //Applicant name3=1 by pressing key on textbox 
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            name3 = 1;
        }

        //Applicant name2=1 by pressing key on textbox 
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            name2 = 1;
        }

        //Applicant name1=1 by pressing key on textbox 
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            name1 = 1;
        }

        //Applicant fname1=1 by pressing key on textbox 
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            fname1 = 1;
        }

        //Applicant fname2=1 by pressing key on textbox 
        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            fname2 = 1;
        }

        //Applicant fname3=1 by pressing key on textbox 
        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            fname3 = 1;
        }

        //Applicant mname1=1 by pressing key on textbox 
        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            mname1 = 1;
        }

        //Applicant mname2=1 by pressing key on textbox 
        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            mname2 = 1;
        }

        //Applicant mname3=1 by pressing key on textbox 
        private void textBox22_KeyPress(object sender, KeyPressEventArgs e)
        {
            mname3 = 1;
        }

        //Generating Teaching staff ID by click Generate button
        private void button3_Click(object sender, EventArgs e)
        {
            sequencecurval();
            deptID();
            textBox10.Text = "TS" + "/" + departid + "/" + dateTimePicker2.Value.Date.ToString("yy") + "/" + teachcurvalue.ToString();
        }

        //Getting current value from student sequence , person sequence and exam sequence
        void sequencecurval()
        {
            //Getting current value from student sequence , person sequence and exam sequence
            string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "select TEACHERSEQ.nextval from DUAL";
            string query1 = "drop sequence TEACHERSEQ";
            string query2 = "select PERSONSEQ.nextval from DUAL";
            string query3 = "drop sequence PERSONSEQ";

            OracleCommand cmd = new OracleCommand(query, con);
            OracleCommand cmd1 = new OracleCommand(query1, con);
            OracleCommand cmd2 = new OracleCommand(query2, con);
            OracleCommand cmd3 = new OracleCommand(query3, con);
            OracleDataReader rdr, rdr1,rdr2,rdr3;
            try
            {
                con.Open();
                rdr = cmd.ExecuteReader();
                rdr1 = cmd1.ExecuteReader();
                rdr2 = cmd2.ExecuteReader();
                rdr3 = cmd3.ExecuteReader();
                rdr.Read();
                rdr1.Read();
                rdr2.Read();
                rdr3.Read();
                teachcurvalue = rdr.GetInt32(0);
                percurvalue = rdr2.GetInt32(0);
                sequencecreate();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Creating Student and Person,Exam sequence
        void sequencecreate()
        {
            // Creating Student and Person sequence
            string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "create sequence TEACHERSEQ minvalue 1 maxvalue 999999 start with " + teachcurvalue + " increment by 1 nocycle order NOCACHE";
            string query1 = "create sequence PERSONSEQ minvalue 1 maxvalue 999999 start with " + percurvalue + " increment by 1 nocycle order NOCACHE";

            OracleCommand cmd = new OracleCommand(query, con);
            OracleCommand cmd1 = new OracleCommand(query1, con);
            OracleDataReader rdr,rdr1;
            try
            {
                con.Open();
                rdr = cmd.ExecuteReader();
                rdr1 = cmd1.ExecuteReader();
                rdr.Read();
                rdr1.Read();
                con.Close();
            }

            catch (Exception ex)
            {
               
                MessageBox.Show(ex.Message);
            }
        }

        //Creating Next sequence value
        void sequencenextval()
        {
            //Creating Next sequence value
            string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "Select TEACHERSEQ.nextval from DUAL";
            string query1 = "select PERSONSEQ.nextval from DUAL";

            OracleCommand cmd = new OracleCommand(query, con);
            OracleCommand cmd1 = new OracleCommand(query1, con);
            OracleDataReader rdr,rdr1;
            try
            {
                con.Open();
                rdr = cmd.ExecuteReader();
                rdr1 = cmd1.ExecuteReader();
                rdr.Read();
                rdr1.Read();
                MessageBox.Show("Record Inserted Successfully");
                Teaching_Staff_Admission tsa = new Teaching_Staff_Admission();
                this.Hide();
                tsa.ShowDialog();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                del();
            }
        }

        //Retrieving DepartmentID from Combobox1
        void deptID()
        {
            //Retrieving DepartmentID from Combobox1

            string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "Select deptId from Department where deptname='" + comboBox1.Text + "'";

            OracleCommand cmd = new OracleCommand(query, con);
            OracleDataReader rdr;
            try
            {
                con.Open();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                departid = rdr.GetString(0);
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Delete in case exception
        void del()
        {
            try
            {
                string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
                OracleConnection con = new OracleConnection(str);
                string query = null;
                query = "delete PERSON where pid='" + percurvalue + "'";
                OracleCommand cmd = new OracleCommand(query, con);
                OracleDataReader rdr;
                con.Open();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // pincode only number accepted
        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            // pincode only number accepted
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        // phone no only number accepted
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // phone no only number accepted
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        // Salary only number accepted
        private void textBox25_KeyPress(object sender, KeyPressEventArgs e)
        {
            // phone no only number accepted
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        //making all label null after clicking submit button
        void labelnull()
        {
            label61.Text = null;
            label61.Visible = false;
            label64.Text = null;
            label64.Visible = false;
            label65.Text = null;
            label65.Visible = false;
            label17.Text = null;
            label17.Visible = false;
            label33.Text = null;
            label33.Visible = false;
            label34.Text = null;
            label34.Visible = false;
            label66.Text = null;
            label66.Visible = false;
            label67.Text = null;
            label67.Visible = false;
            label68.Text = null;
            label68.Visible = false;
            label69.Text = null;
            label69.Visible = false;
            label70.Text = null;
            label70.Visible = false;
            label71.Text = null;
            label71.Visible = false;
            label72.Text = null;
            label72.Visible = false;
            label73.Text = null;
            label73.Visible = false;
            label74.Text = null;
            label74.Visible = false;
            label75.Text = null;
            label75.Visible = false;
            label76.Text = null;
            label76.Visible = false;
            label77.Text = null;
            label77.Visible = false;
            label78.Text = null;
            label78.Visible = false;
            label79.Text = null;
            label79.Visible = false;
            label80.Text = null;
            label80.Visible = false;
            label81.Text = null;
            label81.Visible = false;
            label82.Text = null;
            label82.Visible = false;
        }

        // insert data by clicking submit button and calling labelnull() and personinsert()
        private void button5_Click(object sender, EventArgs e)
        {
            // insert data by clicking submit button

            //checking all mandatory field
            int x = 0;

            //Making all labe null and visible false
            labelnull();
            // Checking TextBox is Empty or Not
            if (String.IsNullOrWhiteSpace(comboBox1.Text))
            {
                label61.Visible = true;
                label61.Text = "Department name cannot be empty";
                x = 1;
            }
            if (String.IsNullOrWhiteSpace(comboBox2.Text))
            {
                label17.Visible = true;
                label17.Text = "Designation cannot be empty";
                x = 1;
            }
            if (String.IsNullOrWhiteSpace(textBox25.Text))
            {
                label34.Visible = true;
                label34.Text = "Salary cannot be empty ";
                x = 1;
            }
            if (String.IsNullOrWhiteSpace(textBox10.Text))
            {
                label64.Visible = true;
                label64.Text = "Teacher ID must be Generated";
                x = 1;
            }
            if (picpath == null)
            {
                label65.Visible = true;
                label65.Text = "Upload a Photograph";
                x = 1;
            }
            //Applicant name
            if (String.IsNullOrWhiteSpace(textBox1.Text) || String.IsNullOrWhiteSpace(textBox5.Text) || name1 == 0 || name3 == 0)
            {
                label66.Visible = true;
                label66.Text = "Insert Name";
                x = 1;
            }
            if (String.IsNullOrWhiteSpace(textBox13.Text))
            {
                label67.Visible = true;
                label67.Text = "Select the Date OF Birth";
                x = 1;
            }
            //Nationality
            if (String.IsNullOrWhiteSpace(textBox11.Text))
            {
                label68.Visible = true;
                label68.Text = "Some Fields cannot be empty";
                x = 1;
            }
            //Religion
            if (String.IsNullOrWhiteSpace(textBox12.Text))
            {
                label69.Visible = true;
                label69.Text = "Some Fields cannot be empty";
                x = 1;
            }
            //Caste
            if (String.IsNullOrWhiteSpace(comboBox4.Text))
            {
                label70.Visible = true;
                label70.Text = "Some Fields cannot be empty";
                x = 1;
            }
            //BloodGroup
            if (String.IsNullOrWhiteSpace(comboBox5.Text))
            {
                label71.Visible = true;
                label71.Text = "Some Fields cannot be empty";
                x = 1;
            }
            //Gender
            if (gender == ' ')
            {
                label72.Visible = true;
                label72.Text = "Some Fields cannnot be empty";
                x = 1;
            }
            //Father name
            if (String.IsNullOrWhiteSpace(textBox6.Text) || String.IsNullOrWhiteSpace(textBox8.Text) || fname1 == 0 || fname3 == 0)
            {
                label73.Visible = true;
                label73.Text = "Insert Father Name";
                x = 1;
            }
            //Mother name
            if (String.IsNullOrWhiteSpace(textBox9.Text) || String.IsNullOrWhiteSpace(textBox22.Text) || mname1 == 0 || mname3 == 0)
            {
                label74.Visible = true;
                label74.Text = "Insert Mother Name";
                x = 1;
            }
            //Address
            if (String.IsNullOrWhiteSpace(textBox14.Text))
            {
                label75.Visible = true;
                label75.Text = "Some Fields cannot be empty";
                x = 1;
            }
            //District
            if (String.IsNullOrWhiteSpace(textBox16.Text))
            {
                label76.Visible = true;
                label76.Text = "Some Fields cannot be empty";
                x = 1;
            }
            //State
            if (String.IsNullOrWhiteSpace(textBox17.Text))
            {
                label77.Visible = true;
                label77.Text = "Some Fields cannot be empty";
                x = 1;
            }
            //Pincode
            if (String.IsNullOrWhiteSpace(textBox18.Text))
            {
                label78.Visible = true;
                label78.Text = "Some Fields cannot be empty";
                x = 1;
            }
            //PostOffice
            if (String.IsNullOrWhiteSpace(textBox20.Text))
            {
                label79.Visible = true;
                label79.Text = "Some Fields cannot be empty";
                x = 1;
            }
            //Email
            if (String.IsNullOrWhiteSpace(textBox21.Text))
            {
                label80.Visible = true;
                label80.Text = "Some Fields cannot be empty";
                x = 1;
            }
            //Phone no
            if (String.IsNullOrWhiteSpace(textBox3.Text))
            {
                label81.Visible = true;
                label81.Text = "Some Fields cannot be empty";
                x = 1;
            }
            //Qualification
            if(String.IsNullOrWhiteSpace(textBox2.Text))
            {
                label33.Visible = true;
                label33.Text = "Some Fields cannot be empty";
                x = 1;
            }


            if (x == 0)
            {
                personinsert();
            }
            else if (x == 1)
            {
                label82.Visible = true;
                label82.Text = "Mandatory * Field Must Be Filled";
            }




        }

        //assign gender = m 
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // Radio Button
            gender = 'M';
        }


        //assign gender=f
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //Radion Button
            gender = 'F';
        }

        //Clicking browse button to select image
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opd = new OpenFileDialog();
                opd.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png";
                if (opd.ShowDialog() == DialogResult.OK)
                {
                    picpath = opd.FileName.ToString();
                    pictureBox1.ImageLocation = picpath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // calculating age and display in age box
        void calculateage()
        {
            // calculating age and display in age box

            string bdate = dateTimePicker1.Value.Date.ToString("dd");
            string bmonth = dateTimePicker1.Value.Date.ToString("MM");
            string byear = dateTimePicker1.Value.Date.ToString("yyyy");
            string cdate = DateTime.Now.ToString("dd");
            string cmonth = DateTime.Now.ToString("MM");
            string cyear = DateTime.Now.ToString("yyyy");

            int bdate1 = Convert.ToInt32(bdate);
            int bmonth1 = Convert.ToInt32(bmonth);
            int byear1 = Convert.ToInt32(byear);
            int cdate1 = Convert.ToInt32(cdate);
            int cmonth1 = Convert.ToInt32(cmonth);
            int cyear1 = Convert.ToInt32(cyear);

            int age = 0;

            if (cdate1 < bdate1)
                cmonth1 = cmonth1 - 1;
            if (cmonth1 < bmonth1)
                cyear1 = cyear1 - 1;
            age = cyear1 - byear1;

            textBox13.Text = age.ToString();

        }

        // Calling calculateage() from datetimepicker 1
        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            // Calling calculate age function from datetimepicker 1
            if (i == 1)
                calculateage();
        }

        //inserting into Teaching_Staff table and calling deptID() and coursedu() to generate stuid and calling courseinsert(stuid)
        void teacherinsert()
        {
            //inserting into Teaching_staff table
            deptID();
            string Teachid = "TS" + "/" + departid + "/" + dateTimePicker2.Value.Date.ToString("yy") + "/";

            try
            {
                string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
                OracleConnection con = new OracleConnection(str);
                string query = null;
                if (String.IsNullOrWhiteSpace(textBox24.Text) && String.IsNullOrWhiteSpace(textBox23.Text))
                    query = "insert into TEACHING_STAFF values('"+percurvalue+"',concat('" + Teachid + "','" + teachcurvalue + "'),'"+comboBox2.Text+"','"+textBox25.Text+"','"+textBox2.Text+"',null,null,'"+departid+"')";
                else if(String.IsNullOrWhiteSpace(textBox24.Text))
                    query = "insert into TEACHING_STAFF values('" + percurvalue + "',concat('" + Teachid + "','" + teachcurvalue + "'),'" + comboBox2.Text + "','" + textBox25.Text + "','" + textBox2.Text + "','" + textBox23.Text + "',null,'" + departid + "')";
                else if(String.IsNullOrWhiteSpace(textBox23.Text))
                    query = "insert into TEACHING_STAFF values('" + percurvalue + "',concat('" + Teachid + "','" + teachcurvalue + "'),'" + comboBox2.Text + "','" + textBox25.Text + "','" + textBox2.Text + "',null,'" + textBox24.Text + "','" + departid + "')";
                else
                    query = "insert into TEACHING_STAFF values('" + percurvalue + "',concat('" + Teachid + "','" + teachcurvalue + "'),'" + comboBox2.Text + "','" + textBox25.Text + "','" + textBox2.Text + "','" + textBox23.Text + "','" + textBox24.Text + "','" + departid + "')";

                OracleCommand cmd = new OracleCommand(query, con);
                OracleDataReader rdr;
                con.Open();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                sequencenextval();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                del();
            }

        }

        // Insert data in Person table and calling sequencecurval() and studentinsert()
        void personinsert()
        {
            // Insert data in Person table

            try
            {
                sequencecurval();
                string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
                OracleConnection con = new OracleConnection(str);

                //image insert
                byte[] imageBt = null;
                FileStream fstream = new FileStream(picpath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fstream);
                imageBt = br.ReadBytes((int)fstream.Length);

                //inserting into Person table
                string query = null;

                //checking mname,fmname,mmname,locality
                if ((name2 == 0 || String.IsNullOrWhiteSpace(textBox4.Text)) && (fname2 == 0 || String.IsNullOrWhiteSpace(textBox7.Text)) && (mname2 == 0 || String.IsNullOrWhiteSpace(textBox19.Text)) && String.IsNullOrWhiteSpace(textBox15.Text))
                {
                    query = "insert into person values('" + percurvalue + "','" + dateTimePicker2.Value.Date.ToString("dd-MMM-yyyy") + "','" + textBox1.Text + "',null," +
                                        "'" + textBox5.Text + "','" + textBox6.Text + "',null,'" + textBox8.Text + "','" + textBox9.Text + "',null,'" + textBox22.Text + "'," +
                                        "'" + textBox11.Text + "','" + textBox17.Text + "','" + textBox16.Text + "','" + textBox18.Text + "','" + textBox20.Text + "','" + textBox14.Text + "',null," +
                                        "'" + textBox3.Text + "','" + textBox21.Text + "','" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "','" + comboBox5.Text + "','" + gender + "','" + textBox12.Text + "'," +
                                        "'" + comboBox4.Text + "',:IMG)";
                }
                //Checking mname,fmname,mmname
                else if ((name2 == 0 || String.IsNullOrWhiteSpace(textBox4.Text)) && (fname2 == 0 || String.IsNullOrWhiteSpace(textBox7.Text)) && (mname2 == 0 || String.IsNullOrWhiteSpace(textBox19.Text)))
                {
                    query = "insert into person values('" + percurvalue + "','" + dateTimePicker2.Value.Date.ToString("dd-MMM-yyyy") + "','" + textBox1.Text + "',null," +
                                       "'" + textBox5.Text + "','" + textBox6.Text + "',null,'" + textBox8.Text + "','" + textBox9.Text + "',null,'" + textBox22.Text + "'," +
                                       "'" + textBox11.Text + "','" + textBox17.Text + "','" + textBox16.Text + "','" + textBox18.Text + "','" + textBox20.Text + "','" + textBox14.Text + "','" + textBox15.Text + "'," +
                                       "'" + textBox3.Text + "','" + textBox21.Text + "','" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "','" + comboBox5.Text + "','" + gender + "','" + textBox12.Text + "'," +
                                       "'" + comboBox4.Text + "',:IMG)";
                }
                //Checking mname,fmname,locality
                else if ((name2 == 0 || String.IsNullOrWhiteSpace(textBox4.Text)) && (fname2 == 0 || String.IsNullOrWhiteSpace(textBox7.Text)) && String.IsNullOrWhiteSpace(textBox15.Text))
                {
                    query = "insert into person values('" + percurvalue + "','" + dateTimePicker2.Value.Date.ToString("dd-MMM-yyyy") + "','" + textBox1.Text + "',null," +
                                         "'" + textBox5.Text + "','" + textBox6.Text + "',null,'" + textBox8.Text + "','" + textBox9.Text + "','" + textBox19.Text + "','" + textBox22.Text + "'," +
                                         "'" + textBox11.Text + "','" + textBox17.Text + "','" + textBox16.Text + "','" + textBox18.Text + "','" + textBox20.Text + "','" + textBox14.Text + "',null," +
                                         "'" + textBox3.Text + "','" + textBox21.Text + "','" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "','" + comboBox5.Text + "','" + gender + "','" + textBox12.Text + "'," +
                                         "'" + comboBox4.Text + "',:IMG)";
                }
                //checking mname,mmname,locality
                else if ((name2 == 0 || String.IsNullOrWhiteSpace(textBox4.Text)) && (mname2 == 0 || String.IsNullOrWhiteSpace(textBox19.Text)) && String.IsNullOrWhiteSpace(textBox15.Text))
                {
                    query = "insert into person values('" + percurvalue + "','" + dateTimePicker2.Value.Date.ToString("dd-MMM-yyyy") + "','" + textBox1.Text + "',null," +
                                        "'" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "',null,'" + textBox22.Text + "'," +
                                        "'" + textBox11.Text + "','" + textBox17.Text + "','" + textBox16.Text + "','" + textBox18.Text + "','" + textBox20.Text + "','" + textBox14.Text + "',null," +
                                        "'" + textBox3.Text + "','" + textBox21.Text + "','" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "','" + comboBox5.Text + "','" + gender + "','" + textBox12.Text + "'," +
                                        "'" + comboBox4.Text + "',:IMG)";
                }
                //checking fmname,mmname,locality
                else if ((fname2 == 0 || String.IsNullOrWhiteSpace(textBox7.Text)) && (mname2 == 0 || String.IsNullOrWhiteSpace(textBox19.Text)) && String.IsNullOrWhiteSpace(textBox15.Text))
                {
                    query = "insert into person values('" + percurvalue + "','" + dateTimePicker2.Value.Date.ToString("dd-MMM-yyyy") + "','" + textBox1.Text + "','" + textBox4.Text + "'," +
                                       "'" + textBox5.Text + "','" + textBox6.Text + "',null,'" + textBox8.Text + "','" + textBox9.Text + "',null,'" + textBox22.Text + "'," +
                                       "'" + textBox11.Text + "','" + textBox17.Text + "','" + textBox16.Text + "','" + textBox18.Text + "','" + textBox20.Text + "','" + textBox14.Text + "',null," +
                                       "'" + textBox3.Text + "','" + textBox21.Text + "','" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "','" + comboBox5.Text + "','" + gender + "','" + textBox12.Text + "'," +
                                       "'" + comboBox4.Text + "',:IMG)";
                }
                //Checking Applicant Middle Name and Father Middle Name
                else if ((name2 == 0 || String.IsNullOrWhiteSpace(textBox4.Text)) && (fname2 == 0 || String.IsNullOrWhiteSpace(textBox7.Text)))
                {
                    query = "insert into person values('" + percurvalue + "','" + dateTimePicker2.Value.Date.ToString("dd-MMM-yyyy") + "','" + textBox1.Text + "',null," +
                                        "'" + textBox5.Text + "','" + textBox6.Text + "',null,'" + textBox8.Text + "','" + textBox9.Text + "','" + textBox19.Text + "','" + textBox22.Text + "'," +
                                        "'" + textBox11.Text + "','" + textBox17.Text + "','" + textBox16.Text + "','" + textBox18.Text + "','" + textBox20.Text + "','" + textBox14.Text + "','" + textBox15.Text + "'," +
                                        "'" + textBox3.Text + "','" + textBox21.Text + "','" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "','" + comboBox5.Text + "','" + gender + "','" + textBox12.Text + "'," +
                                        "'" + comboBox4.Text + "',:IMG)";
                }
                //Checking Applicant Middle Name and Mother Middle Name
                else if ((name2 == 0 || String.IsNullOrWhiteSpace(textBox4.Text)) && (mname2 == 0 || String.IsNullOrWhiteSpace(textBox19.Text)))
                {
                    query = "insert into person values('" + percurvalue + "','" + dateTimePicker2.Value.Date.ToString("dd-MMM-yyyy") + "','" + textBox1.Text + "',null," +
                                         "'" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "',null,'" + textBox22.Text + "'," +
                                         "'" + textBox11.Text + "','" + textBox17.Text + "','" + textBox16.Text + "','" + textBox18.Text + "','" + textBox20.Text + "','" + textBox14.Text + "','" + textBox15.Text + "'," +
                                         "'" + textBox3.Text + "','" + textBox21.Text + "','" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "','" + comboBox5.Text + "','" + gender + "','" + textBox12.Text + "'," +
                                         "'" + comboBox4.Text + "',:IMG)";
                }
                //Checking Father Middle Name and Mother Middle Name
                else if ((fname2 == 0 || String.IsNullOrWhiteSpace(textBox7.Text)) && (mname2 == 0 || String.IsNullOrWhiteSpace(textBox19.Text)))
                {
                    query = "insert into person values('" + percurvalue + "','" + dateTimePicker2.Value.Date.ToString("dd-MMM-yyyy") + "','" + textBox1.Text + "','" + textBox4.Text + "'," +
                                    "'" + textBox5.Text + "','" + textBox6.Text + "',null,'" + textBox8.Text + "','" + textBox9.Text + "',null,'" + textBox22.Text + "'," +
                                    "'" + textBox11.Text + "','" + textBox17.Text + "','" + textBox16.Text + "','" + textBox18.Text + "','" + textBox20.Text + "','" + textBox14.Text + "','" + textBox15.Text + "'," +
                                    "'" + textBox3.Text + "','" + textBox21.Text + "','" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "','" + comboBox5.Text + "','" + gender + "','" + textBox12.Text + "'," +
                                    "'" + comboBox4.Text + "',:IMG)";
                }
                //checking fmname,locality
                else if ((fname2 == 0 || String.IsNullOrWhiteSpace(textBox7.Text)) && String.IsNullOrWhiteSpace(textBox15.Text))
                {
                    query = "insert into person values('" + percurvalue + "','" + dateTimePicker2.Value.Date.ToString("dd-MMM-yyyy") + "','" + textBox1.Text + "','" + textBox4.Text + "'," +
                                   "'" + textBox5.Text + "','" + textBox6.Text + "',null,'" + textBox8.Text + "','" + textBox9.Text + "','" + textBox19.Text + "','" + textBox22.Text + "'," +
                                   "'" + textBox11.Text + "','" + textBox17.Text + "','" + textBox16.Text + "','" + textBox18.Text + "','" + textBox20.Text + "','" + textBox14.Text + "',null," +
                                   "'" + textBox3.Text + "','" + textBox21.Text + "','" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "','" + comboBox5.Text + "','" + gender + "','" + textBox12.Text + "'," +
                                   "'" + comboBox4.Text + "',:IMG)";
                }
                //checking mmname,locality
                else if ((mname2 == 0 || String.IsNullOrWhiteSpace(textBox19.Text)) && String.IsNullOrWhiteSpace(textBox15.Text))
                {
                    query = "insert into person values('" + percurvalue + "','" + dateTimePicker2.Value.Date.ToString("dd-MMM-yyyy") + "','" + textBox1.Text + "','" + textBox4.Text + "'," +
                                   "'" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "',null,'" + textBox22.Text + "'," +
                                   "'" + textBox11.Text + "','" + textBox17.Text + "','" + textBox16.Text + "','" + textBox18.Text + "','" + textBox20.Text + "','" + textBox14.Text + "',null," +
                                   "'" + textBox3.Text + "','" + textBox21.Text + "','" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "','" + comboBox5.Text + "','" + gender + "','" + textBox12.Text + "'," +
                                   "'" + comboBox4.Text + "',:IMG)";
                }
                //checking mname,locality
                else if ((name2 == 0 || String.IsNullOrWhiteSpace(textBox4.Text)) && String.IsNullOrWhiteSpace(textBox15.Text))
                {
                    query = "insert into person values('" + percurvalue + "','" + dateTimePicker2.Value.Date.ToString("dd-MMM-yyyy") + "','" + textBox1.Text + "',null," +
                                   "'" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox19.Text + "','" + textBox22.Text + "'," +
                                   "'" + textBox11.Text + "','" + textBox17.Text + "','" + textBox16.Text + "','" + textBox18.Text + "','" + textBox20.Text + "','" + textBox14.Text + "',null," +
                                   "'" + textBox3.Text + "','" + textBox21.Text + "','" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "','" + comboBox5.Text + "','" + gender + "','" + textBox12.Text + "'," +
                                   "'" + comboBox4.Text + "',:IMG)";
                }
                //Checking Applicant Middle Name
                else if (name2 == 0 || String.IsNullOrWhiteSpace(textBox4.Text))
                {
                    query = "insert into person values('" + percurvalue + "','" + dateTimePicker2.Value.Date.ToString("dd-MMM-yyyy") + "','" + textBox1.Text + "',null," +
                                        "'" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox19.Text + "','" + textBox22.Text + "'," +
                                        "'" + textBox11.Text + "','" + textBox17.Text + "','" + textBox16.Text + "','" + textBox18.Text + "','" + textBox20.Text + "','" + textBox14.Text + "','" + textBox15.Text + "'," +
                                        "'" + textBox3.Text + "','" + textBox21.Text + "','" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "','" + comboBox5.Text + "','" + gender + "','" + textBox12.Text + "'," +
                                        "'" + comboBox4.Text + "',:IMG)";
                }
                // Checking Applicant Father Middle Name
                else if (fname2 == 0 || String.IsNullOrWhiteSpace(textBox7.Text))
                {
                    query = "insert into person values('" + percurvalue + "','" + dateTimePicker2.Value.Date.ToString("dd-MMM-yyyy") + "','" + textBox1.Text + "','" + textBox4.Text + "'," +
                                       "'" + textBox5.Text + "','" + textBox6.Text + "',null,'" + textBox8.Text + "','" + textBox9.Text + "','" + textBox19.Text + "','" + textBox22.Text + "'," +
                                       "'" + textBox11.Text + "','" + textBox17.Text + "','" + textBox16.Text + "','" + textBox18.Text + "','" + textBox20.Text + "','" + textBox14.Text + "','" + textBox15.Text + "'," +
                                       "'" + textBox3.Text + "','" + textBox21.Text + "','" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "','" + comboBox5.Text + "','" + gender + "','" + textBox12.Text + "'," +
                                       "'" + comboBox4.Text + "',:IMG)";
                }
                //Checking Applicant Mother Middle Name
                else if (mname2 == 0 || String.IsNullOrWhiteSpace(textBox19.Text))
                {
                    query = "insert into person values('" + percurvalue + "','" + dateTimePicker2.Value.Date.ToString("dd-MMM-yyyy") + "','" + textBox1.Text + "','" + textBox4.Text + "'," +
                                    "'" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "',null,'" + textBox22.Text + "'," +
                                    "'" + textBox11.Text + "','" + textBox17.Text + "','" + textBox16.Text + "','" + textBox18.Text + "','" + textBox20.Text + "','" + textBox14.Text + "','" + textBox15.Text + "'," +
                                    "'" + textBox3.Text + "','" + textBox21.Text + "','" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "','" + comboBox5.Text + "','" + gender + "','" + textBox12.Text + "'," +
                                    "'" + comboBox4.Text + "',:IMG)";
                }
                //checking Locality
                else if (String.IsNullOrWhiteSpace(textBox15.Text))
                {
                    query = "insert into person values('" + percurvalue + "','" + dateTimePicker2.Value.Date.ToString("dd-MMM-yyyy") + "','" + textBox1.Text + "','" + textBox4.Text + "'," +
                                    "'" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox19.Text + "','" + textBox22.Text + "'," +
                                    "'" + textBox11.Text + "','" + textBox17.Text + "','" + textBox16.Text + "','" + textBox18.Text + "','" + textBox20.Text + "','" + textBox14.Text + "',null," +
                                    "'" + textBox3.Text + "','" + textBox21.Text + "','" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "','" + comboBox5.Text + "','" + gender + "','" + textBox12.Text + "'," +
                                    "'" + comboBox4.Text + "',:IMG)";
                }
                // All Fillup
                else
                {
                    query = "insert into person values('" + percurvalue + "','" + dateTimePicker2.Value.Date.ToString("dd-MMM-yyyy") + "','" + textBox1.Text + "','" + textBox4.Text + "'," +
                                    "'" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox19.Text + "','" + textBox22.Text + "'," +
                                    "'" + textBox11.Text + "','" + textBox17.Text + "','" + textBox16.Text + "','" + textBox18.Text + "','" + textBox20.Text + "','" + textBox14.Text + "','" + textBox15.Text + "'," +
                                    "'" + textBox3.Text + "','" + textBox21.Text + "','" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "','" + comboBox5.Text + "','" + gender + "','" + textBox12.Text + "'," +
                                    "'" + comboBox4.Text + "',:IMG)";
                }

                OracleCommand cmd = new OracleCommand(query, con);
                cmd.Parameters.Add(new OracleParameter(":IMG", imageBt));
                con.Open();
                OracleDataReader rdr;
                rdr = cmd.ExecuteReader();
                rdr.Read();
                teacherinsert();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}

