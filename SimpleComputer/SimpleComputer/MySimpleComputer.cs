using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleComputer
{
    class MySimpleComputer
    {
        public int MemSize { get; set; }

        public MyMemory memory;
        public int counter { get; set; }
        public int accumulator { get; set; }
        static System.Windows.Forms.Timer timer;
        List<string> myList;


        public MySimpleComputer(int _m, System.Windows.Forms.Timer _myTimer, ref List<string> _console)
        {
            myList = _console;
            timer = _myTimer;
            counter = 0;
            accumulator = 0;
            MemSize = _m;
            memory = new MyMemory(_m);
            // TODO: Complete member initialization
        }


        public void resetMyComputer()
        {
            memory.sc_regInit();
            //memory.sc_memoryInit();
            counter = 0;
            accumulator = 0;
        }
        /// <summary>
        /// обеспечивает работу устройства управления
        /// </summary>
        /// <returns></returns>
        public int CU()
        {
            int temp_value = 0;
            int value = 0;
            int com = 0;
            int op = 0;
            if (memory.sc_memoryGet(counter, ref value) < 0)
            {
                memory.sc_regSet(Constants.IGNORT, 1);
                memory.sc_regSet(Constants.OUTM, 1);
                return -1;
            }
            if (memory.sc_commandDecode(value, ref com, ref op) < 0)
            {
                memory.sc_regSet(Constants.IGNORT, 1);
                memory.sc_regSet(Constants.ERROR, 1);
                return -1;
            }
            if (com >= Constants.ADD && com <= Constants.MUL)
            {
                ALU(com, op);
                return 0;
            }
            switch (com)
            {
                case Constants.READ:
                    temp_value = 0;
                    timer.Enabled = false;
                    SomeCustomForm myForm = new SomeCustomForm();
                    myForm.Message = "0";
                    myForm.Input = "Enter value(int -16385..32767) to the address(HEX): " + op.ToString("X2");
                    myForm.ShowDialog(new Form());

                    if (myForm.DialogResult == DialogResult.OK)
                    {
                        try
                        {
                            temp_value = Convert.ToInt32(myForm.Message);
                        }
                        catch (Exception)
                        {
                            temp_value = 0;
                        }
                        if (temp_value > 32767 || temp_value < -16385)
                        {
                            memory.sc_regSet(Constants.OVER, 1);
                            memory.sc_regSet(Constants.IGNORT, 1);
                        }
                        else
                        {
                            memory.sc_memorySet(op, temp_value);
                        }
                    }
                    counter++;
                    timer.Enabled = true;
                    break;
                case Constants.WRITE:
                    temp_value = 0;
                    if (memory.sc_memoryGet(op, ref temp_value) < 0)
                    {
                        memory.sc_regSet(Constants.IGNORT, 1);
                        memory.sc_regSet(Constants.OUTM, 1);
                        return -1;
                    }
                    myList.Reverse();
                    myList.Add(temp_value.ToString());
                    myList.Reverse();
                    counter++;
                    break;
                case Constants.JUMP:
                    counter = op;
                    break;
                case Constants.JNEG:
                    if (accumulator < 0) counter = op; else counter++;
                    break;
                case Constants.JZ:
                    if (accumulator == 0) counter = op; else counter++;
                    break;
                case Constants.HALT:
                    counter = 0;
                    memory.sc_regSet(Constants.IGNORT, 1);
                    break;
                case Constants.LOAD:
                    temp_value = 0;
                    if (memory.sc_memoryGet(op, ref temp_value) < 0)
                    {
                        memory.sc_regSet(Constants.IGNORT, 1);
                        memory.sc_regSet(Constants.OUTM, 1);
                        return -1;
                    }
                    accumulator = temp_value;
                    counter++;
                    break;
                case Constants.STORE:
                    if (memory.sc_memorySet(op, accumulator) < 0)
                    {
                        memory.sc_regSet(Constants.IGNORT, 1);
                        memory.sc_regSet(Constants.OUTM, 1);
                        return -1;
                    }
                    counter++;
                    break;
                case Constants.JNS:
                    if (accumulator > 0)
                    {
                        counter = op;
                    }
                    break;
                default:
                    //counter = 0;
                    memory.sc_regSet(Constants.IGNORT, 1);
                    memory.sc_regSet(Constants.ERROR, 1);
                    break;
            }

            return 0;
        }

        public int ALU(int command, int operand)
        {
            int temp = 0;
            switch (command)
            {
                case Constants.ADD://acc+mem(op)
                    if (memory.sc_memoryGet(operand, ref temp) < 0)
                    {
                        memory.sc_regSet(Constants.IGNORT, 1);
                        memory.sc_regSet(Constants.OUTM, 1);
                        return -1;
                    }
                    accumulator = accumulator + temp;
                    if (accumulator > 32767 || accumulator < -16385)
                    {
                        memory.sc_regSet(Constants.OVER, 1);
                        memory.sc_regSet(Constants.IGNORT, 1);
                        accumulator = 0;
                        return -1;
                    }
                    counter++;
                    break;
                case Constants.SUB://acc-mem(op)
                    if (memory.sc_memoryGet(operand, ref temp) < 0)
                    {
                        memory.sc_regSet(Constants.IGNORT, 1);
                        memory.sc_regSet(Constants.OUTM, 1);
                        return -1;
                    }
                    accumulator = accumulator - temp;
                    if (accumulator > 32767 || accumulator < -16385)
                    {
                        memory.sc_regSet(Constants.OVER, 1);
                        memory.sc_regSet(Constants.IGNORT, 1);
                        accumulator = 0;
                        return -1;
                    }
                    counter++;
                    break;
                case Constants.DIVIDE://acc/mem(op)
                    if (memory.sc_memoryGet(operand, ref temp) < 0)
                    {
                        memory.sc_regSet(Constants.IGNORT, 1);
                        memory.sc_regSet(Constants.OUTM, 1);
                        return -1;
                    }
                    if (temp==0)
                    {
                        memory.sc_regSet(Constants.IGNORT, 1);
                        memory.sc_regSet(Constants.ZERO, 1);
                        return -1;
                    }
                    accumulator = accumulator / temp;
                    if (accumulator > 32767 || accumulator < -16385)
                    {
                        memory.sc_regSet(Constants.OVER, 1);
                        memory.sc_regSet(Constants.IGNORT, 1);
                        accumulator = 0;
                        return -1;
                    }
                    counter++;
                    break;
                case Constants.MUL://acc*mem(op)
                    if (memory.sc_memoryGet(operand, ref temp) < 0)
                    {
                        memory.sc_regSet(Constants.IGNORT, 1);
                        memory.sc_regSet(Constants.OUTM, 1);
                        return -1;
                    }
                    accumulator = accumulator * temp;
                    if (accumulator > 32767 || accumulator < -16385)
                    {
                        memory.sc_regSet(Constants.OVER, 1);
                        memory.sc_regSet(Constants.IGNORT, 1);
                        accumulator = 0;
                        return -1;
                    }
                    counter++;
                    break;
                default:
                    memory.sc_regSet(Constants.IGNORT, 1);
                    memory.sc_regSet(Constants.ERROR, 1);
                    break;
            }
            return 0;
        }
        public int compileASM(string fileName)
        {
            string[] buf;
            string temp;
            int idx = 0;
            int oper = 0;
            int command = 0;
            int value = 0;
            string[] lines = System.IO.File.ReadAllLines(@fileName);
            foreach (string line in lines)
            {
                try
                {
                    buf = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    idx = Convert.ToInt32(buf[0]);
                    temp = String.Copy(buf[1]);
                    oper = Convert.ToInt32(buf[2]);
                }
                catch (Exception)
                {

                    return -1; ;
                }


                if (String.Equals(temp, "READ")) command = Constants.READ;
                if (String.Equals(temp, "WRITE")) command = Constants.WRITE;
                if (String.Equals(temp, "LOAD")) command = Constants.LOAD;
                if (String.Equals(temp, "STORE")) command = Constants.STORE;
                if (String.Equals(temp, "ADD")) command = Constants.ADD;
                if (String.Equals(temp, "SUB")) command = Constants.SUB;
                if (String.Equals(temp, "JNS")) command = Constants.JNS;
                if (String.Equals(temp, "DIVIDE")) command = Constants.DIVIDE;
                if (String.Equals(temp, "MUL")) command = Constants.MUL;
                if (String.Equals(temp, "JUMP")) command = Constants.JUMP;
                if (String.Equals(temp, "JNEG")) command = Constants.JNEG;
                if (String.Equals(temp, "JZ")) command = Constants.JZ;
                if (String.Equals(temp, "HALT")) command = Constants.HALT;
                if (String.Equals(temp, "=")) command = 0;
                if (command > 0)
                {
                    if (memory.sc_commandEncode(command, oper, ref value) < 0) return 1;
                }
                else
                    value = oper;

                if (memory.sc_memorySet(idx, value) < 0) return 1;
            }
            return 0;
        }
    }
}
