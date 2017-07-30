using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Text.RegularExpressions;

namespace JIST
{
    public partial class Update : Form
    {
        int i,pid;
        string picpath, stuid;
        char gender;
        int em, m, p;

        //constructor calling and initializing
        public Update()
        {
            InitializeComponent();
            i = 0;
            connection();
            DateTimepicker();
            department();
            disable();
            em = m = p = 0;
            dataGridView1.MultiSelect = false;
            label16.Visible = false;
            studentdash.Normalcolor = Color.FromArgb(252, 86, 83);

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

        //checking minimum phone number
        private void textBox14_Leave(object sender, EventArgs e)
        {
            string pattern = "^[0-9]{10}$";
            Regex obj = new Regex(pattern);
            if (obj.IsMatch(textBox14.Text))
            {
                m = 0;
                errorProvider1.Clear();
                if (em == 0 && m == 0 && p == 0)
                    button3.Enabled = true;
            }
            else
            {
                errorProvider1.SetError(this.textBox14, "Enter a valid number");
                button3.Enabled = false;
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
                    button3.Enabled = true;
            }
            else
            {
                errorProvider2.SetError(this.textBox18, "Enter a valid pincode");
                button3.Enabled = false;
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
                    button3.Enabled = true;
            }
            else
            {
                errorProvider3.SetError(this.textBox21, "Please provide a valid email address");
                button3.Enabled = false;
                em = 1;
                return;
            }

        }


        //Disable all button and textfield 
        void disable()
        {
            button2.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox10.Enabled = false;
            dateTimePicker1.Enabled = false;
            textBox11.Enabled = false;
            textBox12.Enabled = false;
            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            textBox3.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
            textBox19.Enabled = false;
            textBox22.Enabled = false;
            textBox23.Enabled = false;
            textBox15.Enabled = false;
            textBox16.Enabled = false;
            textBox17.Enabled = false;
            textBox18.Enabled = false;
            textBox20.Enabled = false;
            textBox21.Enabled = false;
            textBox14.Enabled = false;
            button3.Enabled = false;
        }

        //Enable all button and textfield 
        void enable()
        {
            button2.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox10.Enabled = true;
            dateTimePicker1.Enabled = true;
            textBox11.Enabled = true;
            textBox12.Enabled = true;
            comboBox4.Enabled = true;
            comboBox5.Enabled = true;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            textBox3.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;
            textBox19.Enabled = true;
            textBox22.Enabled = true;
            textBox23.Enabled = true;
            textBox15.Enabled = true;
            textBox16.Enabled = true;
            textBox17.Enabled = true;
            textBox18.Enabled = true;
            textBox20.Enabled = true;
            textBox21.Enabled = true;
            textBox14.Enabled = true;
            button3.Enabled = true;
        }

        //Making Custom DateTimepicker1
        void DateTimepicker()
        {

            dateTimePicker1.CustomFormat = "dd-MMM-yyyy";
            dateTimePicker1.MaxDate = DateTime.Today.AddYears(-18);
            i = 1;

        }

        //Checking connection
        void connection()
        {
            try
            {
                string str = "DATA SOURCE=localhost:1521/xe;USER ID = IMS; Password=enteryourchoice";
                OracleConnection mycon = new OracleConnection(str);
                mycon.Open();
                mycon.Dispose();
                mycon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

                comboBox1.Items.Add("ALL");
                while (rdr.Read())
                {
                    string dept = rdr.GetString(0);
                    comboBox1.Items.Add(dept);
                }
                con.Dispose();
                con.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Making field empty
        void fieldempty()
        {
            textBox4.Text = null;
            textBox5.Text = null;
            textBox10.Text = null;
            dateTimePicker1.Text = null;
            textBox11.Text = null;
            textBox12.Text = null;
            comboBox4.Text = null;
            comboBox5.Text = null;
            radioButton1.Checked=false;
            radioButton2.Checked = false;
            textBox3.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;
            textBox8.Text = null;
            textBox9.Text = null;
            textBox19.Text = null;
            textBox22.Text = null;
            textBox23.Text = null;
            textBox15.Text = null;
            textBox16.Text = null;
            textBox17.Text = null;
            textBox18.Text = null;
            textBox20.Text = null;
            textBox21.Text = null;
            textBox14.Text = null;
        }

        // insert coursename in combobox2
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // insert coursename in combobox2
            textBox1.Text = null;
            textBox2.Text = null;
            pictureBox1.Image = JIST.Properties.Resources.Users_icon;
            fieldempty();
            disable();
            string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "select coursename from course where deptid=(select deptid from department where deptname='" + comboBox1.Text + "') order by coursename";
            OracleCommand cmd = new OracleCommand(query, con);
            OracleDataReader rdr;
            try
            {
                con.Open();
                rdr = cmd.ExecuteReader();

                comboBox2.Items.Clear();
                comboBox2.Text = null;
                comboBox3.Items.Clear();
                comboBox3.Text = null;
                while (rdr.Read())
                {
                    string coursename = rdr.GetString(0);
                    comboBox2.Items.Add(coursename);
                }
                con.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        //Form closing
        private void Update_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //Back button
        private void button4_Click(object sender, EventArgs e)
        {
            StudentManagement studm = new StudentManagement();
            this.Hide();
            studm.ShowDialog();
        }

        // insert Semester in combobox3
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // insert Semester in combobox3
            textBox1.Text = null;
            textBox2.Text = null;
            pictureBox1.Image = JIST.Properties.Resources.Users_icon;
            fieldempty();
            disable();
            string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "select semno from semester where courseid=(select courseid from course where coursename='" + comboBox2.Text + "' and deptid=(select deptid from department where deptname='" + comboBox1.Text + "')) order by semno";
            OracleCommand cmd = new OracleCommand(query, con);
            OracleDataReader rdr;
            try
            {
               
                con.Open();
               
                rdr = cmd.ExecuteReader();
                comboBox3.Items.Clear();
                comboBox3.Text = null;
                while (rdr.Read())
                {
                    int semno = rdr.GetInt32(0);
                    
                    comboBox3.Items.Add(semno);
                }
                con.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Combobox3 selected
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            pictureBox1.Image = JIST.Properties.Resources.Users_icon;
            fieldempty();
            disable();

        }
        //calling datagrid() when search button click
        private void button1_Click(object sender, EventArgs e)
        {
            //calling datagrid
            datagrid();
        }

        //Loading data in datagridview1
        void datagrid()
        { 
            // Showing Data in DataGridView1 from search button
            textBox1.Text = null;
            textBox2.Text = null;
            string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query=null;
             //Department All
            if (comboBox1.Text == "ALL")
                query = "select sc.stuid as Student_ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,deptname as Department,coursename as Course,currentstatus as Semester from person p,department d,student s,student_course sc,course c where sc.courseid=c.courseid and s.stuid=sc.stuid and d.deptid=s.deptid and p.pid=s.pid order by fname,mname,lname";
            //Non is empty
            else if (String.IsNullOrWhiteSpace(comboBox1.Text) && String.IsNullOrWhiteSpace(comboBox2.Text) && String.IsNullOrWhiteSpace(comboBox3.Text))
            {
               
                query = "select sc.stuid as Student_ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,deptname as Department,coursename as Course,currentstatus as Semester from person p,department d,student s,student_course sc,course c where sc.courseid=c.courseid and s.stuid=sc.stuid and d.deptid=s.deptid and p.pid=s.pid order by fname,mname,lname";
            }
            //course and semester is empty
            else if (String.IsNullOrWhiteSpace(comboBox2.Text) && String.IsNullOrWhiteSpace(comboBox3.Text))
            {
              
                query = "select sc.stuid as Student_ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,deptname as Department,coursename as Course,currentstatus as Semester from person p,department d,student s,student_course sc,course c where sc.courseid=c.courseid and s.stuid=sc.stuid and d.deptid=s.deptid and p.pid=s.pid and d.deptid=(select deptid from department where deptname='" + comboBox1.Text + "') order by fname,mname,lname";
            }
            //Department and Course is empty
            else if (String.IsNullOrWhiteSpace(comboBox2.Text) && String.IsNullOrWhiteSpace(comboBox3.Text))
            {
                
                query = "select sc.stuid as Student_ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,deptname as Department,coursename as Course,currentstatus as Semester from person p,department d,student s,student_course sc,course c where sc.courseid=c.courseid and s.stuid=sc.stuid and d.deptid=s.deptid and p.pid=s.pid and s.currentstatus='" + comboBox3.Text + "' order by fname,mname,lname";
            }
            //Department and Semester is empty
            else if (String.IsNullOrWhiteSpace(comboBox2.Text) && String.IsNullOrWhiteSpace(comboBox3.Text))
            {
                
                query = "select sc.stuid as Student_ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,deptname as Department,coursename as Course,currentstatus as Semester from person p,department d,student s,student_course sc,course c where sc.courseid=c.courseid and s.stuid=sc.stuid and d.deptid=s.deptid and p.pid=s.pid and coursename='" + comboBox2.Text + "' order by fname,mname,lname";
            }
            //Department is empty
           else if (String.IsNullOrWhiteSpace(comboBox1.Text))
            {
              
                query = "select sc.stuid as Student_ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,deptname as Department,coursename as Course,currentstatus as Semester from person p,department d,student s,student_course sc,course c where sc.courseid=c.courseid and s.stuid=sc.stuid and d.deptid=s.deptid and p.pid=s.pid and coursename='" + comboBox2.Text + "' and s.currentstatus='" + comboBox3.Text + "' order by fname,mname,lname";
            }
            //Course is empty
            else if (String.IsNullOrWhiteSpace(comboBox2.Text))
            {
              
                query = "select sc.stuid as Student_ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,deptname as Department,coursename as Course,currentstatus as Semester from person p,department d,student s,student_course sc,course c where sc.courseid=c.courseid and s.stuid=sc.stuid and d.deptid=s.deptid and p.pid=s.pid and d.deptid=(select deptid from department where deptname='" + comboBox1.Text + "') and s.currentstatus='" + comboBox3.Text + "' order by fname,mname,lname";
            }
            //Semester is empty
            else if (String.IsNullOrWhiteSpace(comboBox3.Text))
            {
                
                query = "select sc.stuid as Student_ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,deptname as Department,coursename as Course,currentstatus as Semester from person p,department d,student s,student_course sc,course c where sc.courseid=c.courseid and s.stuid=sc.stuid and d.deptid=s.deptid and p.pid=s.pid and d.deptid=(select deptid from department where deptname='" + comboBox1.Text + "') and coursename='" + comboBox2.Text + "' order by fname,mname,lname";
            }
           
            //Department,course,semester is empty
            else
            {
               
                query = "select sc.stuid as Student_ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,deptname as Department,coursename as Course,currentstatus as Semester from person p,department d,student s,student_course sc,course c where sc.courseid=c.courseid and s.stuid=sc.stuid and d.deptid=s.deptid and p.pid=s.pid and d.deptid=(select deptid from department where deptname='" + comboBox1.Text + "') and coursename='" + comboBox2.Text + "' and s.currentstatus='" + comboBox3.Text + "' order by fname,mname,lname";
            }

            OracleCommand cmd = new OracleCommand(query, con);
         
            try
            {
                OracleDataAdapter oda = new OracleDataAdapter();
                oda.SelectCommand = cmd;
                DataTable dbdataset = new DataTable();
                oda.Fill(dbdataset);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dbdataset;
                dataGridView1.DataSource = bsource;
                this.dataGridView1.Columns["Full_Name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;   
                this.dataGridView1.Columns["Full_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns["Department"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;              
                this.dataGridView1.Columns["Course"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;              
                this.dataGridView1.Columns["Semester"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView1.EnableHeadersVisualStyles = false;
                this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("ARIAL", 9, FontStyle.Bold);
                this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
                this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.MistyRose;
                this.dataGridView1.DefaultCellStyle.BackColor = Color.LightCyan;
                this.dataGridView1.DefaultCellStyle.Font= new Font("ARIAL", 9, FontStyle.Bold);
                this.dataGridView1.DefaultCellStyle.ForeColor = Color.Red;
                if (dataGridView1.Rows.Count > 0)
                    dataGridView1.Rows[0].Selected = false;

                label16.Visible = true;
                label16.Text = "Displaying " + dataGridView1.RowCount + " Record";

                oda.Update(dbdataset);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // Retrieve information from person table
        void personinfo(int pid)
        {
            // Retrieve information from person table

            string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "select * from person where pid='"+pid+"'";
            OracleCommand cmd = new OracleCommand(query, con);
            OracleDataReader rdr;
            try
            {

                con.Open();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                string fname, mname, lname, ffname, fmname, flname, mfname, mmname, mlname, dob, nationality, religion, caste, bg, gender, add, locality, district, state,postoffice,email;
                int pincode;
                long phoneno;
                fname = rdr.GetString(2);
                lname = rdr.GetString(4);
                ffname = rdr.GetString(5);
                flname = rdr.GetString(7);
                mfname = rdr.GetString(8);
                mlname = rdr.GetString(10);
                dob = Convert.ToDateTime(rdr["DOB"]).ToString("dd-MMM-yyyy");
                nationality = rdr.GetString(11);
                religion = rdr.GetString(23);
                caste = rdr.GetString(24);
                bg = rdr.GetString(21);
                gender = rdr.GetString(22);
                add = rdr.GetString(16);
                district = rdr.GetString(13);
                state = rdr.GetString(12);
                postoffice = rdr.GetString(15);
                email = rdr.GetString(19);
                phoneno = rdr.GetInt64(18);
                pincode = rdr.GetInt32(14);
                if (Convert.IsDBNull(rdr["mname"])) { }
                else
                {
                    mname = rdr.GetString(3);
                    textBox5.Text = mname;
                }
                if (Convert.IsDBNull(rdr["fmname"])) { }
                else
                {
                    fmname = rdr.GetString(6);
                    textBox7.Text = fmname;
                }
                if (Convert.IsDBNull(rdr["mmname"])) { }
                else
                {
                    mmname = rdr.GetString(9);
                    textBox19.Text = mmname;
                }
                if (Convert.IsDBNull(rdr["locality"])) { }
                else
                {
                    locality = rdr.GetString(17);
                    textBox15.Text = locality;
                }

                //Show person detail

                textBox4.Text = fname;
                textBox10.Text = lname;
                dateTimePicker1.Text = dob;
                //displaying age
                calculateage();
                textBox11.Text = nationality;
                textBox12.Text = religion;
                comboBox4.Text = caste;
                comboBox5.Text = bg;
                if (gender == "M")
                    radioButton1.Checked = true;
                else if (gender == "F")
                    radioButton2.Checked = true;
                textBox6.Text = ffname;
                textBox8.Text = flname;
                textBox9.Text = mfname;
                textBox22.Text = mlname;
                textBox23.Text = add;
                textBox16.Text = district;
                textBox17.Text = state;
                textBox18.Text = pincode.ToString();
                textBox20.Text = postoffice;
                textBox21.Text = email;
                textBox14.Text = phoneno.ToString();

                //Showing picture in picturebox1
                if (Convert.IsDBNull(rdr["PHOTOGRAPH"]))
                {
                    pictureBox1.Image = JIST.Properties.Resources.Users_icon;
                }
                else
                {
                    byte[] imgg = (byte[])(rdr["PHOTOGRAPH"]);
                    if (imgg == null)
                    {
                        pictureBox1.Image = null;
                    }
                    else
                    {
                        MemoryStream mstream = new MemoryStream(imgg);
                        pictureBox1.Image = System.Drawing.Image.FromStream(mstream);
                        picpath = null;
                    }
                }
                enable();
                con.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Retrieve information from student table and calling personinfo(pid)
        void studentinfo()
        {
            // Retrieve information from student table

            string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "select * from student where stuid='"+stuid+"'";
            OracleCommand cmd = new OracleCommand(query, con);
            OracleDataReader rdr;
            try
            {

                con.Open();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                pid = rdr.GetInt32(1);

                //Making hobby empty
                 textBox3.Text = null;

                if (Convert.IsDBNull(rdr["HOBBY"]))
                {

                }
                else
                {
                  string hobby = rdr.GetString(4);
                    
                    textBox3.Text = hobby;
                }

                personinfo(pid);
                con.Dispose();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //making mname,fmname,mmname and locality null
        void makingnull()
        {
            textBox5.Text = null;
            textBox3.Text = null;
            textBox7.Text = null;
            textBox19.Text = null;
            textBox15.Text = null;
        }

        //datagridview1 record selected and calling makingnull() and studentinfo()
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Select data from datagridview1
            try
            {
                if (e.RowIndex >= 0)
                {

                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    stuid = row.Cells["Student_ID"].Value.ToString();
                    makingnull();
                    studentinfo();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //calculating age
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

        //calling calculateage() when click on datetimepicker1
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Calling calculate age function from datetimepicker 1
            if (i == 1)
                calculateage();
        }

        //select image when click on browse button
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

        //calling studentid() when key pressed on textbox1
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //calling studentid
            studentid();
            label16.Visible = true;
            label16.Text = "Displaying " + dataGridView1.RowCount + " Record";
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                if (dataGridView1.Rows.Count > 0)
                    dataGridView1.Rows[0].Selected = false;
            }
        }

        //Searching through STUDENT ID
        void studentid()
        {
            //Searching through STUDENT ID
            pictureBox1.Image = JIST.Properties.Resources.Users_icon;
            String str = "Data Source=localhost:1521/xe;user id=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "select sc.stuid as Student_ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,deptname as Department,coursename as Course,currentstatus as Semester from person p,department d,student s,student_course sc,course c where sc.courseid=c.courseid and s.stuid=sc.stuid and d.deptid=s.deptid and p.pid=s.pid order by fname,mname,lname";
            OracleCommand cmd = new OracleCommand(query, con);
            // cmd.Parameters.Add("namelike", "%" + textBox2.Text + "%");
            try
            {
                OracleDataAdapter oda = new OracleDataAdapter();
                oda.SelectCommand = cmd;
                DataTable dbt;
                dbt = new DataTable();
                oda.Fill(dbt);
                //BindingSource bsource = new BindingSource();
                //bsource.DataSource = dbt;
                //dataGridView1.DataSource = bsource;
                //oda.Update(dbt);
                DataView DV = new DataView(dbt);
                //DV.RowFilter = "name like '%"+textBox2.Text+"%'";
                DV.RowFilter = string.Format("Student_ID like '{0}%'", textBox1.Text);
                dataGridView1.DataSource = DV;
                this.dataGridView1.Columns["Full_Name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dataGridView1.Columns["Full_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns["Department"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView1.Columns["Course"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView1.Columns["Semester"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView1.EnableHeadersVisualStyles = false;
                this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("ARIAL", 9, FontStyle.Bold);
                this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
                this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.MistyRose;
                this.dataGridView1.DefaultCellStyle.BackColor = Color.LightCyan;
                this.dataGridView1.DefaultCellStyle.Font = new Font("ARIAL", 9, FontStyle.Bold);
                this.dataGridView1.DefaultCellStyle.ForeColor = Color.Red;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //calling studentname() when key pressed on textbox2
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //calling studentname
            studentname();
            label16.Visible = true;
            label16.Text = "Displaying " + dataGridView1.RowCount + " Record";
            if (String.IsNullOrWhiteSpace(textBox2.Text))
            {
                if (dataGridView1.Rows.Count > 0)
                    dataGridView1.Rows[0].Selected = false;
            }
        }

        //Searching through NAME
        void studentname()
        {
            //Searching through NAME
            pictureBox1.Image = JIST.Properties.Resources.Users_icon;
            String str = "Data Source=localhost:1521/xe;user id=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "select sc.stuid as Student_ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,deptname as Department,coursename as Course,currentstatus as Semester from person p,department d,student s,student_course sc,course c where sc.courseid=c.courseid and s.stuid=sc.stuid and d.deptid=s.deptid and p.pid=s.pid order by fname,mname,lname";
            OracleCommand cmd = new OracleCommand(query, con);
            // cmd.Parameters.Add("namelike", "%" + textBox2.Text + "%");
            try
            {
                OracleDataAdapter oda = new OracleDataAdapter();
                oda.SelectCommand = cmd;
                DataTable dbt;
                dbt = new DataTable();
                oda.Fill(dbt);
                //BindingSource bsource = new BindingSource();
                //bsource.DataSource = dbt;
                //dataGridView1.DataSource = bsource;
                //oda.Update(dbt);
                DataView DV = new DataView(dbt);
                //DV.RowFilter = "name like '%"+textBox2.Text+"%'";
                
                //Department,course,semester empty
                if(String.IsNullOrWhiteSpace(comboBox1.Text) && String.IsNullOrWhiteSpace(comboBox2.Text) && String.IsNullOrWhiteSpace(comboBox3.Text))
                    DV.RowFilter = string.Format("Full_Name like '%{0}%'", textBox2.Text);
                //Department all
                else if(comboBox1.Text=="ALL")
                    DV.RowFilter = string.Format("Full_Name like '%{0}%'", textBox2.Text);
                //Course,semester empty
                else if (String.IsNullOrWhiteSpace(comboBox2.Text) && String.IsNullOrWhiteSpace(comboBox3.Text))
                    DV.RowFilter = string.Format("Full_Name like '%{0}%' and Department='{1}'", textBox2.Text, comboBox1.Text);
                //Semester empty
               else if (String.IsNullOrWhiteSpace(comboBox3.Text))
                    DV.RowFilter = string.Format("Full_Name like '%{0}%' and Department='{1}' and Course='{2}'", textBox2.Text, comboBox1.Text, comboBox2.Text);
                //Non empty
                else
                    DV.RowFilter = string.Format("Full_Name like '%{0}%' and Department='{1}' and Course='{2}' and Semester={3}", textBox2.Text, comboBox1.Text, comboBox2.Text, comboBox3.Text);

                dataGridView1.DataSource = DV;
                this.dataGridView1.Columns["Full_Name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dataGridView1.Columns["Full_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns["Department"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView1.Columns["Course"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView1.Columns["Semester"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView1.EnableHeadersVisualStyles = false;
                this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("ARIAL", 9, FontStyle.Bold);
                this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
                this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.MistyRose;
                this.dataGridView1.DefaultCellStyle.BackColor = Color.LightCyan;
                this.dataGridView1.DefaultCellStyle.Font = new Font("ARIAL", 9, FontStyle.Bold);
                this.dataGridView1.DefaultCellStyle.ForeColor = Color.Red;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //making textbox2 content null when click on textbox1
        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox2.Text = null;
            comboBox1.Text = null;
            comboBox2.Text = null;
            comboBox3.Text = null;
        }

        //making textbox1 content null when click on textbox2
        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            comboBox1.Text = null;
            comboBox2.Text = null;
            comboBox3.Text = null;
        }

        //making all label invisible
        void labelnull()
        {
           
            label66.Text = null;
            label66.Visible = false;
            label68.Text = null;
            label68.Visible = false;
            label69.Text = null;
            label69.Visible = false;
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

        // insert data by clicking submit button and calling labelnull() , personupdate()
        private void button3_Click(object sender, EventArgs e)
        {
            // insert data by clicking submit button

            //checking all mandatory field
            int x = 0;

            //Making all labe null and visible false
            labelnull();
            // Checking TextBox is Empty or Not
        
            //Applicant name
            if (String.IsNullOrWhiteSpace(textBox4.Text) || String.IsNullOrWhiteSpace(textBox10.Text))
            {
                label73.Visible = true;
                label73.Text = "Name cannot be empty";
                x = 1;
            }
            //Nationality
            if (String.IsNullOrWhiteSpace(textBox11.Text))
            {
                label66.Visible = true;
                label66.Text = "Some Fields cannot be empty";
                x = 1;
            }
            //Religion
            if (String.IsNullOrWhiteSpace(textBox12.Text))
            {
                label74.Visible = true;
                label74.Text = "Some Fields cannot be empty";
                x = 1;
            }
        
            //Father name
            if (String.IsNullOrWhiteSpace(textBox6.Text) || String.IsNullOrWhiteSpace(textBox8.Text))
            {
                label68.Visible = true;
                label68.Text = "Father Name cannot be empty";
                x = 1;
            }
            //Mother name
            if (String.IsNullOrWhiteSpace(textBox9.Text) || String.IsNullOrWhiteSpace(textBox22.Text))
            {
                label69.Visible = true;
                label69.Text = "Mother Name cannot be empty";
                x = 1;
            }
            //Address
            if (String.IsNullOrWhiteSpace(textBox23.Text))
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
            if (String.IsNullOrWhiteSpace(textBox14.Text))
            {
                label81.Visible = true;
                label81.Text = "Some Fields cannot be empty";
                x = 1;
            }


            if (x == 0)
            {
               personupdate();
            }
            else if (x == 1)
            {
                label82.Visible = true;
                label82.Text = "Mandatory * Field Must Be Filled";
            }
        }

        // phone no only number accepted
        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            // phone no only number accepted
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
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

        //assigning gender M
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //RadionButton 1
            gender = 'M';
        }

        //assigning gender F
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //RadionButton 2
            gender = 'F';
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        //inserting into Student table and calling datagrid(),studentid(),studentname() according to condition
        void studentupdate()
        {
            //inserting into Student table

            try
            {
                string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
                OracleConnection con = new OracleConnection(str);
                string query = null;
                if (String.IsNullOrWhiteSpace(textBox2.Text))
                    query = "update student set hobby=null where stuid='"+stuid+"'";
                else
                    query = "update student set hobby='"+textBox3.Text+"' where stuid='"+stuid+"'";

                OracleCommand cmd = new OracleCommand(query, con);
                OracleDataReader rdr;
                con.Open();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                if (textBox1.Text == null && textBox2.Text == null)
                    datagrid();
                else if (textBox1.Text != null)
                    studentid();
                else if(textBox2.Text!=null)
                    studentname();

                MessageBox.Show("Record Updated Successfully");
                con.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // Inserting data in Person table and calling studentupdate()
        void personupdate()
        {
            // Insert data in Person table

            try
            {
                string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
                OracleConnection con = new OracleConnection(str);

                //Photograph changed from browse option
                if (picpath != null)
                {
                    //image insert
                    byte[] imageBt = null;
                    FileStream fstream = new FileStream(picpath, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fstream);
                    imageBt = br.ReadBytes((int)fstream.Length);

                    //inserting into Person table
                    string query = null;

                    //checking mname,fmname,mmname,locality
                    if ((String.IsNullOrWhiteSpace(textBox5.Text)) && (String.IsNullOrWhiteSpace(textBox7.Text)) && (String.IsNullOrWhiteSpace(textBox19.Text)) && String.IsNullOrWhiteSpace(textBox15.Text))
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname=null,lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname=null,flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                   "mmname=null,mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                   "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality=null,phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                   "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "',PHOTOGRAPH=:IMG where pid='" + pid + "'";
                    }
                    //Checking mname,fmname,mmname
                    else if ((String.IsNullOrWhiteSpace(textBox5.Text)) && (String.IsNullOrWhiteSpace(textBox7.Text)) && (String.IsNullOrWhiteSpace(textBox19.Text)))
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname=null,lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname=null,flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                  "mmname=null,mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                  "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality='" + textBox15.Text + "',phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                  "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "',PHOTOGRAPH=:IMG where pid='" + pid + "'";
                    }
                    //Checking mname,fmname,locality
                    else if ((String.IsNullOrWhiteSpace(textBox5.Text)) && (String.IsNullOrWhiteSpace(textBox7.Text)) && String.IsNullOrWhiteSpace(textBox15.Text))
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname=null,lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname=null,flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                   "mmname='" + textBox19.Text + "',mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                   "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality=null,phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                   "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "',PHOTOGRAPH=:IMG where pid='" + pid + "'";
                    }
                    //checking mname,mmname,locality
                    else if ((String.IsNullOrWhiteSpace(textBox5.Text)) && (String.IsNullOrWhiteSpace(textBox19.Text)) && String.IsNullOrWhiteSpace(textBox15.Text))
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname=null,lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname='" + textBox7.Text + "',flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                   "mmname=null,mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                   "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality=null,phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                   "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "',PHOTOGRAPH=:IMG where pid='" + pid + "'";
                    }
                    //checking fmname,mmname,locality
                    else if ((String.IsNullOrWhiteSpace(textBox7.Text)) && (String.IsNullOrWhiteSpace(textBox19.Text)) && String.IsNullOrWhiteSpace(textBox15.Text))
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname='" + textBox5.Text + "',lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname=null,flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                  "mmname=null,mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                  "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality=null,phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                  "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "',PHOTOGRAPH=:IMG where pid='" + pid + "'";
                    }
                    //Checking Applicant Middle Name and Father Middle Name
                    else if ((String.IsNullOrWhiteSpace(textBox5.Text)) && (String.IsNullOrWhiteSpace(textBox7.Text)))
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname=null,lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname=null,flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                    "mmname='" + textBox19.Text + "',mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                    "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality='" + textBox15.Text + "',phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                    "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "',PHOTOGRAPH=:IMG where pid='" + pid + "'";
                    }
                    //Checking Applicant Middle Name and Mother Middle Name
                    else if ((String.IsNullOrWhiteSpace(textBox5.Text)) && (String.IsNullOrWhiteSpace(textBox19.Text)))
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname=null,lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname='" + textBox7.Text + "',flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                   "mmname=null,mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                   "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality='" + textBox15.Text + "',phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                   "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "',PHOTOGRAPH=:IMG where pid='" + pid + "'";
                    }
                    //Checking Father Middle Name and Mother Middle Name
                    else if ((String.IsNullOrWhiteSpace(textBox7.Text)) && (String.IsNullOrWhiteSpace(textBox19.Text)))
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname='" + textBox5.Text + "',lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname=null,flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                   "mmname=null,mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                   "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality='" + textBox15.Text + "',phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                   "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "',PHOTOGRAPH=:IMG where pid='" + pid + "'";
                    }
                    //checking fmname,locality
                    else if ((String.IsNullOrWhiteSpace(textBox7.Text)) && String.IsNullOrWhiteSpace(textBox15.Text))
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname='" + textBox5.Text + "',lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname=null,flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                   "mmname='" + textBox19.Text + "',mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                   "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality=null,phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                   "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "',PHOTOGRAPH=:IMG where pid='" + pid + "'";
                    }
                    //checking mmname,locality
                    else if ((String.IsNullOrWhiteSpace(textBox19.Text)) && String.IsNullOrWhiteSpace(textBox15.Text))
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname='" + textBox5.Text + "',lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname='" + textBox7.Text + "',flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                   "mmname=null,mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                   "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality=null,phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                   "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "',PHOTOGRAPH=:IMG where pid='" + pid + "'";
                    }
                    //checking mname,locality
                    else if ((String.IsNullOrWhiteSpace(textBox5.Text)) && String.IsNullOrWhiteSpace(textBox15.Text))
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname=null,lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname='" + textBox7.Text + "',flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                   "mmname='" + textBox19.Text + "',mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                   "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality=null,phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                   "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "',PHOTOGRAPH=:IMG where pid='" + pid + "'";
                    }
                    //Checking Applicant Middle Name
                    else if (String.IsNullOrWhiteSpace(textBox5.Text))
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname=null,lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname='" + textBox7.Text + "',flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                    "mmname='" + textBox19.Text + "',mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                    "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality='" + textBox15.Text + "',phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                    "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "',PHOTOGRAPH=:IMG where pid='" + pid + "'";
                    }
                    // Checking Applicant Father Middle Name
                    else if (String.IsNullOrWhiteSpace(textBox7.Text))
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname='" + textBox5.Text + "',lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname=null,flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                  "mmname='" + textBox19.Text + "',mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                  "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality='" + textBox15.Text + "',phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                  "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "',PHOTOGRAPH=:IMG where pid='" + pid + "'";
                    }
                    //Checking Applicant Mother Middle Name
                    else if (String.IsNullOrWhiteSpace(textBox19.Text))
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname='" + textBox5.Text + "',lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname='" + textBox7.Text + "',flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                   "mmname=null,mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                   "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality='" + textBox15.Text + "',phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                   "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "',PHOTOGRAPH=:IMG where pid='" + pid + "'";
                    }
                    //checking Locality
                    else if (String.IsNullOrWhiteSpace(textBox15.Text))
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname='" + textBox5.Text + "',lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname='" + textBox7.Text + "',flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                  "mmname='" + textBox19.Text + "',mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                  "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality=null,phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                  "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "',PHOTOGRAPH=:IMG where pid='" + pid + "'";
                    }
                    // All Fillup
                    else
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname='" + textBox5.Text + "',lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname='" + textBox7.Text + "',flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                   "mmname='" + textBox19.Text + "',mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                   "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality='" + textBox15.Text + "',phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                   "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "',PHOTOGRAPH=:IMG where pid='" + pid + "'";
                    }

                    OracleCommand cmd = new OracleCommand(query, con);
                    cmd.Parameters.Add(new OracleParameter(":IMG", imageBt));
                    con.Open();
                    OracleDataReader rdr;
                    rdr = cmd.ExecuteReader();
                    rdr.Read();
                    studentupdate();
                    con.Dispose();
                    con.Close();
                }
                //Photograph Not changed from browse option
                else
                {
                   

                    //inserting into Person table
                    string query = null;

                    //checking mname,fmname,mmname,locality
                    if ((String.IsNullOrWhiteSpace(textBox5.Text)) && (String.IsNullOrWhiteSpace(textBox7.Text)) && (String.IsNullOrWhiteSpace(textBox19.Text)) && String.IsNullOrWhiteSpace(textBox15.Text))
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname=null,lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname=null,flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                   "mmname=null,mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                   "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality=null,phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                   "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "' where pid='" + pid + "'";
                    }
                    //Checking mname,fmname,mmname
                    else if ((String.IsNullOrWhiteSpace(textBox5.Text)) && (String.IsNullOrWhiteSpace(textBox7.Text)) && (String.IsNullOrWhiteSpace(textBox19.Text)))
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname=null,lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname=null,flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                  "mmname=null,mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                  "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality='" + textBox15.Text + "',phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                  "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "' where pid='" + pid + "'";
                    }
                    //Checking mname,fmname,locality
                    else if ((String.IsNullOrWhiteSpace(textBox5.Text)) && (String.IsNullOrWhiteSpace(textBox7.Text)) && String.IsNullOrWhiteSpace(textBox15.Text))
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname=null,lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname=null,flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                   "mmname='" + textBox19.Text + "',mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                   "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality=null,phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                   "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "' where pid='" + pid + "'";
                    }
                    //checking mname,mmname,locality
                    else if ((String.IsNullOrWhiteSpace(textBox5.Text)) && (String.IsNullOrWhiteSpace(textBox19.Text)) && String.IsNullOrWhiteSpace(textBox15.Text))
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname=null,lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname='" + textBox7.Text + "',flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                   "mmname=null,mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                   "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality=null,phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                   "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "' where pid='" + pid + "'";
                    }
                    //checking fmname,mmname,locality
                    else if ((String.IsNullOrWhiteSpace(textBox7.Text)) && (String.IsNullOrWhiteSpace(textBox19.Text)) && String.IsNullOrWhiteSpace(textBox15.Text))
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname='" + textBox5.Text + "',lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname=null,flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                  "mmname=null,mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                  "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality=null,phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                  "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "' where pid='" + pid + "'";
                    }
                    //Checking Applicant Middle Name and Father Middle Name
                    else if ((String.IsNullOrWhiteSpace(textBox5.Text)) && (String.IsNullOrWhiteSpace(textBox7.Text)))
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname=null,lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname=null,flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                    "mmname='" + textBox19.Text + "',mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                    "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality='" + textBox15.Text + "',phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                    "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "' where pid='" + pid + "'";
                    }
                    //Checking Applicant Middle Name and Mother Middle Name
                    else if ((String.IsNullOrWhiteSpace(textBox5.Text)) && (String.IsNullOrWhiteSpace(textBox19.Text)))
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname=null,lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname='" + textBox7.Text + "',flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                   "mmname=null,mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                   "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality='" + textBox15.Text + "',phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                   "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "' where pid='" + pid + "'";
                    }
                    //Checking Father Middle Name and Mother Middle Name
                    else if ((String.IsNullOrWhiteSpace(textBox7.Text)) && (String.IsNullOrWhiteSpace(textBox19.Text)))
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname='" + textBox5.Text + "',lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname=null,flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                   "mmname=null,mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                   "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality='" + textBox15.Text + "',phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                   "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "' where pid='" + pid + "'";
                    }
                    //checking fmname,locality
                    else if ((String.IsNullOrWhiteSpace(textBox7.Text)) && String.IsNullOrWhiteSpace(textBox15.Text))
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname='" + textBox5.Text + "',lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname=null,flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                   "mmname='" + textBox19.Text + "',mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                   "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality=null,phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                   "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "' where pid='" + pid + "'";
                    }
                    //checking mmname,locality
                    else if ((String.IsNullOrWhiteSpace(textBox19.Text)) && String.IsNullOrWhiteSpace(textBox15.Text))
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname='" + textBox5.Text + "',lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname='" + textBox7.Text + "',flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                   "mmname=null,mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                   "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality=null,phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                   "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "' where pid='" + pid + "'";
                    }
                    //checking mname,locality
                    else if ((String.IsNullOrWhiteSpace(textBox5.Text)) && String.IsNullOrWhiteSpace(textBox15.Text))
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname=null,lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname='" + textBox7.Text + "',flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                   "mmname='" + textBox19.Text + "',mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                   "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality=null,phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                   "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "' where pid='" + pid + "'";
                    }
                    //Checking Applicant Middle Name
                    else if (String.IsNullOrWhiteSpace(textBox5.Text))
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname=null,lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname='" + textBox7.Text + "',flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                    "mmname='" + textBox19.Text + "',mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                    "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality='" + textBox15.Text + "',phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                    "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "' where pid='" + pid + "'";
                    }
                    // Checking Applicant Father Middle Name
                    else if (String.IsNullOrWhiteSpace(textBox7.Text))
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname='" + textBox5.Text + "',lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname=null,flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                  "mmname='" + textBox19.Text + "',mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                  "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality='" + textBox15.Text + "',phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                  "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "' where pid='" + pid + "'";
                    }
                    //Checking Applicant Mother Middle Name
                    else if (String.IsNullOrWhiteSpace(textBox19.Text))
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname='" + textBox5.Text + "',lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname='" + textBox7.Text + "',flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                   "mmname=null,mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                   "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality='" + textBox15.Text + "',phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                   "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "' where pid='" + pid + "'";
                    }
                    //checking Locality
                    else if (String.IsNullOrWhiteSpace(textBox15.Text))
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname='" + textBox5.Text + "',lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname='" + textBox7.Text + "',flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                  "mmname='" + textBox19.Text + "',mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                  "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality=null,phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                  "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "' where pid='" + pid + "'";
                    }
                    // All Fillup
                    else
                    {
                        query = "update person set fname='" + textBox4.Text + "',mname='" + textBox5.Text + "',lname='" + textBox10.Text + "',ffname='" + textBox6.Text + "',fmname='" + textBox7.Text + "',flname='" + textBox8.Text + "',mfname='" + textBox9.Text + "'," +
                                                   "mmname='" + textBox19.Text + "',mlname='" + textBox22.Text + "',nationality='" + textBox11.Text + "',state='" + textBox17.Text + "',district='" + textBox16.Text + "',pincode='" + textBox18.Text + "'," +
                                                   "postoffice='" + textBox20.Text + "',address='" + textBox23.Text + "',locality='" + textBox15.Text + "',phoneno='" + textBox14.Text + "',email='" + textBox21.Text + "'," +
                                                   "dob='" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "',BG='" + comboBox5.Text + "',gender='" + gender + "',RELIGON='" + textBox12.Text + "',caste='" + comboBox4.Text + "' where pid='" + pid + "'";
                    }

                    OracleCommand cmd = new OracleCommand(query, con);
                    con.Open();
                    OracleDataReader rdr;
                    rdr = cmd.ExecuteReader();
                    rdr.Read();
                    studentupdate();
                    con.Dispose();
                    con.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Stopping scrollbar to move up when click on datagridview1
        private void dataGridView1_MouseEnter(object sender, EventArgs e)
        {
            int vs = panel1.VerticalScroll.Value;
            ActiveControl = dataGridView1;
            panel1.VerticalScroll.Value = vs;
        }
    }
}
