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
    }
}
