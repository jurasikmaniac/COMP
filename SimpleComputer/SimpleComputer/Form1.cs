using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleComputer
{
    public partial class Form1 : Form
    {
        String[] array2 =new String[100];
        public Form1()
        {
            for (int i = 0; i < 100; i++)
            {
                array2[i] = "+9999";
            }
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            dataGridView1.RowCount = array2.Length/10;
            dataGridView1.ColumnCount = array2.Length / 10;
            for (int i = 0; i < array2.Length / 10; i++)
                for (int j = 0; j < array2.Length / 10; j++)
                    dataGridView1.Rows[i].Cells[j].Value = array2[i*10 + j];
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            array2[e.RowIndex * 10 + e.ColumnIndex] = dataGridView1.CurrentCell.Value.ToString();
        }

        

        
    }
}
