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
        private static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        private static List<string> myList = new List<string>();
        MySimpleComputer myComp = new MySimpleComputer(100, myTimer, ref myList);
        
        
        // This is the method to run when the timer is raised.
        private void TimerEventProcessor(Object myObject,
                                                EventArgs myEventArgs)
        {
            if (myComp.memory.sc_regGet(Constants.IGNORT) == 0)
            {
                myComp.CU();
                dataGridView1.CurrentCell = dataGridView1[myComp.counter % 10, myComp.counter / 10];
                label1.Text = myComp.counter.ToString("X2");
                updateGUI();
                
            }
            else
            {
                updateGUI(); 
                myTimer.Enabled = false;
                myTimer.Stop();
            }       
            
                       
        }
        

        public Form1()
        {
            myList.Add(">Output console");            
            myTimer.Tick += new EventHandler(TimerEventProcessor);
            myTimer.Interval = 500;
            InitializeComponent();
            updateGUI();
        }
        

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (myComp.memory.sc_regGet(Constants.IGNORT)==0)
            {
                updateGUI();
                return;
            }
            int temp=0;
            bool positiv = true;
            string cell="0000";
            if (dataGridView1.CurrentCell.Value==null)
            {
                cell = "";
            }
            else
            {
                cell = dataGridView1.CurrentCell.Value.ToString();
            }
           
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
            int com=0;
            int op=0;
            dataGridView1.RowCount = myComp.MemSize / 10;
            dataGridView1.ColumnCount = myComp.MemSize / 10;  
            int temp = 0;
            for (int i = 0; i < myComp.MemSize / 10; i++)
            {
                for (int j = 0; j < myComp.MemSize / 10; j++)
                {
                    if (myComp.memory.sc_memoryGet(i * 10 + j, ref temp) == 0)
                    {
                        com = (temp >> 7) & 0x7F;
                        op = temp & 0x7F;                        
                        if (MyMemory.GetBit( temp,14)==0)
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
            textBoxAcc.Text = myComp.accumulator.ToString();
            textBoxInstr.Text = myComp.counter.ToString();
            if (myComp.memory.sc_regGet(Constants.IGNORT)==0) labelFIgnorTimer.ForeColor = Color.LightGray;
            else labelFIgnorTimer.ForeColor = Color.Black;
            if (myComp.memory.sc_regGet(Constants.ERROR) == 0) labelFWrongOp.ForeColor = Color.LightGray;
            else labelFWrongOp.ForeColor = Color.Black;
            if (myComp.memory.sc_regGet(Constants.OUTM) == 0) labelFOutMemory.ForeColor = Color.LightGray;
            else labelFOutMemory.ForeColor = Color.Black;
            if (myComp.memory.sc_regGet(Constants.OVER) == 0) labelFOverFlow.ForeColor = Color.LightGray;
            else labelFOverFlow.ForeColor = Color.Black;
            if (myComp.memory.sc_regGet(Constants.ZERO) == 0) labelFDivZero.ForeColor = Color.LightGray;
            else labelFDivZero.ForeColor = Color.Black;
            com = 0; 
            op = 0;
            int value=0;
            myComp.memory.sc_memoryGet(myComp.counter, ref value);
            myComp.memory.sc_commandDecode(value, ref com, ref op);
            labelOp.Text = "+" + com.ToString("X2");
            labelOpVal.Text = op.ToString("X2");
            //myList.Reverse();
            textBoxConsole.Lines = myList.ToArray();            
        }

        

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (myComp.memory.sc_regGet(Constants.IGNORT) == 0)
            {
                updateGUI();
                return;
            }
            string cell = "0000";
            if (dataGridView1.CurrentCell.Value == null)
            {
                cell = "0000";
            }
            else
            {
                cell = dataGridView1.CurrentCell.Value.ToString();
            }            
            cell = cell.Trim(new Char[] { '+', '-' });
            dataGridView1.CurrentCell.Value = cell;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            myComp.memory.sc_regInit();            
            updateGUI();
            myComp.CU();
            dataGridView1.CurrentCell = dataGridView1[myComp.counter % 10, myComp.counter / 10];
            label1.Text = myComp.counter.ToString("X2");
            updateGUI();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //myComp.memory.sc_memorySave("/1.txt");

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();


            saveFileDialog1.Filter = "Memory files (*.mem)|*.mem|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                myComp.memory.sc_memorySave(saveFileDialog1.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Memory files (*.mem)|*.mem|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                myComp.resetMyComputer();
                myComp.memory.sc_memoryLoad(openFileDialog1.FileName);                
                updateGUI();
            }
        }

        

        private void button6_Click(object sender, EventArgs e)
        {
            myComp.resetMyComputer();
            updateGUI();
        }

        private void buttonClearMemory_Click(object sender, EventArgs e)
        {
            myComp.memory.sc_memoryInit();
            myComp.counter = 0;
            updateGUI();
        }

        private void textBoxInstr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)Keys.Enter)
            {

                myComp.counter = Convert.ToInt32(((TextBox)sender).Text);
                updateGUI();
            }
        }

        private void textBoxAcc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                myComp.accumulator = Convert.ToInt32(((TextBox)sender).Text);
                updateGUI();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            myComp.resetMyComputer();
            myComp.memory.sc_regSet(Constants.IGNORT, 0);
            updateGUI();
            myTimer.Interval = Decimal.ToInt32(numericUpDownClock.Value);
            myTimer.Enabled = true;
            myTimer.Start();
            
            Application.DoEvents();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int pos = e.RowIndex * 10 + e.ColumnIndex;
            label1.Text = pos.ToString("X2");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "ASM files (*.asm)|*.asm|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                myComp.resetMyComputer();
                myComp.compileASM(openFileDialog1.FileName);
                updateGUI();
            }
        }       
    }
}
