using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleComputer
{
    class MyMemory
    {
        int[] arrMem;

        public MyMemory(int _memSize){
            arrMem=new int[_memSize];
            sc_memoryInit();
        }

//инициализирует оперативную память Simple Computer, задавая всем ее ячейкам нулевые значения.
        private int sc_memoryInit(){
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
            if (address<0||address>=arrMem.Length)
            {
                return -1; //выход за границы
            }
            arrMem[address] = value&0xFFFF;
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

        
        //d. int sc_memorySave (char * filename) – сохраняет содержимое памяти в файл в
//бинарном виде (используя функцию write или fwrite);e. int sc_memoryLoad (char * filename) – загружает из указанного файла содер-
//жимое оперативной памяти (используя функцию read или fread);
//f. int sc_regInit (void) – инициализирует регистр флагов нулевым значением;
//g. int sc_regSet (int register, int value) – устанавливает значение указанно-
//го регистра флагов. Для номеров регистров флагов должны использоваться маски, за-
//даваемые макросами (#define). Если указан недопустимый номер регистра или некор-
//ректное значение, то функция завершается с ошибкой.
//h. int sc_regGet (int register, int * value) – возвращает значение указанного
//флага. Если указан недопустимый номер регистра, то функция завершается с ошибкой.
//i. int sc_commandEncode (int command, int operand, int * value) – кодиру-
//ет команду с указанным номером и операндом и помещает результат в value. Если ука-
//заны неправильные значения для команды или операнда, то функция завершается с
//ошибкой. В этом случае значение value не изменяется.
//j. int sc_commandDecode (int value, int * command, int * operand) – деко-
//дирует значение как команду Simple Computer. Если декодирование невозможно, то
//устанавливается флаг «ошибочная команда» и функция завершается с ошибкой.
    
    }
}
