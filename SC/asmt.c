#include <stdio.h>
#include "mySimpleComputer.h"

int asmt(char *filename1, char *filename2)
{
	FILE *filein;
	char line[60], buf[30];
	unsigned short int idx = 0;
	int oper = 0, command = 0, value = 0;

	if ((filein = fopen(filename1, "rt")) == NULL) return 2;

	sc_memoryInit();

	do
	{
		fgets(line, sizeof(line), filein);
		sscanf(line, "%hu %s %d\n", &idx, buf, &oper);

		if (!strcmp(buf, "READ"))	command = SC_READ;
		if (!strcmp(buf, "WRITE"))	command = SC_WRITE;
		if (!strcmp(buf, "LOAD"))	command = SC_LOAD;
		if (!strcmp(buf, "STORE"))	command = SC_STORE;
		if (!strcmp(buf, "ADD"))	command = SC_ADD;
		if (!strcmp(buf, "SUB"))	command = SC_SUB;
		if (!strcmp(buf, "SUBC"))	command = SC_SUBC;
		if (!strcmp(buf, "DIVIDE"))	command = SC_DIVIDE;
		if (!strcmp(buf, "MUL"))	command = SC_MUL;
		if (!strcmp(buf, "JUMP"))	command = SC_JUMP;
		if (!strcmp(buf, "JNEG"))	command = SC_JNEG;
		if (!strcmp(buf, "JZ"))		command = SC_JZ;
		if (!strcmp(buf, "HALT"))	command = SC_HALT;
		if (!strcmp(buf, "="))		command = 0;

		if (command > 0)
		{
			if (sc_commandEncode(command, oper, &value))
				return 1;
		}
		else
			value = oper;

		if (sc_memorySet(idx, value))
			return 1;
		
	} while (!feof(filein));

	fclose(filein);

	if (sc_memorySave(filename2))
		return 3;

	return 0;
}

int main(int argc, char **argv)
{
	int err;
	if (argc!=3)
	{
		printf("Usage: %s [asm file] [dump file]\n", argv[0]);
		return 0;
	}

	err = asmt(argv[1], argv[2]);
	switch (err)
	{
		case 0: printf("Dump create\n"); break;
		case 1: printf("Error in mySimpleComputer\n"); break;
		case 2: printf("Can't open input file\n"); return 1; break;
		case 3: printf("Can't save dump\n"); return 1; break;
	}

	return 0;
}
