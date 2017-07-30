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
    public partial class insertAttendance : Form
    {
        string stuid;
        //constructor calling and initializing
        public insertAttendance()
        {
            InitializeComponent();
            connection();
            department();
            button2.Enabled = false;
            button1.Enabled = false;
            textBox2.Enabled = false;
            textBox1.Enabled = false;
            Name12.Visible = false;
            panel1.VerticalScroll.Value = 1;
            attendancedash.Normalcolor = Color.FromArgb(252, 86, 83);
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

        //Form closing
        private void insertAttendance_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //Back button
        private void button4_Click(object sender, EventArgs e)
        {
            Attendance atd = new Attendance();
            this.Hide();
            atd.ShowDialog();
        }


        //inserting department name in combobox1
        void department()
        {
            //inserting department name in combobox1
            button1.Enabled = false;
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

        // insert coursename in combobox2
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = null;
            textBox1.Text = null;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            // insert coursename in combobox2
            button1.Enabled = false;
            button2.Enabled = false;
            Name12.Visible = false;
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
            textBox2.Text = null;
            textBox1.Text = null;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            Name12.Visible = false;
            button1.Enabled = false;
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
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Search button enable by selecting semester in combobox3
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            textBox2.Text = null;
            textBox1.Text = null;
            Name12.Visible = false;
            pictureBox1.Image = JIST.Properties.Resources.Users_icon;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            button2.Enabled = false;
        }

        //Making name null when click on Studentid
        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox2.Text = null;
        }

        //Making studentid null when click on name
        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
        }

        //calling datagrid() when search button click and all selected
        private void button1_Click(object sender, EventArgs e)
        {
            //calling datagrid
            dataGridView1.Columns.Clear();
            datagrid();
            Name12.Visible = false;
            pictureBox1.Image = JIST.Properties.Resources.Users_icon;
            textBox2.Enabled = true;
            textBox1.Enabled = true;
            button2.Enabled = true;
        }

        //Loading data in datagridview1 and calling subjectadd()
        void datagrid()
        {
            // Showing Data in DataGridView1 from search button
            textBox1.Text = null;
            textBox2.Text = null;
            dataGridView1.Columns.Clear();
            string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = null;

            query = "select p.photograph as IMG,a.stuid as Student_ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,GENDER,apercent as Percentage from Attendance a,Person p,student s where a.stuid=s.stuid and s.pid=p.pid and " +
                     "a.sub=(select sub from semester where courseid = (select courseid from course " +
                         "where coursename='" + comboBox2.Text + "' and deptid=(select deptid from department where deptname='" + comboBox1.Text + "')) and semno='" + comboBox3.Text + "')";


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
                this.dataGridView1.Columns["Student_ID"].ReadOnly = true;
                this.dataGridView1.Columns["Full_Name"].ReadOnly = true;
                this.dataGridView1.Columns["Gender"].ReadOnly = true;

                this.dataGridView1.Columns["Full_Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns["Full_Name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns["Full_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns["IMG"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                if (this.dataGridView1.Columns["IMG"] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dataGridView1.Columns["IMG"]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                    dataGridView1.Rows[0].Cells["IMG"].Selected = false;
                }

                //adding new columns to datagridview by replacing character and header to multi line
                //string hi = "Rock tim Raj";
                //this.dataGridView1.Columns.Add("Hello", hi.Replace(" ", "\r\n"));

                //Making particular column only readonly
                //this.dataGridView1.Columns["Department"].ReadOnly = true;

                this.dataGridView1.EnableHeadersVisualStyles = false;
                this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("ARIAL", 9, FontStyle.Bold);
                this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
                this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.MistyRose;
                this.dataGridView1.DefaultCellStyle.BackColor = Color.LightCyan;
                this.dataGridView1.DefaultCellStyle.Font = new Font("ARIAL", 9, FontStyle.Bold);
                this.dataGridView1.DefaultCellStyle.ForeColor = Color.Red;
                // subjectadd();
                if (dataGridView1.Rows.Count > 0)
                    dataGridView1.Rows[0].Cells["Student_ID"].Selected = false;

                label16.Visible = true;
                label16.Text = "Displaying " + dataGridView1.RowCount + " Record";

                oda.Update(dbdataset);

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
                    dataGridView1.Rows[0].Cells["Student_ID"].Selected = false;
            }
        }

        //Searching through STUDENT ID
        void studentid()
        {
            dataGridView1.Columns.Clear();
            Name12.Visible = false;
            pictureBox1.Image = JIST.Properties.Resources.Users_icon;
            //Searching through STUDENT ID
            String str = "Data Source=localhost:1521/xe;user id=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "select p.photograph as IMG,a.stuid as Student_ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,GENDER,apercent as Percentage from Attendance a,Person p,student s where a.stuid=s.stuid and s.pid=p.pid and " +
                     "a.sub=(select sub from semester where courseid = (select courseid from course " +
                         "where coursename='" + comboBox2.Text + "' and deptid=(select deptid from department where deptname='" + comboBox1.Text + "')) and semno='" + comboBox3.Text + "')";
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
                this.dataGridView1.Columns["Student_ID"].ReadOnly = true;
                this.dataGridView1.Columns["Full_Name"].ReadOnly = true;
                this.dataGridView1.Columns["Gender"].ReadOnly = true;

                this.dataGridView1.Columns["Full_Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns["Full_Name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns["Full_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns["IMG"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                if (this.dataGridView1.Columns["IMG"] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dataGridView1.Columns["IMG"]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                }

                //adding new columns to datagridview by replacing character and header to multi line
                //string hi = "Rock tim Raj";
                //this.dataGridView1.Columns.Add("Hello", hi.Replace(" ", "\r\n"));

                //Making particular column only readonly
                //this.dataGridView1.Columns["Department"].ReadOnly = true;

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
                    dataGridView1.Rows[0].Cells["Full_Name"].Selected = false;
            }
        }

        //Searching through NAME
        void studentname()
        {
            dataGridView1.Columns.Clear();
            Name12.Visible = false;
            pictureBox1.Image = JIST.Properties.Resources.Users_icon;
            //Searching through NAME
            String str = "Data Source=localhost:1521/xe;user id=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "select p.photograph as IMG,a.stuid as Student_ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name,GENDER,apercent as Percentage from Attendance a,Person p,student s where a.stuid=s.stuid and s.pid=p.pid and " +
                     "a.sub=(select sub from semester where courseid = (select courseid from course " +
                         "where coursename='" + comboBox2.Text + "' and deptid=(select deptid from department where deptname='" + comboBox1.Text + "')) and semno='" + comboBox3.Text + "')";
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
                DV.RowFilter = string.Format("Full_Name like '%{0}%'", textBox2.Text);

                dataGridView1.DataSource = DV;
                this.dataGridView1.Columns["Student_ID"].ReadOnly = true;
                this.dataGridView1.Columns["Full_Name"].ReadOnly = true;
                this.dataGridView1.Columns["Gender"].ReadOnly = true;

                this.dataGridView1.Columns["Full_Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns["Full_Name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns["Full_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns["IMG"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                if (this.dataGridView1.Columns["IMG"] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dataGridView1.Columns["IMG"]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                }

                //adding new columns to datagridview by replacing character and header to multi line
                //string hi = "Rock tim Raj";
                //this.dataGridView1.Columns.Add("Hello", hi.Replace(" ", "\r\n"));

                //Making particular column only readonly
                //this.dataGridView1.Columns["Department"].ReadOnly = true;

                this.dataGridView1.EnableHeadersVisualStyles = false;
                this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("ARIAL", 9, FontStyle.Bold);
                this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
                this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.MistyRose;
                this.dataGridView1.DefaultCellStyle.BackColor = Color.LightCyan;
                this.dataGridView1.DefaultCellStyle.Font = new Font("ARIAL", 9, FontStyle.Bold);
                this.dataGridView1.DefaultCellStyle.ForeColor = Color.Red;
                if (dataGridView1.Rows.Count > 0)
                    dataGridView1.Rows[0].Cells["Full_Name"].Selected = true;


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
            string query = "select * from student where stuid='" + stuid + "'";
            OracleCommand cmd = new OracleCommand(query, con);
            OracleDataReader rdr;
            try
            {

                con.Open();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                int pid = rdr.GetInt32(1);
                personinfo(pid);
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //datagridview1 record selected and calling  studentinfo()
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Select data from datagridview1
            try
            {
                if (e.RowIndex >= 0)
                {
            
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    stuid = row.Cells["Student_ID"].Value.ToString();
                    string name = row.Cells["Full_Name"].Value.ToString();
                    Name12.Text = name;
                    Name12.Visible = true;
                    studentinfo();
                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //inserting attendance percentage in attendance table by pressing submit button
        private void button2_Click(object sender, EventArgs e)
        {
            //Confirmation of saving 
            DialogResult dialog = MessageBox.Show("Confirm Changes?", "Attendance", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.No)
            {


            }
            else if (dialog == DialogResult.Yes)
            {
                string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
                OracleConnection con = new OracleConnection(str);
                OracleCommand cmd = new OracleCommand();
                string query = null;
                cmd.Connection = con;
                try
                {
                    con.Open();
                    //Counting no of Rows
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                            string stid = this.dataGridView1.Rows[i].Cells["Student_ID"].Value.ToString();
                            query = "update Attendance set Apercent='" + dataGridView1.Rows[i].Cells["Percentage"].Value + "' where stuid='" + stid + "' and sub=(select sub from semester where semno='" + comboBox3.Text + "' and courseid=(select courseid from course where coursename='" + comboBox2.Text + "' and deptid=(select deptid from department where deptname='" + comboBox1.Text + "')))";
                            cmd.CommandText = query;
                            cmd.ExecuteNonQuery();
                       
                    }
                    MessageBox.Show("Attendance Stored Successfully");
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
       }

        //Stopping scrollbar to move up when click on datagridview1
        private void dataGridView1_MouseEnter(object sender, EventArgs e)
        {
            int vs = panel1.VerticalScroll.Value;
            ActiveControl = dataGridView1;
            panel1.VerticalScroll.Value = vs;
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
          
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
