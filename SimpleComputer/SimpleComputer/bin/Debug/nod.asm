﻿0 READ 10
1 READ 11 //ввели исходные числа
2 LOAD 10 //нужно, чтобы первое число было больше второго
3 SUB 11 //вычитаем второе из первого
4 JZ 90 //если результат равен 0, то они равны. Переходим к выводу результата 
5 JNEG 20 //если результат меньше нуля, переходим к части программы, которая меняет числа местами
6 JUMP 30 //иначе переходим к основной части алгоритма
20 LOAD 10 //часть программы, меняющая числа местами (просто через темповую ячейку 12)
21 STORE 12
22 LOAD 11
23 STORE 10
24 LOAD 12
25 STORE 11
26 JUMP 30
30 LOAD 10 //основная часть алгоритма
31 DIVIDE 11 //ищем остаток от деления первого на второе
32 MUL 11
33 STORE 12
34 LOAD 10
35 SUB 12
36 JZ 90 //если остаток равен нулю, переходим к выводу результата
37 STORE 10 //иначе записываем остаток на место первого числа
38 JUMP 20 //и вызываем часть программы, меняющую числа местами (которая, поменяв их, запустит основную часть заново)
90 WRITE 11 //выводим результат
91 HALT 0 //умираем