using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleComputer
{
    
    class MyMemory
    {
        int[] arrMem;
        int flags;
        
        public MyMemory(int _memSize)
        {
            arrMem = new int[_memSize];
            sc_regInit();
            sc_memoryInit();
        }

        //инициализирует оперативную память Simple Computer, задавая всем ее ячейкам нулевые значения.
        public int sc_memoryInit()
        {
            for (int i = 0; i < arrMem.Length; i++)
            {
                arrMem[i] = 0;
            }
            return 0;
        }

        //задает значение указанной ячейки памяти как value. Если адрес выходит за допустимые границы, 
        //то устанавливается флаг «выход за границы памяти»
        //и работа функции прекращается с ошибкой;
        public int sc_memorySet(int address, int value)
        {
            if (address < 0 || address >= arrMem.Length)
            {
                return -1; //выход за границы
            }
            //arrMem[address] = value & 0x7FFF;
            arrMem[address] = value;
            return 0;
        }

        //возвращает значение указан-
        //ной ячейки памяти в value. Если адрес выходит за допустимые границы, то устанавли-
        //вается флаг «выход за границы памяти» и работа функции прекращается с ошибкой.
        //Значение value в этом случае не изменяется.
        public int sc_memoryGet(int address, ref int value)
        {
            if (address < 0 || address >= arrMem.Length)
            {                
                return -1; //выход за границы
            }
            value = arrMem[address];
            return 0;
        }

        //сохраняет содержимое памяти в файл в
        //бинарном виде (используя функцию write или fwrite);        
        /// <summary>
        /// Saves a file
        /// </summary>        
        public int sc_memorySave(string fileName)
        {
            FileStream Writer = null;
            byte[] buff = new byte[arrMem.Length * sizeof(int)];
            Buffer.BlockCopy(arrMem, 0, buff, 0, buff.Length);
            try
            {
                int Index = fileName.LastIndexOf('/');
                if (Index <= 0)
                {
                    Index = fileName.LastIndexOf('\\');
                }
                if (Index <= 0)
                {
                    throw new Exception("Directory must be specified for the file");
                }
                string Directory = fileName.Remove(Index) + "/";

                bool Opened = false;
                while (!Opened)
                {
                    try
                    {
                        Writer = File.Open(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
                        Opened = true;
                    }
                    catch (System.IO.IOException e)
                    {
                        throw e;
                    }
                }
                Writer.Write(buff, 0, buff.Length);
                Writer.Close();
            }
            catch (Exception a)
            {
                throw a;
            }
            finally
            {
                if (Writer != null)
                {
                    Writer.Close();
                    Writer.Dispose();
                }
            }

            return 0;
        }

        //загружает из указанного файла содер-
        //жимое оперативной памяти (используя функцию read или fread);
        public int sc_memoryLoad(string fileName)
        {
            FileStream Reader = null;
            byte[] buff = new byte[arrMem.Length * sizeof(int)];
            try
            {
                int Index = fileName.LastIndexOf('/');
                if (Index <= 0)
                {
                    Index = fileName.LastIndexOf('\\');
                }
                if (Index <= 0)
                {
                    throw new Exception("Directory must be specified for the file");
                }
                string Directory = fileName.Remove(Index) + "/";

                bool Opened = false;
                while (!Opened)
                {
                    try
                    {
                        Reader = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.None);
                        Opened = true;
                    }
                    catch (System.IO.IOException e)
                    {
                        throw e;
                    }
                }
                Reader.Read(buff, 0, buff.Length);
                Buffer.BlockCopy(buff, 0, arrMem, 0, buff.Length);
                Reader.Close();
            }
            catch (Exception a)
            {
                throw a;
            }
            finally
            {
                if (Reader != null)
                {
                    Reader.Close();
                    Reader.Dispose();
                }
            }

            return 0;
        }
        //инициализирует регистр флагов нулевым значением;
        public int sc_regInit()
        {
            flags = 0;
            sc_regSet(Constants.IGNORT, 1);
            return 0;
        }

//устанавливает значение указанно-
//го регистра флагов. Для номеров регистров флагов должны использоваться маски, за-
//даваемые макросами (#define). Если указан недопустимый номер регистра или некор-
//ректное значение, то функция завершается с ошибкой.
        public int sc_regSet(int register, int value)
        {
            if (register<0||register>4)
            {
                return -1;
            }            
            SetBit(ref flags, register, value);
            return 0;
        }

//возвращает значение указанного
//флага. Если указан недопустимый номер регистра, то функция завершается с ошибкой.
        public int sc_regGet(int register)
        {
            if (register < 0 || register > 4)
            {
                return -1;
            }  
            return GetBit(flags, register);
        }

//кодиру-
//ет команду с указанным номером и операндом и помещает результат в value. Если ука-
//заны неправильные значения для команды или операнда, то функция завершается с
//ошибкой. В этом случае значение value не изменяется.
        public int sc_commandEncode(int command, int operand, ref int value)
        {
            if (command<0||command>127||operand<0||operand>127)
            {
                return 0;
            }
            int _com = command << 7;
            int _op = operand & 0x7F;
            value = _com | _op;
            return 0;
        }

//декодирует значение как команду Simple Computer. Если декодирование невозможно, то
//устанавливается флаг «ошибочная команда» и функция завершается с ошибкой.
        public int sc_commandDecode (int value, ref int command, ref int operand)
        {
            if ((value < 0) || ((value >> 15))!=0)
            {
                return -1;
            }
                
            operand = value & 127;
            command = value >> 7;
            return 0; 
        }

        static public void SetBit(ref int dw, int nBitNumber, int nBitValue)
        {
            //dw - целое, в котором задаем бит
            //nBitNumber - номер бита, который задаем (0..31)
            int dwMask = 1 << nBitNumber;// 0000100000....

            //nBitValue (0|1)
            if (nBitValue == 0)
            {//задаем 0
                dwMask = ~dwMask;// 1111011111....
                dw = dw & dwMask; // 0 & x = 0
            }
            else
            {//задаем 1
                dw = dw | dwMask;// 1 | x = 1
            }
        }

        static public int GetBit(int dw, int nBitNumber)
        {
            //dw - целое в котором узнаем бит
            //nBitNumber - номер бита, который узнаем (0..31)
            int dwMask = 1 << nBitNumber;// 0000100000....
            dw = dwMask & dw;
            if (Convert.ToBoolean(dw))
                return 1;
            return 0;
        }

    }
}
