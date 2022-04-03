using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace lab5
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            HashSet<int> set = new HashSet<int>();
            foreach(var s in textBox1.Text.Split(' '))
            {
                set.Add(int.Parse(s));
            }

            dataGridView1.RowCount = set.Count;
            dataGridView1.ColumnCount = set.Count;

            for (int i = 0; i < set.Count; i++)
            {
                dataGridView1.Rows[0].Cells[i].Value = set.ElementAt(i);
            }

            int row = 1;
            while (set.Count!=1)
            {
                HashSet<int> temp = new HashSet<int>();
                for (int i = 0; i < set.Count - 1; i++)
                {
                    temp.Add(set.ElementAt(i) + set.ElementAt(i+1));
                }
                set = new HashSet<int>(temp);
                for (int i = 0; i < set.Count; i++)
                {
                    dataGridView1.Rows[row].Cells[i].Value = set.ElementAt(i);
                }
                row++;
            }
        }

        private void backb_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }
    }
}