using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MergeExternalSort
{
    public partial class Form3 : Form
    {
        public int progress { 
            set 
            {
                progressBar1.Value = value;
                label1.Text = value + "%";
            } 
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
