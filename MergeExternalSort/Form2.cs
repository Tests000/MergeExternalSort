using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MergeExternalSort
{
    public enum Characteristic
    {
        Time,
        Compares,
        Passes
    }
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Characteristic ch)
        {
            InitializeComponent();
            var res = Solve();
            dataGridView1.RowCount = 4;
            if (ch == Characteristic.Compares)
            {
                label1.Text = "Кол-во сравнений";
                dataGridView1.Rows[0].Cells[0].Value = "1000";
                dataGridView1.Rows[0].Cells[1].Value = res[0].compares;
                dataGridView1.Rows[0].Cells[2].Value = res[4].compares;
                dataGridView1.Rows[1].Cells[0].Value = "5000";
                dataGridView1.Rows[1].Cells[1].Value = res[1].compares;
                dataGridView1.Rows[1].Cells[2].Value = res[5].compares;
                dataGridView1.Rows[2].Cells[0].Value = "10000";
                dataGridView1.Rows[2].Cells[1].Value = res[2].compares;
                dataGridView1.Rows[2].Cells[2].Value = res[6].compares;
                dataGridView1.Rows[3].Cells[0].Value = "50000";
                dataGridView1.Rows[3].Cells[1].Value = res[3].compares;
                dataGridView1.Rows[3].Cells[2].Value = res[7].compares;
            }
            else if (ch == Characteristic.Passes)
            {
                label1.Text = "Кол-во проходов";
                dataGridView1.Rows[0].Cells[0].Value = "1000";
                dataGridView1.Rows[0].Cells[1].Value = res[0].passes;
                dataGridView1.Rows[0].Cells[2].Value = res[4].passes;
                dataGridView1.Rows[1].Cells[0].Value = "5000";
                dataGridView1.Rows[1].Cells[1].Value = res[1].passes;
                dataGridView1.Rows[1].Cells[2].Value = res[5].passes;
                dataGridView1.Rows[2].Cells[0].Value = "10000";
                dataGridView1.Rows[2].Cells[1].Value = res[2].passes;
                dataGridView1.Rows[2].Cells[2].Value = res[6].passes;
                dataGridView1.Rows[3].Cells[0].Value = "50000";
                dataGridView1.Rows[3].Cells[1].Value = res[3].passes;
                dataGridView1.Rows[3].Cells[2].Value = res[7].passes;
            }
            else if (ch == Characteristic.Time)
            {
                label1.Text = "Время выполнения";
                dataGridView1.Rows[0].Cells[0].Value = "1000";
                dataGridView1.Rows[0].Cells[1].Value = (int)res[0].time + " мс";
                dataGridView1.Rows[0].Cells[2].Value = (int)res[4].time + " мс";
                dataGridView1.Rows[1].Cells[0].Value = "5000";
                dataGridView1.Rows[1].Cells[1].Value = (int)res[1].time + " мс";
                dataGridView1.Rows[1].Cells[2].Value = (int)res[5].time + " мс";
                dataGridView1.Rows[2].Cells[0].Value = "10000";
                dataGridView1.Rows[2].Cells[1].Value = (int)res[2].time + " мс";
                dataGridView1.Rows[2].Cells[2].Value = (int)res[6].time + " мс";
                dataGridView1.Rows[3].Cells[0].Value = "50000";
                dataGridView1.Rows[3].Cells[1].Value = (int)res[3].time + " мс";
                dataGridView1.Rows[3].Cells[2].Value = (int)res[7].time + " мс";
            }
        }

        private MergeSort.Result[] Solve()
        {
            var progress = new Form3();
            progress.Show();
            progress.progress = 0;
            progress.Update();
            var res = new MergeSort.Result[8];
            Generate("1k.txt", 1000);
            res[0] = MergeSort.Sort("1k.txt", "o1k.txt");
            progress.progress = 1;
            progress.Update();
            Generate("5k.txt", 5000);
            res[1] = MergeSort.Sort("5k.txt", "o5k.txt");
            progress.progress = 5;
            progress.Update();
            Generate("10k.txt", 10000);
            res[2] = MergeSort.Sort("10k.txt", "o10k.txt");
            progress.progress = 12;
            progress.Update();
            Generate("50k.txt", 50000);
            res[3] = MergeSort.Sort("50k.txt", "o50k.txt");
            progress.progress = 50;
            progress.Update();
            ReverseFill("1k.txt", 1000);
            res[4] = MergeSort.Sort("1k.txt", "o1k.txt");
            progress.progress = 51;
            progress.Update();
            ReverseFill("5k.txt", 5000);
            res[5] = MergeSort.Sort("5k.txt", "o5k.txt");
            progress.progress = 55;
            progress.Update();
            ReverseFill("10k.txt", 10000);
            res[6] = MergeSort.Sort("10k.txt", "o10k.txt");
            progress.progress = 62;
            progress.Update();
            ReverseFill("50k.txt", 50000);
            res[7] = MergeSort.Sort("50k.txt", "o50k.txt");
            progress.progress = 100;
            progress.Update();
            progress.Close();
            return res;
        }

        private void Generate(string name, int countElems)
        {
            StreamWriter writer = new StreamWriter(name);
            Random rand = new Random();
            for (int i = 0; i < countElems; i++)
            {
                writer.Write(rand.Next(-countElems, countElems) + "\n");
            }
            writer.Dispose();
        }
        private void ReverseFill(string name, int countElems)
        {
            StreamWriter writer = new StreamWriter(name);
            for (int i = countElems/2; i >= -countElems/2; i--)
            {
                writer.Write(i + "\n");
            }
            writer.Dispose();
        }
    }
}
