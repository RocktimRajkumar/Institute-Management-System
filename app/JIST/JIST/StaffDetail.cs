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
using System.Drawing.Printing;
using System.IO;

namespace JIST
{
    public partial class StaffDetail : Form
    {
        //Constructor calling and initializing
        public StaffDetail()
        {
            InitializeComponent();
            connection();
            collectivedash.Normalcolor = Color.FromArgb(252, 86, 83);
            bunifuThinButton21.Visible = false;
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

        //Back button
        private void button4_Click(object sender, EventArgs e)
        {
            CollectiveInformation clinf = new CollectiveInformation();
            this.Hide();
            clinf.ShowDialog();
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

        //calling teachoffid() when key pressed on textbox1 and calling makingnull(),teachoffid()
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //calling studentid
            pictureBox1.Image = JIST.Properties.Resources.Users_icon;
            makingnull();
            teachoffid();

        }

        //making all field null
        void makingnull()
        {
            textBox4.Text = null;
            textBox23.Text = null;
            textBox24.Text = null;
            textBox25.Text = null;
            textBox10.Text = null;
            textBox16.Text = null;
            textBox17.Text = null;
            textBox18.Text = null;
            textBox20.Text = null;
            textBox21.Text = null;
            textBox14.Text = null;
            textBox6.Text = null;
            textBox8.Text = null;
            textBox9.Text = null;
            textBox22.Text = null;
            textBox27.Text = null;
            textBox28.Text = null;
            textBox11.Text = null;
            textBox12.Text = null;
            textBox26.Text = null;
            textBox13.Text = null;
            textBox3.Text = null;
            textBox5.Text = null;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox2.Text = null;
            textBox7.Text = null;
            textBox19.Text = null;
            textBox15.Text = null;
            textBox29.Text = null;
            textBox30.Text = null;
        }

        //Searching through Teaching staff ID or Office staff ID and calling department(dptid) and personinfo(pid)
        void teachoffid()
        {

            string str = "DATA SOURCE=localhost:1521/xe; USER ID=IMS;password=enteryourchoice";
            OracleConnection con = new OracleConnection(str);
            string query;
            if(textBox1.Text.StartsWith("T"))
               query= "select pid,designation,salary,qualification,previous_work_exp,specialization,deptid from teaching_staff where TSID='"+textBox1.Text+"' ";
            else
            query = "select pid,designation,salary,qualification,previous_work_exp from office_staff where staffid='" + textBox1.Text+"'";
            OracleCommand cmd = new OracleCommand(query, con);
            OracleDataReader rdr;
            try
            {

                con.Open();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                if (rdr.HasRows)
                {
                    int pid = rdr.GetInt32(0);
                    string designation = rdr.GetString(1);
                    int salary = rdr.GetInt32(2);
                    string qualification = rdr.GetString(3);
                    textBox29.Text = designation;
                    textBox23.Text = qualification;
                    textBox25.Text = salary.ToString() ;
                    personinfo(pid);
                    if (Convert.IsDBNull(rdr["previous_work_exp"]))
                    {

                    }
                    else
                    {
                        string previous = rdr.GetString(4);

                        textBox2.Text = previous;
                    }
                    if(textBox1.Text.StartsWith("T"))
                    {
                        label18.Visible = true;
                        label3.Visible = true;
                        textBox30.Visible = true;
                        textBox24.Visible = true;
                        if(Convert.IsDBNull(rdr["specialization"]))
                        { }
                        else
                        {
                            string special = rdr.GetString(5);
                            textBox30.Text = special;
                        }
                        string deptid = rdr.GetString(6);
                        department(deptid);
                    }
                    else
                    {
                        textBox30.Visible = false;
                        textBox24.Visible = false;
                        label18.Visible = false;
                        label3.Visible = false;
                    }
                    bunifuThinButton21.Visible = true;
                }
                else
                {
                    bunifuThinButton21.Visible = false;
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //inserting department name in textbox24
        void department(string dptid)
        {
            //inserting department name in textbox24
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
                textBox24.Text = deptname;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Retrieve information from person table and calling Examid()
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
                    textBox4.Text = mname;
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

                textBox3.Text = fname;
                textBox5.Text = lname;
                textBox26.Text = dob;
                //displaying age
                calculateage(Convert.ToDateTime(rdr["DOB"]).ToString("dd"), Convert.ToDateTime(rdr["DOB"]).ToString("MM"), Convert.ToDateTime(rdr["DOB"]).ToString("yyyy"));
                textBox11.Text = nationality;
                textBox12.Text = religion;
                textBox27.Text = caste;
                textBox28.Text = bg;
                if (gender == "M")
                    radioButton1.Checked = true;
                else if (gender == "F")
                    radioButton2.Checked = true;
                textBox6.Text = ffname;
                textBox8.Text = flname;
                textBox9.Text = mfname;
                textBox22.Text = mlname;
                textBox14.Text = add;
                textBox16.Text = district;
                textBox17.Text = state;
                textBox18.Text = pincode.ToString();
                textBox20.Text = postoffice;
                textBox21.Text = email;
                textBox10.Text = phoneno.ToString();

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
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //calculating age
        void calculateage(string bdate, string bmonth, string byear)
        {
            // calculating age and display in age box

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

        //printpreview the document
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
            //printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.Document = printDocument1;
            //print preview dialog size
            printPreviewDialog1.ClientSize = new System.Drawing.Size(500, 600);

            //Overriding print function in print preview dialog
            ToolStripButton b = new ToolStripButton();
            b.Image = JIST.Properties.Resources.print;
            b.DisplayStyle = ToolStripItemDisplayStyle.Image;
            b.Click += printPreviewDialog1_Click;
            ((System.Windows.Forms.ToolStrip)(printPreviewDialog1.Controls[1])).Items.RemoveAt(0);
            ((System.Windows.Forms.ToolStrip)(printPreviewDialog1.Controls[1])).Items.Insert(0, b);
            printPreviewDialog1.ShowDialog();
        }

        private void printPreviewDialog1_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }

            //pageSetupDialog1.Document = printDocument1;
            //pageSetupDialog1.ShowDialog();
        }


        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {

            //print the panel

            Bitmap bm = new Bitmap(panel2.Width, panel2.Height);
            panel2.DrawToBitmap(bm, new Rectangle(0, 0, panel2.Width, panel2.Height));
            e.Graphics.DrawImage(bm, e.PageBounds);
        }
    }
}
