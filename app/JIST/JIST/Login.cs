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
using System.Threading;


namespace JIST
{
    public partial class Login : Form
    {
        //Construction calling initialization
        public Login()
        {
            InitializeComponent();
            connection();
            bunifuFormFadeTransition1.ShowAsyc(this);
            button1.BackColor = Color.Transparent;
            pictureBox1.BackColor = Color.Transparent;
            bunifuCustomLabel1.BackColor = Color.Transparent;
            bunifuCustomLabel2.BackColor = Color.Transparent;
            bunifuCircleProgressbar1.BackColor = Color.Transparent;
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

        //Checking username and password when click on login button
        private void button1_Click(object sender, EventArgs e)
        {
            bunifuCircleProgressbar1.Visible = true;
            bunifuCircleProgressbar1.Value = 17;
            contextMenuStrip1.Enabled = false;
            button1.Visible = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }

        void checkuername()
        {
            try
            {
                string str = "DATA SOURCE=192.168.0.53:1521/xe; USER ID=IMS;password=enteryourchoice";
                OracleConnection mycon = new OracleConnection(str);
                OracleCommand SelectCommand = new OracleCommand("select * from ADMIN where USERNAME ='" + textBox1.Text + "' and password='" + textBox2.Text + "'", mycon);
                OracleDataReader myReader;
                mycon.Open();
                myReader = SelectCommand.ExecuteReader();
                while (myReader.Read())
                {
                    cout = cout + 1;
                   
                }
                if (cout == 1)
                {
                    
                    //homepage home = new homepage(textBox1.Text);
                    //this.Hide();
                    //home.ShowDialog();

                }

                else
                {
                    
                    // backgroundWorker1.CancelAsync();


                }
                mycon.Dispose();
                mycon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int cout ,i;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            cout = 0;
           
            for(i=20;i<=100;i+=3)
            {
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                }
                else
                {
                    simulateheavywork();
                    backgroundWorker1.ReportProgress(i);
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            checkuername();
            bunifuCircleProgressbar1.Value = e.ProgressPercentage;

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (i >= 98)
            {
                bunifuCircleProgressbar1.Visible = false;
                contextMenuStrip1.Enabled = true;
                button1.Visible = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;

                if (cout >= 1)
                {
                    homepage home = new homepage(textBox1.Text);
                    this.Hide();
                    home.ShowDialog();
                }
                else
                    MessageBox.Show("Invalid Credential");
            }

        }

        private void simulateheavywork()
        {
            Thread.Sleep(100);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

   

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }



        //Form Closing
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

       
    }
}
