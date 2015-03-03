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
            int temp=0;
            try
            {
                temp = Int32.Parse(dataGridView1.CurrentCell.Value.ToString(), System.Globalization.NumberStyles.HexNumber);
            }
            catch (FormatException )
            {
                string message = "Wrong format";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);                
            }
            myComp.memory.sc_memorySet(e.RowIndex * 10 + e.ColumnIndex, temp);
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
                        if (!GetBit( ref temp,15))
                        {
                            dataGridView1.Rows[i].Cells[j].Value ="+" + temp.ToString("X4");    
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells[j].Value = "-" + temp.ToString("X4");    
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


        

        
    }
}
