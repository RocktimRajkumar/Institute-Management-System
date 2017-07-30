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
    public partial class StaffUpdate : Form
    {
        int i, pid,yr;
        string picpath, id;
        char gender;
        int em,m,p;

        //Constructor calling and intializing
        public StaffUpdate()
        {
            InitializeComponent();
            connection();
            i = 0;
            yr = 0;
            em = m = p = 0;
            DateTimepicker();
            disable();
            textBox24.Enabled = false;
            comboBox1.Enabled = false;
            button1.Enabled = false;
            dataGridView1.MultiSelect = false;
            textBox2.Enabled = false;
            label16.Visible = false;
            staffdash.Normalcolor = Color.FromArgb(252, 86, 83);
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

        //Checking connnection
        void connection()
        {
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
            comboBox3.Enabled = false;
            comboBox6.Enabled = false;
            textBox25.Enabled = false;
            textBox26.Enabled = false;
            textBox27.Enabled = false;
            textBox3.Enabled = false;
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
            comboBox3.Enabled = true;
            comboBox6.Enabled = true;
            textBox25.Enabled = true;
            textBox27.Enabled = true;
            textBox3.Enabled = true;
            button3.Enabled = true;
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
            radioButton1.Checked = false;
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
            comboBox3.Text = null;
            comboBox6.Text = null;
            textBox25.Text = null;
            textBox26.Text = null;
            textBox27.Text = null;
            textBox3.Text = null;
        }

        //inserting department name in combobox1 by click deparment IN
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            pictureBox1.Image = JIST.Properties.Resources.Users_icon;
            fieldempty();
            labelnull();
            textBox2.Enabled = true;
            disable();
            if (comboBox2.Text == "Teaching Staff")
            {
                comboBox1.Items.Clear();
                department();
                comboBox1.Enabled = true;
                yr = 0;
                textBox24.Text ="Y Y Y Y";
                textBox24.Enabled = false;
                button1.Enabled = true;
            }
            else
            {
                comboBox1.Enabled = false;
                textBox24.Enabled = true;
                yr = 0;
                textBox24.Text ="Y Y Y Y";
                button1.Enabled = true;
            }
        }

        //selecting department from combobox1
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            pictureBox1.Image = JIST.Properties.Resources.Users_icon;
            textBox24.Enabled = true;
            fieldempty();
            labelnull();
            disable();
        }

        //Forming closing
        private void StaffUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //Back button
        private void button4_Click(object sender, EventArgs e)
        {
            StaffManagement stm = new StaffManagement();
            this.Hide();
            stm.ShowDialog();
        }

        //Making Custom DateTimepicker1
        void DateTimepicker()
        {

            dateTimePicker1.CustomFormat = "dd-MMM-yyyy";
            dateTimePicker1.MaxDate = DateTime.Today.AddYears(-18);
            i = 1;

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
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Year makin null when click on textbox24
        private void textBox24_Click(object sender, EventArgs e)
        {
            if (yr == 0)
            {
                textBox24.Text = null;
                yr = 1;
            }
            labelnull();
        }

        //Assing yr=1 and only number accepted when pressing key in textBox24
        private void textBox24_KeyPress(object sender, KeyPressEventArgs e)
        {
            yr = 1;
            char ch = e.KeyChar;
            labelnull();
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        //calling datagrid() when search button click
        private void button1_Click(object sender, EventArgs e)
        {
            //calling datagrid
            datagrid();
            labelnull();
        }

        //Loading data in datagridview1
        void datagrid()
        {
            // Showing Data in DataGridView1 from search button
            textBox1.Text = null;
            textBox2.Text = null;
            if (String.IsNullOrWhiteSpace(textBox24.Text))
                yr = 0;
            string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = null;
            if (comboBox2.Text == "Teaching Staff")
            {
                //Department All or null and year default
                if ((comboBox1.Text == "ALL" || String.IsNullOrWhiteSpace(comboBox1.Text)) && yr==0)
                    query = "select ts.tsid as ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,ts.designation as \"Designation    \",ts.salary as \"Salary  \",p.gender as Gender from person p,teaching_staff ts where ts.pid=p.pid order by fname,mname,lname";
                //Department All or null and year entered
                else if ((comboBox1.Text == "ALL" || String.IsNullOrWhiteSpace(comboBox1.Text)) && yr == 1)
                {

                    query = "select ts.tsid as ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,ts.designation as \"Designation    \",ts.salary as \"Salary  \",p.gender as Gender from person p,teaching_staff ts where ts.pid=p.pid and p.DOA like :year order by fname,mname,lname";
                }
                //Department not all and year not entered
                else if (comboBox1.Text !="ALL" && yr==0 )
                {

                    query = "select ts.tsid as ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,ts.designation as \"Designation    \",ts.salary as \"Salary  \",p.gender as Gender from person p,teaching_staff ts where ts.pid=p.pid and ts.deptid=(select deptid from department where deptname='" + comboBox1.Text + "') order by fname,mname,lname";
                }
                //Department not all and year entered
                else if (comboBox1.Text != "ALL" && yr == 1)
                {

                    query = "select ts.tsid as ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,ts.designation as \"Designation    \",ts.salary as \"Salary  \",p.gender as Gender from person p,teaching_staff ts where ts.pid=p.pid and ts.deptid=(select deptid from department where deptname='" + comboBox1.Text + "') and p.DOA like :year order by fname,mname,lname";
                }
              
            }
            else
            {
                //year default
                if (yr == 0)
                    query = "select os.staffid as ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,os.designation as \"Designation    \",os.salary as \"Salary  \",p.gender as Gender from person p,office_staff os where os.pid=p.pid order by fname,mname,lname";
                //year entered
                else
                    query = "select os.staffid as ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,os.designation as \"Designation    \",os.salary as \"Salary  \",p.gender as Gender from person p,office_staff os where os.pid=p.pid and p.DOA like :year order by fname,mname,lname";
            }
            OracleCommand cmd = new OracleCommand(query, con);
            if(yr==1)
            cmd.Parameters.Add(new OracleParameter(":year", "_______"+textBox24.Text.Substring(2)));

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
                this.dataGridView1.Columns["Designation    "].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dataGridView1.Columns["Designation    "].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView1.Columns["Salary  "].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dataGridView1.Columns["Salary  "].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView1.Columns["Gender"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dataGridView1.Columns["Gender"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView1.Columns["ID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dataGridView1.EnableHeadersVisualStyles = false;
                this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("ARIAL", 9, FontStyle.Bold);
                this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
                this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.MistyRose;
                this.dataGridView1.DefaultCellStyle.BackColor = Color.LightCyan;
                this.dataGridView1.DefaultCellStyle.Font = new Font("ARIAL", 9, FontStyle.Bold);
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
            string query = "select * from person where pid='" + pid + "'";
            OracleCommand cmd = new OracleCommand(query, con);
            OracleDataReader rdr;
            try
            {

                con.Open();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                string fname, mname, lname, ffname, fmname, flname, mfname, mmname, mlname, dob, nationality, religion, caste, bg, gender, add, locality, district, state, postoffice, email;
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
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Retrieve information from Teaching Staff table and calling personinfo(pid)
        void Teachinginfo()
        {
            // Retrieve information from teaching staff table

            string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "select * from TEACHING_STAFF where tsid='" + id + "'";
            OracleCommand cmd = new OracleCommand(query, con);
            OracleDataReader rdr;
            try
            {

                con.Open();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                pid = rdr.GetInt32(0);

                //Making previous work exp and specialization empty
                textBox3.Text = null;
                textBox26.Text = null;
                textBox26.Enabled = true;

                if (Convert.IsDBNull(rdr["PREVIOUS_WORK_EXP"]))
                {
                    textBox3.Text = null;
                }
                else
                {
                    string prwe = rdr.GetString(5);

                    textBox3.Text = prwe;
                }
                if(Convert.IsDBNull(rdr["SPECIALIZATION"]))
                {
                    textBox26.Text = null;
                }
                else
                {
                    string spec = rdr.GetString(6);
                    textBox26.Text = spec;
                }

                string deg = rdr.GetString(2);
                int sal = rdr.GetInt32(3);
                string quali = rdr.GetString(4);
                comboBox6.Visible = false;
                comboBox3.Visible = true;
                comboBox3.Text = deg;
                textBox25.Text = sal.ToString();
                textBox27.Text = quali;

                personinfo(pid);
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Retrieve information from Office Staff table and calling personinfo(pid)
        void Officeinfo()
        {

            string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "select * from OFFICE_STAFF where STAFFID='" + id + "'";
            OracleCommand cmd = new OracleCommand(query, con);
            OracleDataReader rdr;
            try
            {

                con.Open();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                pid = rdr.GetInt32(1);

                //Making previous work exp empty
                textBox3.Text = null;

                //making specialization disable
                textBox26.Enabled = false;

                if (Convert.IsDBNull(rdr["PREVIOUS_WORK_EXP"]))
                {
                    textBox3.Text = null;
                }
                else
                {
                    string prwe = rdr.GetString(5);

                    textBox3.Text = prwe;
                }

                string deg = rdr.GetString(2);
                int sal = rdr.GetInt32(3);
                string quali = rdr.GetString(4);
                comboBox3.Visible = false;
                comboBox6.Visible = true;
                comboBox6.Text = deg;
                textBox25.Text = sal.ToString();
                textBox27.Text = quali;

                personinfo(pid);
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
                if (comboBox2.Text == "Teaching Staff"||textBox1.Text.StartsWith("T"))
                {
                    if (e.RowIndex >= 0)
                    {

                        DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                        id = row.Cells["ID"].Value.ToString();
                        makingnull();
                        Teachinginfo();

                    }
                }
                else
                {
                    if (e.RowIndex >= 0)
                    {

                        DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                        id = row.Cells["ID"].Value.ToString();
                        makingnull();
                        Officeinfo();

                    }
                }
            }
            catch (Exception ex)
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

        //calling teachoffid() when key pressed on textbox1
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //calling teachoffid
            teachoffid();
            label16.Visible = true;
            label16.Text = "Displaying " + dataGridView1.RowCount + " Record";
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                try
                {
                    dataGridView1.DataSource = null;
                    label16.Text = "Displaying " + dataGridView1.RowCount + " Record";
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //Searching through TEACHING_STAFF ID and OFFICE_STAFF ID
        void teachoffid()
        {
            //Searching through TEACHING_STAFF ID and OFFICE_STAFF ID
            pictureBox1.Image = JIST.Properties.Resources.Users_icon;
            String str = "Data Source=localhost:1521/xe;user id=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "select ts.tsid as ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,ts.designation as \"Designation    \",ts.salary as \"Salary  \",p.gender as Gender from person p,teaching_staff ts where ts.pid=p.pid order by fname,mname,lname";
            string query1 = "select os.staffid as ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,os.designation as \"Designation    \",os.salary as \"Salary  \",p.gender as Gender from person p,office_staff os where os.pid=p.pid order by fname,mname,lname";
            OracleCommand cmd = new OracleCommand(query, con);
            OracleCommand cmd1 = new OracleCommand(query1, con);
            // cmd.Parameters.Add("namelike", "%" + textBox2.Text + "%");
            try
            {
                OracleDataAdapter oda = new OracleDataAdapter();
                OracleDataAdapter oda1 = new OracleDataAdapter();
                oda.SelectCommand = cmd;
                oda1.SelectCommand = cmd1;
                DataTable dbt,dbt1;
               
              
                if (textBox1.Text.StartsWith("T"))
                {
                    dbt = new DataTable();
                    oda.Fill(dbt);
                    DataView DV = new DataView(dbt);
                    DV.RowFilter = string.Format("ID like '{0}%'", textBox1.Text);
                    dataGridView1.DataSource = DV;
                }
                else
                {
                    dbt1 = new DataTable();
                    oda1.Fill(dbt1);
                    DataView DV1 = new DataView(dbt1);
                    DV1.RowFilter = string.Format("ID like '{0}%'", textBox1.Text);
                    dataGridView1.DataSource = DV1;
                }
 

                this.dataGridView1.Columns["Full_Name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dataGridView1.Columns["Full_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns["Designation    "].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dataGridView1.Columns["Designation    "].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView1.Columns["Salary  "].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dataGridView1.Columns["Salary  "].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView1.Columns["Gender"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dataGridView1.Columns["Gender"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView1.Columns["ID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
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

        //calling teachoffname() when key pressed on textbox2
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //calling teachoffname
            teachoffname();
            label16.Visible = true;
            label16.Text = "Displaying " + dataGridView1.RowCount + " Record";
            if (String.IsNullOrWhiteSpace(textBox2.Text))
            {
                try
                {
                    dataGridView1.DataSource = null;
                    label16.Text = "Displaying " + dataGridView1.RowCount + " Record";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //Searching through NAME
        void teachoffname()
        {
            //Searching through NAME
            pictureBox1.Image = JIST.Properties.Resources.Users_icon;
            String str = "Data Source=localhost:1521/xe;user id=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "select ts.tsid as ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,ts.designation as \"Designation    \",ts.salary as \"Salary  \",p.gender as Gender from person p,teaching_staff ts where ts.pid=p.pid order by fname,mname,lname";
            string query1 = "select os.staffid as ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,os.designation as \"Designation    \",os.salary as \"Salary  \",p.gender as Gender from person p,office_staff os where os.pid=p.pid order by fname,mname,lname";
            OracleCommand cmd = new OracleCommand(query, con);
            OracleCommand cmd1 = new OracleCommand(query1, con);
            try
            {
                OracleDataAdapter oda = new OracleDataAdapter();
                OracleDataAdapter oda1 = new OracleDataAdapter();
                oda.SelectCommand = cmd;
                oda1.SelectCommand = cmd1;
                DataTable dbt,dbt1;
                dbt = new DataTable();
                dbt1 = new DataTable();

                if (comboBox2.Text == "Teaching Staff") 
                {
                    oda.Fill(dbt);
                    DataView DV = new DataView(dbt);
                    DV.RowFilter = string.Format("Full_Name like '%{0}%'", textBox2.Text);
                    dataGridView1.DataSource = DV;
                }

                else
                {
                    oda1.Fill(dbt1);
                    DataView DV1 = new DataView(dbt1);
                    DV1.RowFilter = string.Format("Full_Name like '%{0}%'", textBox2.Text);
                    dataGridView1.DataSource = DV1;
                }


                this.dataGridView1.Columns["Full_Name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dataGridView1.Columns["Full_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns["Designation    "].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dataGridView1.Columns["Designation    "].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView1.Columns["Salary  "].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dataGridView1.Columns["Salary  "].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView1.Columns["Gender"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dataGridView1.Columns["Gender"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView1.Columns["ID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
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
            textBox2.Enabled = false;
            textBox24.Enabled = false;
            button1.Enabled = false;
            labelnull();
        }

        //making textbox1 content null when click on textbox2
        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            comboBox1.Text = null;
            textBox24.Enabled = false;
            button1.Enabled = false;
            labelnull();
        }

        //making all label invisible
        void labelnull()
        {
          
            label33.Text = null;
            label33.Visible = false;
            label34.Text = null;
            label34.Visible = false;
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
            //Salary
            if(String.IsNullOrWhiteSpace(textBox25.Text))
            {
                label34.Visible = true;
                label34.Text= "Some Fields cannot be empty";
                x = 1;
            }
            //qualification
            if (String.IsNullOrWhiteSpace(textBox27.Text))
            {
                label33.Visible = true;
                label33.Text = "Some Fields cannot be empty";
                x = 1;
            }
            if (x == 0)
            {
               personupdate();
                dataGridView1.RefreshEdit();
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

        //Salary only number accepted
        private void textBox25_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        //Stopping scrollbar to move up when click on datagridview1
        private void dataGridView1_MouseEnter(object sender, EventArgs e)
        {
            int vs = panel1.VerticalScroll.Value;
            ActiveControl = dataGridView1;
            panel1.VerticalScroll.Value = vs;
        }

        //inserting into teaching_staff or office_staff table 
        void teachofficeupdate()
        {

            try
            {
                string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
                OracleConnection con = new OracleConnection(str);
                string query = null;
                if (comboBox2.Text == "Teaching Staff" || textBox1.Text.StartsWith("T"))
                {
                   
                    if (String.IsNullOrWhiteSpace(textBox26.Text) && String.IsNullOrWhiteSpace(textBox3.Text))
                        query = "update TEACHING_STAFF set DESIGNATION='" + comboBox3.Text + "',salary='" + textBox25.Text + "',qualification='" + textBox27.Text + "',PREVIOUS_WORK_EXP=null,SPECIALIZATION=null where tsid='" + id + "'";
                    else if (String.IsNullOrWhiteSpace(textBox26.Text))
                        query = "update TEACHING_STAFF set DESIGNATION='" + comboBox3.Text + "',salary='" + textBox25.Text + "',qualification='" + textBox27.Text + "',PREVIOUS_WORK_EXP='" + textBox3.Text + "',SPECIALIZATION=null where tsid='" + id + "'";
                    else if (String.IsNullOrWhiteSpace(textBox3.Text))
                        query = "update TEACHING_STAFF set DESIGNATION='" + comboBox3.Text + "',salary='" + textBox25.Text + "',qualification='" + textBox27.Text + "',PREVIOUS_WORK_EXP=null,SPECIALIZATION='" + textBox26.Text + "' where tsid='" + id + "'";
                    else
                        query = "update TEACHING_STAFF set DESIGNATION='" + comboBox3.Text + "',salary='" + textBox25.Text + "',qualification='" + textBox27.Text + "',PREVIOUS_WORK_EXP='" + textBox3.Text + "',SPECIALIZATION='" + textBox26.Text + "' where tsid='" + id + "'";
                }
                else
                {
                    
                   if (String.IsNullOrWhiteSpace(textBox3.Text))
                        query = "update OFFICE_STAFF set DESIGNATION='" + comboBox6.Text + "',SALARY='" + textBox25.Text + "',QUALIFICATION='" + textBox27.Text + "',PREVIOUS_WORK_EXP=null where staffid='" + id + "'";
                    else
                        query = "update OFFICE_STAFF set DESIGNATION='" + comboBox6.Text + "',SALARY='" + textBox25.Text + "',QUALIFICATION='" + textBox27.Text + "',PREVIOUS_WORK_EXP='" + textBox3.Text + "' where staffid='" + id + "'";
                }


                OracleCommand cmd = new OracleCommand(query, con);
                OracleDataReader rdr;
                con.Open();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                //if (textBox1.Text == null && textBox2.Text == null)
                //    datagrid();
                //else if (textBox1.Text != null)
                //    studentid();
                //else if (textBox2.Text != null)
                //    studentname();

                MessageBox.Show("Record Updated Successfully");
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
                    teachofficeupdate();
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
                    teachofficeupdate();
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
