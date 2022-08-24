using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket1._0
{
    public partial class StartForm : Form
    {

       

        public StartForm()
        {
            InitializeComponent();
            
        }

        

        private void StartForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Step = 2;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar.Increment(2);
            progressBar.PerformStep();

            if (progressBar.Value == 100)
            {
                timer1.Stop();
                StartPageForm log = new StartPageForm();
                log.Show();
                this.Hide();
            }

        }
    }
}
