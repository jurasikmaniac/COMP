/*
 * mySimpleComputer.h
 *
 *  Created on: 25.11.2011
 *      Author: x
 */

#ifndef MYSIMPLECOMPUTER_H_
#define MYSIMPLECOMPUTER_H_

#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include <unistd.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>

#define SC_F_OUTMEM 1
#define SC_F_RUNNIN 2
#define SC_F_DIVZER 4
#define SC_F_OUTVAL 8
#define SC_F_UNKCOM 16
#define SC_F_ALL 31

#define SC_READ 10
#define SC_WRITE 11
#define SC_LOAD 20
#define SC_STORE 21
#define SC_ADD 30
#define SC_SUB 31
#define SC_DIVIDE 32
#define SC_MUL 33
#define SC_JUMP 40
#define SC_JNEG 41
#define SC_JZ 42
#define SC_HALT 43
#define SC_ADDC 75

extern int sc_memoryInit();
extern int sc_memorySet(int address, int value);
extern int sc_memoryGet(int address, int *value);
extern int sc_memorySave(char *filename);
extern int sc_memoryLoad(char *filename);
extern int sc_memoryPrint();
extern int sc_regInit(void);
extern int sc_regSet(int reg, int value);
extern int sc_regGet(int reg, int *value);
extern int sc_commandEncode(int command, int operand, int *value);
extern int sc_commandDecode(int value, int *command, int *operator);

#endif /* MYSIMPLECOMPUTER_H_ */
