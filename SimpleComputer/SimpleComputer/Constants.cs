using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleComputer
{
    static class Constants
    {        
        /// <summary>
        ///  флаг переполнения
        /// </summary>
        public const int OVER = 0; 
        
        /// <summary>
        ///  флаг деления на ноль
        /// </summary>
        public const int ZERO = 1;       
        
        /// <summary>
        /// флаг выхода за пределы памяти
        /// </summary>
        public const int OUTM = 2; 
       
        /// <summary>
        ///  флаг игнорирование таймера
        /// </summary>
        public const int IGNORT = 3; 
       
        /// <summary>
        /// флаг ошибка комманды
        /// </summary>
        public const int ERROR = 4;

        
        //Операции ввода/вывода--------------------------------
        
        /// <summary>
        /// Ввод с терминала в указанную ячейку памяти с контролем переполнения
        /// </summary>
        public const int READ = 0x10;

        /// <summary>
        /// Вывод на терминал значение указанной ячейки памяти
        /// </summary>
        public const int WRITE = 0x11;

        //Операции загрузки/выгрузки в аккумулятор-------------
        /// <summary>
        /// Загрузка в аккумулятор значения из указанного адреса памяти
        /// </summary>
        public const int LOAD = 0x20;
        
        /// <summary>
        /// Выгружает значение из аккумулятора по указанному адресу памяти
        /// </summary>
        public const int STORE = 0x21; 

        //Арифметические операции------------------------------

        /// <summary>
        /// Выполняет сложение слова в аккумуляторе и слова из указанной ячейки памяти
        /// (результат в аккумуляторе)
        /// </summary>
        public const int ADD =0x30; 

        /// <summary>
        /// Вычитает из слова в аккумуляторе слово из указанной ячейки памяти
        /// (результат в аккумуляторе)
        /// </summary>    
        public const int SUB = 0x31;
        
        /// <summary>
        /// Выполняет деление слова в аккумуляторе на слово из указанной ячейки памяти
        /// (результат в аккумуляторе)
        /// </summary>
        public const int DIVIDE =0x32;

        /// <summary>
        /// Вычисляет произведение слова в аккумуляторе на слово из указанной ячейки памяти
        /// (результат в аккумуляторе)
        /// </summary>
        public const int MUL = 0x33;        //Операции передачи управления------------------------
        
        /// <summary>
        /// Переход к указанному адресу памяти
        /// </summary>
        public const int JUMP = 0x40;

        /// <summary>
        /// Переход к указанному адресу памяти, если в аккумуляторе находится отрицательное число
        /// </summary>
        public const int JNEG =0x41;
 
        /// <summary>
        /// Переход к указанному адресу памяти, если в аккумуляторе находится ноль
        /// </summary>
        public const int JZ = 0x42;

        /// <summary>
        /// Останов, выполняется при завершении работы программы
        /// </summary>
        public const int HALT = 0x43;         //позьзовательские функции----------------------------        /// <summary>
        /// Переход к указанному адресу памяти, если в аккумуляторе находится положительное число
        /// </summary>        public const int JNS = 0x55;
    }
}
