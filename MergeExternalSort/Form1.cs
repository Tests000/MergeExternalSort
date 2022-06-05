using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MergeExternalSort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void колвоСравненийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Form2(Characteristic.Compares);
            form.Show();    
        }

        private void колвоПроходовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Form2(Characteristic.Passes);
            form.Show();
        }

        private void времяВыполненияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form  = new Form2(Characteristic.Time);
            form.Show();
        }



        private void OpenForm(object sender, EventArgs e)
        {
            ReverseFill("seq.txt", 20);
            var res = MergeSort.Sort("seq.txt", "res.txt");
        }


        private void ReverseFill(string name, int countElems)
        {
            StreamWriter writer = new StreamWriter(name);
            for (int i = 0; i < countElems; i++)
            {
                writer.Write(countElems - i + "\n");
            }
            writer.Dispose();
        }
    }
}
