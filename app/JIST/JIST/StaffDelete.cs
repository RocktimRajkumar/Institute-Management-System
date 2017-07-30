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
using System.IO;

namespace JIST
{
    public partial class StaffDelete : Form
    {
        int pid,yr;

        //constructor calling and initialized
        public StaffDelete()
        {
            InitializeComponent();
            connection();
            pid = yr = 0;
            button1.Enabled = false;
            comboBox1.Enabled = false;
            dataGridView1.MultiSelect = false;
            textBox2.Enabled = false;
            button2.Enabled = false;
            textBox24.Enabled = false;
            Name12.Visible = false;
            label16.Visible = false;
            panel1.VerticalScroll.Value = 1;
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
            int vs = panel1.VerticalScroll.Value;
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

            panel1.VerticalScroll.Value = vs;
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
                mycon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //back button
        private void button4_Click(object sender, EventArgs e)
        {
            StaffManagement sm = new StaffManagement();
            this.Hide();
            sm.ShowDialog();
        }

        //Form closing
        private void StaffDelete_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //inserting department name in combobox1 by click deparment IN
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            pictureBox1.Image = JIST.Properties.Resources.Users_icon;
            textBox2.Enabled = true;
            Name12.Visible = false;
            button2.Enabled = false;
            dataGridView1.DataSource = null;
            if (comboBox2.Text == "Teaching Staff")
            {
                comboBox1.Items.Clear();
                department();
                comboBox1.Enabled = true;
                yr = 0;
                textBox24.Text = "Y Y Y Y";
                textBox24.Enabled = false;
                button1.Enabled = true;
            }
            else
            {
                comboBox1.Enabled = false;
                textBox24.Enabled = true;
                yr = 0;
                textBox24.Text = "Y Y Y Y";
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
            Name12.Visible = false;
            button2.Enabled = false;
            dataGridView1.DataSource = null;
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
        }

        //Assing yr=1 and only number accepted when pressing key in textBox24
        private void textBox24_KeyPress(object sender, KeyPressEventArgs e)
        {
            yr = 1;
            char ch = e.KeyChar;
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

        }

        //Loading data in datagridview1
        void datagrid()
        {
            // Showing Data in DataGridView1 from search button
            textBox1.Text = null;
            textBox2.Text = null;
            if (String.IsNullOrWhiteSpace(textBox24.Text))
                yr = 0;
            Name12.Visible = false;
            button2.Enabled = false;
            string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = null;
            if (comboBox2.Text == "Teaching Staff")
            {
                //Department All or null and year default
                if ((comboBox1.Text == "ALL" || String.IsNullOrWhiteSpace(comboBox1.Text)) && yr == 0)
                    query = "select p.photograph as IMG,ts.tsid as ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,ts.designation as \"Designation    \",ts.salary as \"Salary  \",to_char(p.DOA,'dd/MON/yyyy') as Date_of_Joining,p.gender as Gender from person p,teaching_staff ts where ts.pid=p.pid order by fname,mname,lname";
                //Department All or null and year entered
                else if ((comboBox1.Text == "ALL" || String.IsNullOrWhiteSpace(comboBox1.Text)) && yr == 1)
                {

                    query = "select p.photograph as IMG,ts.tsid as ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,ts.designation as \"Designation    \",ts.salary as \"Salary  \",to_char(p.DOA,'dd/MON/yyyy') as Date_of_Joining,p.gender as Gender from person p,teaching_staff ts where ts.pid=p.pid and p.DOA like :year order by fname,mname,lname";
                }
                //Department not all and year not entered
                else if (comboBox1.Text != "ALL" && yr == 0)
                {

                    query = "select p.photograph as IMG,ts.tsid as ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,ts.designation as \"Designation    \",ts.salary as \"Salary  \",to_char(p.DOA,'dd/MON/yyyy') as Date_of_Joining,p.gender as Gender from person p,teaching_staff ts where ts.pid=p.pid and ts.deptid=(select deptid from department where deptname='" + comboBox1.Text + "') order by fname,mname,lname";
                }
                //Department not all and year entered
                else if (comboBox1.Text != "ALL" && yr == 1)
                {

                    query = "select p.photograph as IMG,ts.tsid as ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,ts.designation as \"Designation    \",ts.salary as \"Salary  \",to_char(p.DOA,'dd/MON/yyyy') as Date_of_Joining,p.gender as Gender from person p,teaching_staff ts where ts.pid=p.pid and ts.deptid=(select deptid from department where deptname='" + comboBox1.Text + "') and p.DOA like :year order by fname,mname,lname";
                }

            }
            else
            {
                //year default
                if (yr == 0)
                    query = "select p.photograph as IMG,os.staffid as ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,os.designation as \"Designation    \",os.salary as \"Salary  \",to_char(p.DOA,'dd/MON/yyyy') as Date_of_Joining,p.gender as Gender from person p,office_staff os where os.pid=p.pid order by fname,mname,lname";
                //year entered
                else
                    query = "select p.photograph as IMG,os.staffid as ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,os.designation as \"Designation    \",os.salary as \"Salary  \",to_char(p.DOA,'dd/MON/yyyy') as Date_of_Joining,p.gender as Gender from person p,office_staff os where os.pid=p.pid and p.DOA like :year order by fname,mname,lname";
            }
            OracleCommand cmd = new OracleCommand(query, con);
            if(yr==1)
            cmd.Parameters.Add(new OracleParameter(":year", "_______" + textBox24.Text.Substring(2)));

            try
            {
                OracleDataAdapter oda = new OracleDataAdapter();
                oda.SelectCommand = cmd;
                DataTable dbdataset = new DataTable();
                oda.Fill(dbdataset);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dbdataset;
                dataGridView1.DataSource = bsource;
                this.dataGridView1.Columns["Full_Name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns["Full_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns["Designation    "].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dataGridView1.Columns["Designation    "].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView1.Columns["Salary  "].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dataGridView1.Columns["Salary  "].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView1.Columns["Gender"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dataGridView1.Columns["Gender"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView1.Columns["Date_of_Joining"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dataGridView1.Columns["Date_of_Joining"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView1.Columns["ID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dataGridView1.Columns["IMG"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                if (this.dataGridView1.Columns["IMG"] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dataGridView1.Columns["IMG"]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                }
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

        //calling teachoffid() when key pressed on textbox1
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //calling teachoffid
            teachoffid();
            Name12.Visible = false;
            button2.Enabled = false;
            label16.Visible = true;
            label16.Text = "Displaying " + dataGridView1.RowCount + " Record";
            if (String.IsNullOrWhiteSpace(textBox1.Text))
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

        //Searching through TEACHING_STAFF ID and OFFICE_STAFF ID
        void teachoffid()
        {
            //Searching through TEACHING_STAFF ID and OFFICE_STAFF ID
            pictureBox1.Image = JIST.Properties.Resources.Users_icon;
            String str = "Data Source=localhost:1521/xe;user id=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "select p.photograph as IMG,ts.tsid as ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,ts.designation as \"Designation    \",ts.salary as \"Salary  \",to_char(p.DOA,'dd/MON/yyyy') as Date_of_Joining,p.gender as Gender from person p,teaching_staff ts where ts.pid=p.pid order by fname,mname,lname";
            string query1 = "select p.photograph as IMG,os.staffid as ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,os.designation as \"Designation    \",os.salary as \"Salary  \",to_char(p.DOA,'dd/MON/yyyy') as Date_of_Joining,p.gender as Gender from person p,office_staff os where os.pid=p.pid order by fname,mname,lname";
            OracleCommand cmd = new OracleCommand(query, con);
            OracleCommand cmd1 = new OracleCommand(query1, con);
            // cmd.Parameters.Add("namelike", "%" + textBox2.Text + "%");
            try
            {
                OracleDataAdapter oda = new OracleDataAdapter();
                OracleDataAdapter oda1 = new OracleDataAdapter();
                oda.SelectCommand = cmd;
                oda1.SelectCommand = cmd1;
                DataTable dbt, dbt1;


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


                this.dataGridView1.Columns["Full_Name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns["Full_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns["Designation    "].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dataGridView1.Columns["Designation    "].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView1.Columns["Salary  "].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dataGridView1.Columns["Salary  "].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView1.Columns["Gender"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dataGridView1.Columns["Gender"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView1.Columns["Date_of_Joining"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dataGridView1.Columns["Date_of_Joining"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView1.Columns["ID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dataGridView1.Columns["IMG"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                if (this.dataGridView1.Columns["IMG"] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dataGridView1.Columns["IMG"]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                }
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
            Name12.Visible = false;
            button2.Enabled = false;
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
            string query = "select p.photograph as IMGts.tsid as ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,ts.designation as \"Designation    \",ts.salary as \"Salary  \",to_char(p.DOA,'dd/MON/yyyy') as Date_of_Joining,p.gender as Gender from person p,teaching_staff ts where ts.pid=p.pid order by fname,mname,lname";
            string query1 = "select p.photograph as IMG,os.staffid as ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,os.designation as \"Designation    \",os.salary as \"Salary  \",to_char(p.DOA,'dd/MON/yyyy') as Date_of_Joining,p.gender as Gender from person p,office_staff os where os.pid=p.pid order by fname,mname,lname";
            OracleCommand cmd = new OracleCommand(query, con);
            OracleCommand cmd1 = new OracleCommand(query1, con);
            try
            {
                OracleDataAdapter oda = new OracleDataAdapter();
                OracleDataAdapter oda1 = new OracleDataAdapter();
                oda.SelectCommand = cmd;
                oda1.SelectCommand = cmd1;
                DataTable dbt, dbt1;
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


                this.dataGridView1.Columns["Full_Name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns["Full_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns["Designation    "].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dataGridView1.Columns["Designation    "].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView1.Columns["Salary  "].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dataGridView1.Columns["Salary  "].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView1.Columns["Gender"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dataGridView1.Columns["Gender"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView1.Columns["Date_of_Joining"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dataGridView1.Columns["Date_of_Joining"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView1.Columns["ID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dataGridView1.Columns["IMG"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                if (this.dataGridView1.Columns["IMG"] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dataGridView1.Columns["IMG"]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                }
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
            Name12.Visible = false;
            button2.Enabled = false;
        }

        //making textbox1 content null when click on textbox2
        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            comboBox1.Text = null;
            textBox24.Enabled = false;
            button1.Enabled = false;
            Name12.Visible = false;
            button2.Enabled = false;
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
                    datagrid();
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
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Retrieve information from teaching_staff or office_staff table and calling personinfo
        void teachofficeinfo(string id)
        {

            string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query=null;
            if (comboBox2.Text == "Teaching Staff" || textBox1.Text.StartsWith("T"))
                query = "select pid from Teaching_Staff where tsid='" + id + "'";
            else
                query = "select pid from Office_Staff where staffid='" + id + "'";
            OracleCommand cmd = new OracleCommand(query, con);
            OracleDataReader rdr;
            try
            {

                con.Open();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                pid = rdr.GetInt32(0);
                personinfo();
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
                    string id = row.Cells["ID"].Value.ToString();
                    string name = row.Cells["Full_Name"].Value.ToString();
                    Name12.Text = name;
                    Name12.Visible = true;
                    teachofficeinfo(id);

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
