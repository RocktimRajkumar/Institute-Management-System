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
    public partial class homepage : Form
    {
        int a,b,c,d,f;
        string staffid,uname,date12;
        static string usernam,lastlog;
        //Construction calling and initialization
        public homepage()
        {
            InitializeComponent();
            connection();
            a =b=c=d=f= 0;
            staffid = null;
            homepagedash.Normalcolor = Color.FromArgb(252, 86, 83);
            pictureBox2.Visible = false;
            label1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            roundpicturebox(pictureBox1);
            lastlogin.Text = lastlog;
            timer1.Start();
          
        }

        //Parameter construction calling and initializing when login
        public homepage(string usname)
        {
            usernam = usname;
            InitializeComponent();
            connection();
            a = b = c = d = f = 0;
            staffid = null;
            pictureBox2.Visible = false;
            label1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;

            homepagedash.Normalcolor = Color.FromArgb(252, 86, 83);
            //homepagedash.Enabled = false;

            roundpicturebox(pictureBox1);
            datetime1(usernam);
            insertcurretdatetime(usernam);
            timer1.Start();
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

        //Viewing lastlogin time and date when login
        public void datetime1(string usname)
        {

            string str = "DATA SOURCE=localhost:1521/xe;USER ID = IMS; Password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "Select * from LASTLOGIN where username='" + usname + "' order by sdatetime desc";

            OracleCommand cmd = new OracleCommand(query, con);

            OracleDataReader rdr;
            try
            {
                con.Open();

                rdr = cmd.ExecuteReader();
                rdr.Read();
                if (rdr.HasRows)
                {

                    lastlogin.Text = ("Last Login : " + ((rdr.GetDateTime(1)).ToString("dd-MMM-yyyy  hh:mm:ss tt")).ToUpper());
                    lastlog = lastlogin.Text;
                    date12 = rdr.GetDateTime(1).ToString("dd-MMM-yyyy  hh:mm:ss tt");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Storing current date and time to lastlogin table when login
        void insertcurretdatetime(string usname)
        {

            string date11 = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");


            string str = "DATA SOURCE=localhost:1521/xe;USER ID = IMS; Password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "insert into LASTLOGIN(Username,SDATETIME) values('" + usname + "','" + date11 + "')";
            OracleCommand cmd = new OracleCommand(query, con);
            OracleDataReader rdr;
            try
            {
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

        //Storing current date and time to lastlogin table when sign out
         void insertcurretdt()
        {

            string date11 = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
             
            datetime1(usernam);
            string str = "DATA SOURCE=localhost:1521/xe;USER ID = IMS; Password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "update LASTLOGIN set EDATETIME='"+date11+"' where username='"+usernam+"' and SDATETIME='"+date12+"'";
            OracleCommand cmd = new OracleCommand(query, con);
            OracleDataReader rdr;
            try
            {
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

        //Incrementing  current time
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            time_lbl.Text = ("Time : "+(datetime.ToString("dd-MMM-yyyy   hh:mm:ss tt").ToUpper()));
        }

        //making picturebox round
        void roundpicturebox(PictureBox pictureBox)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width - 3, pictureBox.Height - 3);
            pictureBox.Region = new Region(path);
           
        }

        //checking connection
        void connection()
        {
            try
            {
                string str = "DATA SOURCE=localhost:1521/xe;USER ID = IMS; Password=enteryourchoice";
                OracleConnection mycon = new OracleConnection(str);
                mycon.Open();
                loadaccount();
                mycon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Loading user data in account and setting
        void loadaccount()
        {
            string str = "DATA SOURCE=localhost:1521/xe;USER ID = IMS; Password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "select p.photograph,ad.username,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name from admin ad join person p on ad.pid = p.pid where ad.username = '"+usernam+"'";

            OracleCommand cmd = new OracleCommand(query, con);

            OracleDataReader rdr;
            try
            {
                con.Open();

                rdr = cmd.ExecuteReader();
                rdr.Read();
                string username = rdr.GetString(1);
                string name = rdr.GetString(2);
                toolstripbutton3.Text = username;
                label1.Text = name;

                byte[] imgg = (byte[])(rdr["PHOTOGRAPH"]);
                if (imgg == null)
                {
                    pictureBox1.Image = null;
                }
                else
                {
                    MemoryStream mstream = new MemoryStream(imgg);
                    pictureBox1.Image = System.Drawing.Image.FromStream(mstream);
                    pictureBox2.Image = System.Drawing.Image.FromStream(mstream);
                   
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Opening admission page when click on admission and registration button
        private void button2_Click(object sender, EventArgs e)
        {
            Admission_Registration admission = new Admission_Registration();
            this.Hide();
            admission.ShowDialog();
        }

        //Form closing
        private void homepage_FormClosed(object sender, FormClosedEventArgs e)
        {
            insertcurretdt();
            Application.Exit();
        }

        //Opening studentmanagement page when click on studentmanagement button
        private void button1_Click(object sender, EventArgs e)
        {
            StudentManagement stud = new StudentManagement();
            this.Hide();
            stud.ShowDialog();
        }

        //Opening Fee_payment page when click on fee_payment button
        private void button4_Click(object sender, EventArgs e)
        {
            Fee_Payment fee = new Fee_Payment();
            this.Hide();
            fee.ShowDialog();
        }

        //Opening ExamManagement page when click on Exammanagement button
        private void button5_Click(object sender, EventArgs e)
        {
            ExamManagement ex = new ExamManagement();
            this.Hide();
            ex.ShowDialog();
        }

        //Opening Attendance page when click on Attendance button
        private void button6_Click(object sender, EventArgs e)
        {
            Attendance at = new Attendance();
            this.Hide();
            at.ShowDialog();
        }

        //Opening collective_informatoin page when click collective informatoin button
        private void button7_Click(object sender, EventArgs e)
        {
            CollectiveInformation ci = new CollectiveInformation();
            this.Hide();
            ci.ShowDialog();
        }

        //Opening Staffmanagement page when click staffmanagement button
        private void button3_Click(object sender, EventArgs e)
        {
            StaffManagement stm = new StaffManagement();
            this.Hide();
            stm.ShowDialog();
        }

        //Disable panel when click on panel2
        private void panel2_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;

            toolStripButton1.BackColor = Color.White;
            toolStripButton2.BackColor = Color.White;
            toolStripButton4.BackColor = Color.White;
            toolStripButton5.BackColor = Color.White;

            c = 0;
            b = 0;
            d = 0;
            f = 0;
        }

        //Viewing add admin when click on Add admin
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            button9.IconVisible = false;
            panel3.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            button9.Enabled = false;
            toolStripButton4.BackColor = Color.White;
            toolStripButton1.BackColor = Color.White;
            toolStripButton5.BackColor = Color.White;

            b = 0;
            d = 0;
            f = 0;

            if (c == 0)
            {
                panel4.Visible = true;
                toolStripButton2.BackColor = Color.LightGreen;
                c = 1;
                loadperson();
            }
            else
            {
                panel4.Visible = false;
                panel5.Visible = false;
                toolStripButton2.BackColor = Color.White;
                c = 0;
                dataGridView1.DataSource = null;

            }
            
            
        }

        //loading pid and name from person in datagridview1
        void loadperson()
        {
            string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "select p.photograph as Image,sc.staffid as Staff_ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name from person p join Office_staff sc on sc.pid=p.pid left join admin ad on sc.pid=ad.pid where sc.designation='Admin' and ad.pid is null order by fname,mname,lname";
          
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
                this.dataGridView1.Columns["Full_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dataGridView1.Columns["Staff_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView1.Columns["Image"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                if (this.dataGridView1.Columns["Image"] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dataGridView1.Columns["Image"]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                }
                this.dataGridView1.EnableHeadersVisualStyles = false;
                this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("ARIAL", 9, FontStyle.Bold);
                this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
                this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.MistyRose;
                this.dataGridView1.DefaultCellStyle.BackColor = Color.LightCyan;
                this.dataGridView1.DefaultCellStyle.Font = new Font("ARIAL", 9, FontStyle.Bold);
                this.dataGridView1.DefaultCellStyle.ForeColor = Color.Red;
                this.dataGridView1.ScrollBars = ScrollBars.Horizontal;
                if (dataGridView1.Rows.Count > 0)
                    dataGridView1.Rows[0].Selected = false;

                oda.Update(dbdataset);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Creating username and password when click on add button
        private void button9_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            button9.IconVisible = false;
            button9.Enabled = false;
            label10.Visible = false;
            textBox6.Text = null;
            textBox7.Text = null;
            textBox9.Text = null;

        }

        //Enabling add button when click on cancel button
        private void button11_Click(object sender, EventArgs e)
        {
            button9.Enabled = true;
            button9.IconVisible = true;
            panel5.Visible = false;
        }

        //Viewing remove panel when click on remove admin
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel5.Visible = false;
            panel3.Visible = false;
            panel7.Visible = false;
            button12.Enabled = false;

            toolStripButton2.BackColor = Color.White;
            toolStripButton1.BackColor = Color.White;
            toolStripButton1.BackColor = Color.White;

            c = 0;
            b = 0;
            f = 0;

            if (d==0)
            {
                panel6.Visible = true;
                toolStripButton4.BackColor = Color.LightGreen;
                d = 1;
                loadadminperson();
            }
            else
            {
                panel6.Visible = false;
                toolStripButton4.BackColor = Color.White;
                d = 0;
                dataGridView2.DataSource = null;
            }

        }

        //loading image,username,staffid, name from admin in datagridview2
        void loadadminperson()
        {

            string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "select p.photograph as Image,ad.username as Username,sc.staffid as Staff_ID,upper(p.fname)||' '||upper(p.mname)||' '||upper(p.lname) as Full_Name from admin ad left join person p on ad.pid = p.pid join office_staff sc on ad.pid = sc.pid order by fname,mname,lname";

            OracleCommand cmd = new OracleCommand(query, con);

            try
            {
                OracleDataAdapter oda = new OracleDataAdapter();
                oda.SelectCommand = cmd;
                DataTable dbdataset = new DataTable();
                oda.Fill(dbdataset);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dbdataset;
                dataGridView2.DataSource = bsource;
                this.dataGridView2.Columns["Full_Name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                this.dataGridView2.Columns["Full_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dataGridView2.Columns["Staff_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView2.Columns["Image"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dataGridView2.Columns["Username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                if (this.dataGridView2.Columns["Image"] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dataGridView2.Columns["Image"]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                }
                this.dataGridView2.EnableHeadersVisualStyles = false;
                this.dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("ARIAL", 9, FontStyle.Bold);
                this.dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
                this.dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.MistyRose;
                this.dataGridView2.DefaultCellStyle.BackColor = Color.LightCyan;
                this.dataGridView2.DefaultCellStyle.Font = new Font("ARIAL", 9, FontStyle.Bold);
                this.dataGridView2.DefaultCellStyle.ForeColor = Color.Red;
                this.dataGridView2.ScrollBars = ScrollBars.Horizontal;
                if (dataGridView2.Rows.Count > 0)
                    dataGridView2.Rows[0].Selected = false;

                oda.Update(dbdataset);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Showing login history when click on login history button
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;

            toolStripButton1.BackColor = Color.White;
            toolStripButton2.BackColor = Color.White;
            toolStripButton4.BackColor = Color.White;

            b = 0;
            c = 0;
            d = 0;

            if (f==0)
            {
                panel7.Visible = true;
                toolStripButton5.BackColor = Color.LightGreen;
                f = 1;
                string str = "DATA SOURCE=localhost:1521/xe;USER ID = IMS; Password=enteryourchoice";
                OracleConnection con = new OracleConnection(str);
                string query = "Select to_char(sdatetime,'dd/MON/yyyy HH.MI.SS AM') as LogIn,to_char(edatetime,'dd/MON/yyyy HH.MI.SS AM') as LogOut from LASTLOGIN where username='" + usernam + "' order by sdatetime desc";

                OracleCommand cmd = new OracleCommand(query, con);
                try
                {
                    OracleDataAdapter oda = new OracleDataAdapter();
                    oda.SelectCommand = cmd;
                    DataTable dbdataset = new DataTable();
                    oda.Fill(dbdataset);
                    BindingSource bsource = new BindingSource();
                    bsource.DataSource = dbdataset;
                    dataGridView3.DataSource = bsource;
                    
                    this.dataGridView3.Columns["LogIn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dataGridView3.Columns["LogOut"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dataGridView3.EnableHeadersVisualStyles = false;
                    this.dataGridView3.ColumnHeadersDefaultCellStyle.Font = new Font("ARIAL", 9, FontStyle.Bold);
                    this.dataGridView3.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
                    this.dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = Color.MistyRose;
                    this.dataGridView3.DefaultCellStyle.BackColor = Color.LightCyan;
                    this.dataGridView3.DefaultCellStyle.Font = new Font("ARIAL", 9, FontStyle.Bold);
                    this.dataGridView3.DefaultCellStyle.ForeColor = Color.Red;
                    if (dataGridView3.Rows.Count > 0)
                        dataGridView3.Rows[0].Selected = false;

                    oda.Update(dbdataset);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                panel7.Visible = false;
                toolStripButton5.BackColor = Color.White;
                f = 0;
            }
        }

        //Signing out when click on Sign Out button
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            insertcurretdt();
            Login log = new Login();
            this.Hide();
            log.ShowDialog();
            
        }

        //Creating username and password and storin in admin table
        private void button10_Click(object sender, EventArgs e)
        {
            label10.Visible = false;
            if (String.IsNullOrWhiteSpace(textBox9.Text) || String.IsNullOrWhiteSpace(textBox7.Text) || String.IsNullOrWhiteSpace(textBox6.Text))
            {
                label10.Visible = true;
                label10.Text = "Please Enter Username and Password";
            }
            else
            {
                try
                {
                    string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
                    OracleConnection con = new OracleConnection(str);
                    string query ="select username from admin where username='" + textBox9.Text + "'";
                    OracleCommand cmd = new OracleCommand(query, con);
                    OracleDataReader rdr;
                    con.Open();
                    rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        label10.Visible = true;
                        label10.Text = "Username already exist";
                        con.Close();
                        
                    }
                    else
                    {
                        if(textBox7.Text != textBox6.Text)
                        {
                           
                            label10.Visible = true;
                            label10.Text = "Confirm Password didn't match";
                            con.Close();
                        }
                        else
                        {
                            try
                            {
                                string strn = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
                                OracleConnection con1 = new OracleConnection(strn);
                                string query1 ="insert into ADMIN values('"+textBox9.Text+"','"+textBox7.Text+"',(select pid from OFFICE_STAFF where staffid='"+staffid+"'))";

                                OracleCommand cmd1 = new OracleCommand(query1, con1);
                                OracleDataReader rdr1;
                                con1.Open();
                                rdr1 = cmd1.ExecuteReader();
                                rdr1.Read();
                                MessageBox.Show("Account Created Successfully");
                                panel5.Visible = false;
                                dataGridView1.DataSource = null;
                                loadperson();
                                con1.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //select data from datagridview1
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {

                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    staffid = row.Cells["Staff_ID"].Value.ToString();
                    button9.Enabled = true;
                    button9.IconVisible = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //disable add button when not click on content of datagridview1
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button9.Enabled = false;
        }

        //changing username and password
        private void button8_Click(object sender, EventArgs e)
        {
            label12.Visible = false;
            if (String.IsNullOrWhiteSpace(textBox1.Text) || String.IsNullOrWhiteSpace(textBox2.Text) || String.IsNullOrWhiteSpace(textBox3.Text) || String.IsNullOrWhiteSpace(textBox4.Text) || String.IsNullOrWhiteSpace(textBox5.Text))
            {
                label12.Visible = true;
                label12.Text = "Some Fields cannot be empty";
            }
            else
            {
                userpassword();
            }
        }

        //checking old username and password
        void userpassword()
        {
            try
            {
                string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
                OracleConnection mycon = new OracleConnection(str);
                OracleCommand SelectCommand = new OracleCommand("select * from ADMIN where USERNAME ='" + textBox1.Text + "' and password='" + textBox3.Text + "' and username='"+usernam+"'", mycon);
                OracleDataReader myReader;
                mycon.Open();
                myReader = SelectCommand.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {

                    if(textBox4.Text==textBox5.Text)
                    {
                        try
                        {
                            string strn = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
                            OracleConnection con1 = new OracleConnection(strn);
                            string query1 = "alter table LASTLOGIN disable constraint LASTLOGIN_FK1";
                            string query2 = "update ADMIN set username='" + textBox2.Text + "',password='" + textBox4.Text + "' where username='" + usernam + "'";
                            string query3 = "update LASTLOGIN set username='" + textBox2.Text + "' where username='" + usernam + "'";
                            string query4 = "alter table LASTLOGIN enable constraint LASTLOGIN_FK1";

                            OracleCommand cmd1 = new OracleCommand(query1, con1);
                            OracleCommand cmd2 = new OracleCommand(query2, con1);
                            OracleCommand cmd3 = new OracleCommand(query3, con1);
                            OracleCommand cmd4 = new OracleCommand(query4, con1);

                            OracleDataReader rdr1,rdr2,rdr3,rdr4;
                            con1.Open();
                            rdr1 = cmd1.ExecuteReader();
                            rdr2 = cmd2.ExecuteReader();
                            rdr3 = cmd3.ExecuteReader();
                            rdr4 = cmd4.ExecuteReader();
                            rdr1.Read();
                            rdr2.Read();
                            rdr3.Read();
                            rdr4.Read();
                            MessageBox.Show("Account Changed");
                            con1.Close();
                        
                            Login log = new Login();
                            this.Hide();
                            usernam = textBox2.Text;
                            insertcurretdt();
                            log.ShowDialog();
                   
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        label12.Visible = true;
                        label12.Text = "Confirm Password didn't match";
                    }

                }

                else
                {
                    label12.Visible = true;
                    label12.Text = "Old Username and password is incorrect";
                }
                mycon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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



        //disable delete button when not click on content of datagridview2
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button12.Enabled = false;
        }

        // Removing staff from admin
        private void button12_Click(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount > 1)
            {
                try
                {
                    string strn = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
                    OracleConnection con1 = new OracleConnection(strn);
                    string query1 = "delete from admin where username='" + uname + "'";

                    OracleCommand cmd1 = new OracleCommand(query1, con1);
                    OracleDataReader rdr1;
                    con1.Open();
                    rdr1 = cmd1.ExecuteReader();
                    rdr1.Read();
                    MessageBox.Show("Account Discharged");
                    dataGridView2.DataSource = null;
                    loadadminperson();
                    con1.Close();
                    button12.Enabled = false;
                    if(uname==usernam)
                    {
                        Login log = new Login();
                        this.Hide();
                        log.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Atleast one Admin necessary");
            }

        }


        //select data from datagridview2
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {

                    DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                    uname= row.Cells["Username"].Value.ToString();
                    button12.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Viewing and disabling detail when click on toolstrip button
        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel5.Visible = false;
            panel3.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;

            toolStripButton1.BackColor = Color.White;
            toolStripButton2.BackColor = Color.White;
            toolStripButton4.BackColor = Color.White;
            toolStripButton5.BackColor = Color.White;

            b = 0;
            c = 0;
            d = 0;
            f = 0;

            if (a == 0)
            {
                panel2.Visible = true;
                pictureBox2.Visible = true;
                label1.Visible = true;              
                roundpicturebox(pictureBox2);
                a = 1;
            }
            else
            {
                panel2.Visible = false;
                pictureBox2.Visible = false;
                label1.Visible = false;
                a = 0;
            }
            
        }

        //Panel12 disable when click on homepage
        private void homepage_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            pictureBox2.Visible = false;
            label1.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            a = 0;
        }

        //Panel12 disable when click on panel1
        private void panel1_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            pictureBox2.Visible = false;
            label1.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
           
            a = 0;

        }

        //View Editoption when click on Edit Account
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            label12.Visible = false;

            toolStripButton2.BackColor = Color.White;
            toolStripButton4.BackColor = Color.White;
            toolStripButton5.BackColor = Color.White;

            c = 0;
            d = 0;
            f = 0;

            if (b == 0)
            {
                panel3.Visible = true;
                toolStripButton1.BackColor = Color.LightGreen;
                b = 1;
            }
            else
            {
                panel3.Visible = false;
                toolStripButton1.BackColor = Color.White;
                b = 0;
            }

            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;

       }

    }
}
