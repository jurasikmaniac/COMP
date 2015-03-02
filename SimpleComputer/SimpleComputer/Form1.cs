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
        MySimpleComputer myComp = new MySimpleComputer(100);
        public Form1()
        {
                      
            for (int i = 0; i < 100; i++)
            {
                myComp.memory.sc_memorySet(i, 0x1f1F1f);
            }
            InitializeComponent();
            updateGUI();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateGUI();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int temp =Convert.ToInt32( dataGridView1.CurrentCell.Value.ToString());
            myComp.memory.sc_memorySet(e.RowIndex * 10 + e.ColumnIndex, temp);
        }

        public void updateGUI()
        {
            dataGridView1.RowCount = myComp.MemSize / 10;
            dataGridView1.ColumnCount = myComp.MemSize / 10;  
            int temp = 0;
            for (int i = 0; i < myComp.MemSize / 10; i++)
            {
                for (int j = 0; j < myComp.MemSize / 10; j++)
                {
                    if (myComp.memory.sc_memoryGet(i * 10 + j, ref temp) == 0)
                    {
                        dataGridView1.Rows[i].Cells[j].Value ="+"+ temp.ToString("X4");
                    }
                }
            }
        }

        

        
    }
}
