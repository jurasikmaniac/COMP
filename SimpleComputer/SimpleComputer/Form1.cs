using System;
using System.Collections;
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
                myComp.memory.sc_memorySet(i, 0x1F1F);
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
            int temp=0;
            bool positiv = true;
            string cell = dataGridView1.CurrentCell.Value.ToString();
            int Index = cell.LastIndexOf('+');
            if (Index >= 0)
            {
                positiv = true;
            }
            Index = cell.LastIndexOf('-');
            if (Index >= 0)
            {
                positiv = false;
            }
            cell=cell.Trim(new Char[] { '+', '-'} );

            try
            {
                temp = Int32.Parse(cell, System.Globalization.NumberStyles.HexNumber);
            }
            catch ( Exception )
            {
                string message = "Wrong format(e.g. -/+####)";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);                
            }
            int com = (temp&0x7F00)>>1;
            int op = temp & 0x7F;
            temp = com | op;
            myComp.memory.sc_memorySet(e.RowIndex * 10 + e.ColumnIndex,positiv ? temp:temp|0x4000);
            updateGUI();
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
                        int com = (temp >> 7) & 0x7F;
                        int op = temp & 0x7F;
                        if (!GetBit( ref temp,14))
                        {

                            dataGridView1.Rows[i].Cells[j].Value = "+" + com.ToString("X2") + op.ToString("X2");    
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells[j].Value = "-" + com.ToString("X2") + op.ToString("X2");    
                        }
                        
                    }
                }
            }
        }

        public void SetBit(ref int dw, int nBitNumber, int nBitValue)
        {
             //dw - целое, в котором задаем бит
             //nBitNumber - номер бита, который задаем (0..31)
             int dwMask = 1 << nBitNumber;// 0000100000....
     
             //nBitValue (0|1)
             if(nBitValue == 0)
             {//задаем 0
                   dwMask = ~dwMask;// 1111011111....
                   dw = dw & dwMask; // 0 & x = 0
             }
             else
             {//задаем 1
                   dw = dw | dwMask;// 1 | x = 1
             }
        }

        public bool GetBit(ref int dw, int nBitNumber)
        {
             //dw - целое в котором узнаем бит
             //nBitNumber - номер бита, который узнаем (0..31)
             int dwMask = 1 << nBitNumber;// 0000100000....
             
             if(Convert.ToBoolean(dwMask & dw))
                   return true;
             return false;
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            dataGridView1.CurrentCell.Value="";
        }


        

        
    }
}
