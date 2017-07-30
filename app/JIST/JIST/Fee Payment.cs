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
    public partial class Fee_Payment : Form
    {

        string current,depid;
        int feecat,courid,examcurvalue;
        //Constructor call and initialize
        public Fee_Payment()
        {
            InitializeComponent();
            feecat = 0;
            sub = 0;
            connection();
            examcurvalue = 0;
            feedash.Normalcolor = Color.FromArgb(252, 86, 83);
            pictureBox2.Visible = false;
            Pay.Enabled = false;

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
                string fname, mname, lname;
                fname = rdr.GetString(2);
                lname = rdr.GetString(4);
                if (Convert.IsDBNull(rdr["mname"])) { mname = null; }
                else
                {
                    mname = rdr.GetString(3);
                }

                textBox2.Text = fname + " " + mname + " " + lname;

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
                    }
                }
                con.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // insert semester in combobox1
        void semester(string current)
        {
            // insert semester in combobox1

            string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "select max(semno) from semester where courseid=(select courseid from student_course where stuid='" + textBox1.Text + "')";
            OracleCommand cmd = new OracleCommand(query, con);
            OracleDataReader rdr;
            try
            {
                con.Open();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                int semno = rdr.GetInt32(0);
                int curtsta = Convert.ToInt32(current);
                if(curtsta<semno)
                {
                    int s = curtsta + 1;
                    for (int a = 1; a <= s; a++)
                        comboBox1.Items.Add(a);
                }
                else
                {
                    for(int a=1;a<=semno;a++)
                    {
                        comboBox1.Items.Add(a);
                    }
                }
                con.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // insert coursename in textBox4
        void coursename()
        {

            // insert coursename in textBox4

            string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "select coursename from course where courseid=(select courseid from student_course where stuid='"+textBox1.Text+"')";
            OracleCommand cmd = new OracleCommand(query, con);
            OracleDataReader rdr;
            try
            {
                con.Open();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                string coursename = rdr.GetString(0);
                textBox4.Text = coursename;
                con.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //inserting department name in textbox3
        void department(string dptid)
        {
            //inserting department name in textbox3
            string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "select deptname from Department where deptid='" + dptid + "'";

            OracleCommand cmd = new OracleCommand(query, con);
            OracleDataReader rdr;
            try
            {
                con.Open();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                string deptname = rdr.GetString(0);
                textBox3.Text = deptname;
                coursename();
                con.Dispose();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Retrieve student info through studentID
        void studentinfo()
        {
            // Retrieve student info through studentID

            string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "select * from student where stuid='"+textBox1.Text+"'";
            OracleCommand cmd = new OracleCommand(query, con);
            OracleDataReader rdr;
            try
            {

                con.Open();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                if (rdr.HasRows)
                {
                    int pid = rdr.GetInt32(1);
                    string dptid = rdr.GetString(2);
                    current = rdr.GetString(5);
                    department(dptid);
                    semester(current);
                    personinfo(pid);
                }
                //else
                //{
                //    MessageBox.Show("No datafound");
                //}
                con.Dispose();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        //Form close
        private void Fee_Payment_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //Back button to homepage
        private void button4_Click(object sender, EventArgs e)
        {
            homepage hom = new homepage();
            this.Hide();
            hom.ShowDialog();
        }

        //Searching data through student ID by calling studentinfo()
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Searching data through student ID
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            comboBox1.Items.Clear();
            textBox24.Text = null;
            textBox25.Text = null;
            textBox26.Text = null;
            textBox27.Text = null;
            textBox28.Text = null;
            textBox29.Text = null;
            textBox30.Text = null;
            textBox31.Text = null;
            textBox32.Text = null;
            textBox33.Text = null;
            textBox34.Text = null;
            current = null;
            pictureBox2.Visible = false;
            Pay.Enabled = false;
            pictureBox1.Image = JIST.Properties.Resources.Users_icon;
            studentinfo();
        }

        // Insert Fee Detail textbox
        void Fee()
        {
            // Insert Fee Detail textbox
            string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "select * from FEE where courseID=(select courseId from student_course where stuid='"+textBox1.Text+"')";
            OracleCommand cmd = new OracleCommand(query, con);
            OracleDataReader rdr;
            try
            {
                con.Open();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                feecat = rdr.GetInt32(0);
                int f1 = rdr.GetInt32(1);
                int f2 = rdr.GetInt32(2);
                int f3 = rdr.GetInt32(3);
                int f4 = rdr.GetInt32(4);
                int f5 = rdr.GetInt32(5);
                int f6 = rdr.GetInt32(6);
                int f7 = rdr.GetInt32(7);
                int f8 = rdr.GetInt32(8);
                int f9 = rdr.GetInt32(9);
                int f10 = rdr.GetInt32(10);
                //courseid = rdr.GetInt32(11);

                textBox24.Text = f1.ToString();
                textBox25.Text = f2.ToString();
                textBox26.Text = f3.ToString();
                textBox27.Text = f4.ToString();
                textBox28.Text = f5.ToString();
                textBox29.Text = f6.ToString();
                textBox30.Text = f7.ToString();
                textBox31.Text = f8.ToString();
                textBox32.Text = f9.ToString();
                textBox33.Text = f10.ToString();
                textBox34.Text = (f1 + f2 + f3 + f4 + f5 + f6 + f7 + f8 + f9 + f10).ToString();
                con.Dispose();
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //calling fee() for fee detail and checking fees paid by showing picture
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cursts = Convert.ToInt32(current);
            if (Convert.ToInt32(comboBox1.Text) <= cursts)
            {
                pictureBox2.Visible = true;
                Pay.Enabled = false;
            }
            else
            {
                pictureBox2.Visible = false;
                Pay.Enabled = true;
            }
            Fee();
        }

        private void Fee_Payment_Load(object sender, EventArgs e)
        {

        }

        //Getting current value from exam sequence
        void sequencecurval()
        {
            //Getting current value from exam sequence
            string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query4 = "select EXAMSEQ.nextval from DUAL";
            string query5 = "drop sequence EXAMSEQ";
            OracleCommand cmd4 = new OracleCommand(query4, con);
            OracleCommand cmd5 = new OracleCommand(query5, con);
            OracleDataReader rdr4, rdr5;
            try
            {
                con.Open();
                rdr4 = cmd4.ExecuteReader();
                rdr5 = cmd5.ExecuteReader();
                rdr4.Read();
                rdr5.Read();
                examcurvalue = rdr4.GetInt32(0);
                sequencecreate();
                con.Dispose();
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
            string query2 = "select EXAMSEQ.nextval from DUAL";
            OracleCommand cmd2 = new OracleCommand(query2, con);
            OracleDataReader rdr2;
            try
            {
                con.Open();
                rdr2 = cmd2.ExecuteReader();
                rdr2.Read();
                studentupdate();
                con.Dispose();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //del();
            }
        }

        // Creating Exam sequence
        void sequencecreate()
        {
            // Creating Exam sequence
            string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query2 = "create sequence EXAMSEQ minvalue 1 maxvalue 999999 start with " + examcurvalue + " increment by 1 nocycle order NOCACHE";
            OracleCommand cmd2 = new OracleCommand(query2, con);
            OracleDataReader rdr2;
            try
            {
                con.Open();
                rdr2 = cmd2.ExecuteReader();
                rdr2.Read();
                con.Dispose();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Retrieve paperid and calling examsubinsert(papid),sequencenextval()
        void paperid()
        {
            try
            {
                string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
                OracleConnection con = new OracleConnection(str);
                string query = null;
                query = "select paperid from subject where sub='" + sub + "'";
                OracleCommand cmd = new OracleCommand(query, con);
                OracleDataReader rdr;
                con.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int papid = rdr.GetInt32(0);
                    examsubinsert(papid);
                }
                sequencenextval();
                con.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //delfeeattendexam();
            }
        }

        //insert data into examsubinset() table
        void examsubinsert(int papid)
        {
            try
            {
                string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
                OracleConnection con = new OracleConnection(str);
                string query = null;
                query = "insert into exam_sub(examid,paperid) values('"+examcurvalue+"','" + papid + "')";
                OracleCommand cmd = new OracleCommand(query, con);
                OracleDataReader rdr;
                con.Open();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                con.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //delfeeattendexam();
            }

        }

        //insert data into Exam table and calling paperid()
        void Examinsert()
        {
            sequencecurval();
            try
            {
                string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
                OracleConnection con = new OracleConnection(str);
                string query = null;

                query = "insert into exam values('"+textBox1.Text+"','" +courid+ "','" + sub + "','" +depid+ "','"+examcurvalue+"')";
                OracleCommand cmd = new OracleCommand(query, con);
                OracleDataReader rdr;
                con.Open();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                paperid();
                con.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               // delfreeinsertattend();
            }
        }

        //Retrieving departId and courseID from Exam table
        void deptcour()
        {
            try
            {

                string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
                OracleConnection con = new OracleConnection(str);
                string query = null;
                query = "select DEPTID,COURSEID from EXAM where STUID='"+textBox1.Text+"'";
                OracleCommand cmd = new OracleCommand(query, con);
                OracleDataReader rdr;
                con.Open();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                depid = rdr.GetString(0);
                courid = rdr.GetInt32(1);
                con.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //del();
            }
        }

        //inserting data into attendance table and calling Examinset()
        void attendance()
        {
            deptcour();
            try
            {

                string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
                OracleConnection con = new OracleConnection(str);
                string query = null;
                query = "insert into ATTENDANCE(DEPTID,STUID,COURSEID,SUB) values('"+depid+"','" + textBox1.Text + "','" + courid + "','" + sub + "')";
                OracleCommand cmd = new OracleCommand(query, con);
                OracleDataReader rdr;
                con.Open();
                rdr = cmd.ExecuteReader();
                rdr.Read();
            
                Examinsert();
                con.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //delfeeinsert();
            }
        }



        //Retreieve sub from semester
        int sub;
        void semester()
        {
            try
            {
                string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
                OracleConnection con = new OracleConnection(str);
                string query = null;
                query = "select sub from semester where courseid=(select courseid from student_course where stuid='" + textBox1.Text + "') and semno='" + comboBox1.Text+"'";
                OracleCommand cmd = new OracleCommand(query, con);
                OracleDataReader rdr;
                con.Open();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                sub = rdr.GetInt32(0);
                con.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Closing form when click on cross button
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Minimize form when click minimized button
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


        //Inserting data in student_fee table and calling attendance()
        void studentfeeinsert()
        {
            try
            {
                semester();
                string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
                OracleConnection con = new OracleConnection(str);
                string query = null;
                query = "insert into STUDENT_FEE values('" + feecat + "','"+textBox1.Text+"','" + sub + "')";
                OracleCommand cmd = new OracleCommand(query, con);
                OracleDataReader rdr;
                con.Open();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                attendance();
                con.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Student current status update
        void studentupdate()
        {

            string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query = "update student set currentstatus='"+comboBox1.Text+"' where stuid='"+textBox1.Text+"'";

            OracleCommand cmd = new OracleCommand(query, con);
            OracleDataReader rdr;
            try
            {
                con.Open();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                MessageBox.Show("Fee Paid successfully");
                feecat = 0;
                //Refreshing screen
                pictureBox2.Visible = true;
                string sem = comboBox1.Text;
                comboBox1.Items.Clear();
                Pay.Enabled = false;
                studentinfo();
                comboBox1.Text = sem;
                con.Dispose();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //deletefeeinsertattenexaminsert()
            }
        }

        //Pay button press and calling studentfeeinsert() and studentupdate()
        private void Pay_Click(object sender, EventArgs e)
        {
            sub = 0;
            depid = null;
            courid = 0;
            studentfeeinsert();
        }
    }
}
