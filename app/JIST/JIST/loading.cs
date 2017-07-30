 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JIST
{
    public partial class loading : Form
    {
        int a = 0;
        public loading()
        {
            InitializeComponent();
            bunifuFormFadeTransition1.ShowAsyc(this);
            Cursor.Current = Cursors.AppStarting;
            pictureBox1.BackColor = Color.Transparent;
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            a++;
            if (a == 60)
            {
                pictureBox2.Image = JIST.Properties.Resources._465831_368855303220269_1247157632_o;
            }
            if (a == 120)
                pictureBox2.Image = JIST.Properties.Resources._18622375_1135621386543653_1080340366521194387_n;
            if (a == 180) { 
                Login lg = new Login();
                this.Hide();
                lg.ShowDialog();
                this.Close();
            }
        }
    }
}
