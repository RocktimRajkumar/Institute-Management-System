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

namespace JIST
{
    public partial class Delete : Form
    {
        int pid;

        //Constructor calling and initializing
        public Delete()
        {
            InitializeComponent();
            connection();
            department();
            panel1.VerticalScroll.Value = 1;
            studentdash.Normalcolor = Color.FromArgb(252, 86, 83);
            button2.Enabled = false;
            Name12.Visible = false;
            dataGridView1.MultiSelect = false;
            label16.Visible = false;
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

        //checking connection
        void connection()
        {
            try
            {
                string str = "DATA SOURCE=localhost:1521/xe;USER ID = IMS; Password=enteryourchoice";
                OracleConnection mycon = new OracleConnection(str);
                mycon.Open();
                mycon.Dispose();
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

        // insert coursename in combobox2
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // insert coursename in combobox2
            textBox1.Text = null;
            textBox2.Text = null;
            Name12.Visible = false;
            button2.Enabled = false;
            pictureBox1.Image = JIST.Properties.Resources.Users_icon;
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

        // insert Semester in combobox3
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // insert Semester in combobox3
            textBox1.Text = null;
            textBox2.Text = null;
            Name12.Visible = false;
            button2.Enabled = false;
            pictureBox1.Image = JIST.Properties.Resources.Users_icon;
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

        //combobox3 select
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            Name12.Visible = false;
            button2.Enabled = false;
            pictureBox1.Image = JIST.Properties.Resources.Users_icon;
        }
        //Back Button
        private void button4_Click(object sender, EventArgs e)
        {
            StudentManagement studm = new StudentManagement();
            this.Hide();
            studm.ShowDialog();
        }

        //Form closing
        private void Delete_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }

        // Showing Data in DataGridView1
        void showDatagridview()
        {
            // Showing Data in DataGridView1
            button2.Enabled = false;
            Name12.Visible = false;
            pictureBox1.Image = JIST.Properties.Resources.Users_icon;
            textBox1.Text = null;
            textBox2.Text = null;
            string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = null;
            //Department All
            if (comboBox1.Text == "ALL")
                query = "select p.photograph IMG,sc.stuid as Student_ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,p.GENDER,deptname as Department,coursename as Course,currentstatus as Semester from person p,department d,student s,student_course sc,course c where sc.courseid=c.courseid and s.stuid=sc.stuid and d.deptid=s.deptid and p.pid=s.pid order by fname,mname,lname";
            //Non is empty
            else if (String.IsNullOrWhiteSpace(comboBox1.Text) && String.IsNullOrWhiteSpace(comboBox2.Text) && String.IsNullOrWhiteSpace(comboBox3.Text))
            {

                query = "select  p.photograph IMG,sc.stuid as Student_ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,p.GENDER,deptname as Department,coursename as Course,currentstatus as Semester from person p,department d,student s,student_course sc,course c where sc.courseid=c.courseid and s.stuid=sc.stuid and d.deptid=s.deptid and p.pid=s.pid order by fname,mname,lname";
            }
            //course and semester is empty
            else if (String.IsNullOrWhiteSpace(comboBox2.Text) && String.IsNullOrWhiteSpace(comboBox3.Text))
            {

                query = "select p.photograph IMG,sc.stuid as Student_ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,p.GENDER,deptname as Department,coursename as Course,currentstatus as Semester from person p,department d,student s,student_course sc,course c where sc.courseid=c.courseid and s.stuid=sc.stuid and d.deptid=s.deptid and p.pid=s.pid and d.deptid=(select deptid from department where deptname='" + comboBox1.Text + "') order by fname,mname,lname";
            }
            //Department and Course is empty
            else if (String.IsNullOrWhiteSpace(comboBox2.Text) && String.IsNullOrWhiteSpace(comboBox3.Text))
            {

                query = "select p.photograph IMG,sc.stuid as Student_ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,p.GENDER,deptname as Department,coursename as Course,currentstatus as Semester from person p,department d,student s,student_course sc,course c where sc.courseid=c.courseid and s.stuid=sc.stuid and d.deptid=s.deptid and p.pid=s.pid and s.currentstatus='" + comboBox3.Text + "' order by fname,mname,lname";
            }
            //Department and Semester is empty
            else if (String.IsNullOrWhiteSpace(comboBox2.Text) && String.IsNullOrWhiteSpace(comboBox3.Text))
            {

                query = "select p.photograph IMG,sc.stuid as Student_ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,p.GENDER,deptname as Department,coursename as Course,currentstatus as Semester from person p,department d,student s,student_course sc,course c where sc.courseid=c.courseid and s.stuid=sc.stuid and d.deptid=s.deptid and p.pid=s.pid and coursename='" + comboBox2.Text + "' order by fname,mname,lname";
            }
            //Department is empty
            else if (String.IsNullOrWhiteSpace(comboBox1.Text))
            {

                query = "select p.photograph IMG,sc.stuid as Student_ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,p.GENDER,deptname as Department,coursename as Course,currentstatus as Semester from person p,department d,student s,student_course sc,course c where sc.courseid=c.courseid and s.stuid=sc.stuid and d.deptid=s.deptid and p.pid=s.pid and coursename='" + comboBox2.Text + "' and s.currentstatus='" + comboBox3.Text + "' order by fname,mname,lname";
            }
            //Course is empty
            else if (String.IsNullOrWhiteSpace(comboBox2.Text))
            {

                query = "select p.photograph IMG,sc.stuid as Student_ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,p.GENDER,deptname as Department,coursename as Course,currentstatus as Semester from person p,department d,student s,student_course sc,course c where sc.courseid=c.courseid and s.stuid=sc.stuid and d.deptid=s.deptid and p.pid=s.pid and d.deptid=(select deptid from department where deptname='" + comboBox1.Text + "') and s.currentstatus='" + comboBox3.Text + "' order by fname,mname,lname";
            }
            //Semester is empty
            else if (String.IsNullOrWhiteSpace(comboBox3.Text))
            {

                query = "select p.photograph IMG,sc.stuid as Student_ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,p.GENDER,deptname as Department,coursename as Course,currentstatus as Semester from person p,department d,student s,student_course sc,course c where sc.courseid=c.courseid and s.stuid=sc.stuid and d.deptid=s.deptid and p.pid=s.pid and d.deptid=(select deptid from department where deptname='" + comboBox1.Text + "') and coursename='" + comboBox2.Text + "' order by fname,mname,lname";
            }

            //Department,course,semester is empty
            else
            {

                query = "select p.photograph IMG,sc.stuid as Student_ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,p.GENDER,deptname as Department,coursename as Course,currentstatus as Semester from person p,department d,student s,student_course sc,course c where sc.courseid=c.courseid and s.stuid=sc.stuid and d.deptid=s.deptid and p.pid=s.pid and d.deptid=(select deptid from department where deptname='" + comboBox1.Text + "') and coursename='" + comboBox2.Text + "' and s.currentstatus='" + comboBox3.Text + "' order by fname,mname,lname";
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

                this.dataGridView1.Columns["Full_Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dataGridView1.Columns["Full_Name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dataGridView1.Columns["Full_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns["IMG"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                if (this.dataGridView1.Columns["IMG"] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dataGridView1.Columns["IMG"]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                }
                //this.dataGridView1.Columns["Department"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                //this.dataGridView1.Columns["Course"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                //this.dataGridView1.Columns["Semester"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
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

        //calling showDatagridView() when click search button
        private void button1_Click(object sender, EventArgs e)
        {
            //calling showDatagridView()
            showDatagridview(); 
           
        }

        //Searching through STUDENT ID
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
            //Searching through STUDENT ID
            button2.Enabled = false;
            Name12.Visible = false;
            pictureBox1.Image = JIST.Properties.Resources.Users_icon;
            String str = "Data Source=localhost:1521/xe;user id=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "select p.photograph IMG,sc.stuid as Student_ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,GENDER,deptname as Department,coursename as Course,currentstatus as Semester from person p,department d,student s,student_course sc,course c where sc.courseid=c.courseid and s.stuid=sc.stuid and d.deptid=s.deptid and p.pid=s.pid order by fname,mname,lname";
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
               
                this.dataGridView1.Columns["Full_Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dataGridView1.Columns["Full_Name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dataGridView1.Columns["Full_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns["IMG"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                if (this.dataGridView1.Columns["IMG"] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dataGridView1.Columns["IMG"]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                }
                //this.dataGridView1.Columns["Department"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                //this.dataGridView1.Columns["Course"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                //this.dataGridView1.Columns["Semester"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView1.EnableHeadersVisualStyles = false;
                this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("ARIAL", 9, FontStyle.Bold);
                this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
                this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.MistyRose;
                this.dataGridView1.DefaultCellStyle.BackColor = Color.LightCyan;
                this.dataGridView1.DefaultCellStyle.Font = new Font("ARIAL", 9, FontStyle.Bold);
                this.dataGridView1.DefaultCellStyle.ForeColor = Color.Red;

                if (String.IsNullOrWhiteSpace(textBox1.Text))
                {
                    if (dataGridView1.Rows.Count > 0)
                        dataGridView1.Rows[0].Selected = false;
                }
                label16.Visible = true;
                label16.Text = "Displaying " + dataGridView1.RowCount + " Record";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Searching through NAME
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //Searching through NAME
            button2.Enabled = false;
            Name12.Visible = false;
            pictureBox1.Image = JIST.Properties.Resources.Users_icon;
            String str = "Data Source=localhost:1521/xe;user id=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "select p.photograph as IMG,sc.stuid as Student_ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,GENDER,deptname as Department,coursename as Course,currentstatus as Semester from person p,department d,student s,student_course sc,course c where sc.courseid=c.courseid and s.stuid=sc.stuid and d.deptid=s.deptid and p.pid=s.pid order by fname,mname,lname";
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
                if (String.IsNullOrWhiteSpace(comboBox1.Text) && String.IsNullOrWhiteSpace(comboBox2.Text) && String.IsNullOrWhiteSpace(comboBox3.Text))
                    DV.RowFilter = string.Format("Full_Name like '%{0}%'", textBox2.Text);
                //Department all
                else if (comboBox1.Text == "ALL")
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
               
                this.dataGridView1.Columns["Full_Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dataGridView1.Columns["Full_Name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dataGridView1.Columns["Full_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns["IMG"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                if (this.dataGridView1.Columns["IMG"] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dataGridView1.Columns["IMG"]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                }
                //this.dataGridView1.Columns["Department"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                //this.dataGridView1.Columns["Course"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                //this.dataGridView1.Columns["Semester"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView1.EnableHeadersVisualStyles = false;
                this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("ARIAL", 9, FontStyle.Bold);
                this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
                this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.MistyRose;
                this.dataGridView1.DefaultCellStyle.BackColor = Color.LightCyan;
                this.dataGridView1.DefaultCellStyle.Font = new Font("ARIAL", 9, FontStyle.Bold);
                this.dataGridView1.DefaultCellStyle.ForeColor = Color.Red;

                if (String.IsNullOrWhiteSpace(textBox2.Text))
                {
                    if (dataGridView1.Rows.Count > 0)
                        dataGridView1.Rows[0].Selected = false;
                }

                label16.Visible = true;
                label16.Text = "Displaying " + dataGridView1.RowCount + " Record";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Making name null when click on Studentid
        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox2.Text = null;
            comboBox1.Text = null;
            comboBox2.Text = null;
            comboBox3.Text = null;
        }

        //Making studentid null when click on name
        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            comboBox1.Text = null;
            comboBox2.Text = null;
            comboBox3.Text = null;
        }

        // Delete selected data from datagridview1 when click on delete button
        private void button2_Click(object sender, EventArgs e)
        {
            // Delete selected data from datagridview1
            DialogResult dialog = MessageBox.Show("Confirm Changes?", "DELETE", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.No)
            {


            }
            else if (dialog == DialogResult.Yes)
            {


                string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
                OracleConnection con = new OracleConnection(str);
                string query = "delete from person where pid='" + pid + "'";
                OracleCommand cmd = new OracleCommand(query, con);
                OracleDataReader rdr;
                try
                {

                    con.Open();

                    rdr = cmd.ExecuteReader();
                    rdr.Read();
                    Name12.Visible = false;
                    pictureBox1.Image = JIST.Properties.Resources.Users_icon;
                    button2.Enabled = false;
                    pid = 0;
                    MessageBox.Show("One Recrod Deleted");
                    showDatagridview();
                    con.Dispose();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Retrieve information from person table
        void personinfo()
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

                //Showing picture in picturebox1
                if (Convert.IsDBNull(rdr["PHOTOGRAPH"]))
                {
                    Name12.Visible = false;
                    pictureBox1.Image = JIST.Properties.Resources.Users_icon;
                }
                else
                {
                    byte[] imgg = (byte[])(rdr["PHOTOGRAPH"]);
                    if (imgg == null)
                    {
                        Name12.Visible = false;
                        pictureBox1.Image = null;
                    }
                    else
                    {
                        MemoryStream mstream = new MemoryStream(imgg);
                        pictureBox1.Image = System.Drawing.Image.FromStream(mstream);
                    }
                }
                button2.Enabled = true;
                con.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Retrieve information from student table and calling personinfo
        void studentinfo(string stuid)
        {
            // Retrieve information from student table

            string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "select * from student where stuid='" + stuid + "'";
            OracleCommand cmd = new OracleCommand(query, con);
            OracleDataReader rdr;
            try
            {

                con.Open();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                pid = rdr.GetInt32(1);
                personinfo();
                con.Dispose();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Datagridview content select and calling studentinfo(stuid)
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    string stuid = row.Cells["Student_ID"].Value.ToString();
                    string name = row.Cells["Full_Name"].Value.ToString();
                    Name12.Text = name;
                    Name12.Visible = true;
                    studentinfo(stuid);

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
