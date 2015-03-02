/*
 * mySimpleComputer.c
 *
 *  Created on: 25.11.2011
 *      Author: x
 */

#include "mySimpleComputer.h"

unsigned int sc_memory[100];
unsigned short int sc_registerFlags = 0;

int sc_commandEncode(int command, int operand, int *value)
{
	*value = (command << 7) | (operand & 127);
	return 0;
}

int sc_commandDecode(int value, int *command, int *operand)
{
	if ( (value < 0) || (value >> 15) )
		return 1;
	*operand = value & 127;
	*command = value >> 7;
	return 0;
}

int sc_memoryInit(void)
{
	int i;
	for (i = 0; i < 100; i++) sc_memory[i] = 0;
	return 0;
}

int sc_memorySet(int address, int value)
{
	if (address > 99 || address < 0)
		return 1;
	sc_memory[address] = value;
	return 0;
}

int sc_memoryGet(int address, int *value)
{
	if (address > 99 || address < 0)
		return 1;
	*value = sc_memory[address];
	return 0;
}

int sc_memorySave(char *filename)
{
	FILE *file;
	if ((file = fopen(filename, "wb+")) == NULL)
		return 1;
	if (fwrite(sc_memory, sizeof(int), 100, file) != 100)
	{
		fclose(file);
		return 1;
	}
	fclose(file);
	return 0;
}

int sc_memoryLoad(char *filename)
{
	FILE *file;
	if ((file = fopen(filename, "rb")) == NULL)
		return 1;
	if (fread(sc_memory, sizeof(int), 100, file) != 100)
	{
		fclose(file);
		return 1;
	}
	fclose(file);
	return 0;
}

int sc_memoryPrint()
{

	int value = 0;
	int i, j;
	for (i = 0; i < 10; i++)
	{
    		for (j = 0; j < 10; j++)
    		{
    			if (sc_memoryGet(i*10+j, &value)) return 1;
    			if (value & 0x8000)
				printf(" %02X%02X ", (value & 127), (value >> 7));
    			else
				printf("+%02X%02X ", (value & 127), (value >> 7));
		}
    		printf("\n ");
	}
	return 0;
}

int sc_regInit(void)
{
	sc_registerFlags = 0;
	return 0;
}

int sc_regSet(int reg, int value)
{
	if ( (value < 0) || (value > 1) ) return 1;
	switch (reg)
	{
		case SC_F_OUTMEM:
		case SC_F_RUNNIN:
		case SC_F_DIVZER:
		case SC_F_OUTVAL:
		case SC_F_UNKCOM:
			if (value)
				sc_registerFlags |= reg;
			else
				sc_registerFlags &= (SC_F_ALL - reg);
			break;
		default:
			return 2;
	}
	return 0;
}

int sc_regGet(int reg, int *value)
{
	switch (reg)
	{
		case SC_F_OUTMEM:
		case SC_F_RUNNIN:
		case SC_F_DIVZER:
		case SC_F_OUTVAL:
		case SC_F_UNKCOM:
			*value = ((sc_registerFlags & reg) == 0) ? 0 : 1;
			break;
		default:
			return 1;
	}
	return 0;
}
