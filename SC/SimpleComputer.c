#include <signal.h>
#include <sys/time.h>
#include <unistd.h>
#include "mySimpleComputer.h"
#include "myTerm.h"
#include "myBigChars.h"
#include "myReadkey.h"

struct itimerval timer;
int sc_accumulator = 0;
unsigned short int sc_instrcntr = 0;
int value = 0, command = 0, operand = 0;
int font[22][2];
unsigned short int lastx = 23;
char str[50];

void setAlarm(int state)
{
	timer.it_interval.tv_sec = 0;
	timer.it_interval.tv_usec = 0;
	timer.it_value.tv_sec = 0;
	timer.it_value.tv_usec = ((state == 0) ? 0 : 300000 );
	setitimer (ITIMER_REAL, &timer, 0);
}

int mwrite(char * str)
{
	return write(1, str, strlen(str));
}

int repaint(void)
{
	int fd = 0;
	int k = 0, i = 0;
	int value = 0;
	/* Print memory */
	mt_setstdcolor();
	mt_setfgcolor(COLOR_WHITE);
	mt_gotoXY(2, 2);
	sc_memoryPrint();
	mt_setstdcolor();
	/* Hightlight current cell */
	mt_setbgcolor(COLOR_WHITE);
	mt_gotoXY((sc_instrcntr/10)+2, (sc_instrcntr%10)*6+2);
	sc_memoryGet(sc_instrcntr, &value);
	if (value & 0x8000)
		printf(" %02X%02X", (value & 127), (value >> 7));
	else
		printf("+%02X%02X", (value & 127), (value >> 7));
	/* Paint boxes */
	mt_setstdcolor();
	mt_setfgcolor(COLOR_WHITE);
	bc_box(1, 1, 12, 61);
	bc_box(1, 62, 3, 22);
	bc_box(4, 62, 3, 22);
	bc_box(7, 62, 3, 22);
	bc_box(10, 62, 3, 22);
	bc_box(13, 1, 10, 44);
	bc_box(13, 45, 10, 39);
	/* Write headers */
	mt_setstdcolor();
	mt_setfgcolor(COLOR_WHITE);
	mt_gotoXY(1, 3);
	mwrite(" Memory ");
	mt_gotoXY(1, 64);
	mwrite(" Accumulator ");
	mt_gotoXY(4, 64);
	mwrite(" InstrCntr ");
	mt_gotoXY(7, 64);
	mwrite(" Operation ");
	mt_gotoXY(10, 64);
	mwrite(" Flags ");
	mt_gotoXY(13, 47);
	mwrite(" Keys ");
	/* Write Keys */
	mt_setstdcolor();
	mt_setfgcolor(COLOR_WHITE);
	mt_gotoXY(14, 47);
	mwrite("L   - Load memory dump");
	mt_gotoXY(15, 47);
	mwrite("S   - Save memory dump");
	mt_gotoXY(16, 47);
	mwrite("R   - Run / Stop");
	mt_gotoXY(17, 47);
	mwrite("T   - Step");
	mt_gotoXY(18, 47);
	mwrite("I   - Reset");
	mt_gotoXY(19, 47);
	mwrite("F5  - Set accumulator");
	mt_gotoXY(20, 47);
	mwrite("F6  - Set instructions counter");
	mt_gotoXY(21, 47);
	mwrite("Esc - Exit");
	/* Write Info (Accumulator, Counter, Operation, Flags) */
	/*   Accumulator */
	mt_gotoXY(2, 64);
	sprintf(str, "%06d", sc_accumulator);
	mwrite(str);
	/*   Instructions Counter */
	mt_gotoXY(5, 64);
	sprintf(str, "%02d", sc_instrcntr);
	mwrite(str);
	/*   Operation */
	mt_gotoXY(8, 64);
	sc_memoryGet(sc_instrcntr, &value);
	sprintf(str, "+ %02X : %02X", (value >> 7), (value & 127));
	mwrite(str);
	/*   Flags */
	mt_gotoXY(11, 64);
	mwrite("              ");
	mt_gotoXY(11, 64);
	sc_regGet(SC_F_OUTMEM, &value); if (value) mwrite("OM ");
	sc_regGet(SC_F_RUNNIN, &value); if (value) mwrite("IG ");
	sc_regGet(SC_F_DIVZER, &value); if (value) mwrite("DZ ");
	sc_regGet(SC_F_OUTVAL, &value); if (value) mwrite("OV ");
	sc_regGet(SC_F_UNKCOM, &value); if (value) mwrite("UC");
	/* Big Chars */
	if ((fd = open("font.bc", O_RDONLY, 00700)) == -1)
	{
		mt_clrscr();
		mwrite("Cannot open file 'font.bc'\n");
		rk_mytermrestore(0);
		mt_cursorVisible(1);
		return 1;
	}
	for (i = 0; i < 22; i++)
	{
		bc_bigcharread(fd, &font[i][0], &k, i);
		if (k==0) 
		{
			mt_clrscr();
			mwrite("Cannot read font\n");
			rk_mytermrestore(0);
			mt_cursorVisible(1);
			return 1;
		}
	}
	close(fd);
	sc_memoryGet(sc_instrcntr, &value);
	bc_printbigchar (&font[20][0], 2, 13, 8, COLOR_GREEN);
	bc_printbigchar (&font[(value & 127)/16][0], 10, 13, 8, COLOR_GREEN);
	bc_printbigchar (&font[(value & 127)%16][0], 18, 13, 8, COLOR_GREEN);
	bc_printbigchar (&font[(value >> 7)/16][0], 26, 13, 8, COLOR_GREEN);
	bc_printbigchar (&font[(value >> 7)%16][0], 34, 13, 8, COLOR_GREEN);
	mt_gotoXY(lastx+1, 1);
}

int ALU(int command, int operand)
{
	int tmp = 0, tmp2 = 0, tmp3 = 0;
	char str[30];
	switch (command)
	{
		case SC_ADD:
			if (sc_memoryGet(operand, &tmp))
			{
				sc_regSet(SC_F_OUTMEM, 1);
				return -1;
			}
			sc_accumulator += tmp;
			sc_instrcntr++;
			break;
		case SC_SUB:
			if (sc_memoryGet(operand, &tmp))
			{
				sc_regSet(SC_F_OUTMEM, 1);
				return -1;
			}
			sc_accumulator -= tmp;
			sc_instrcntr++;
			break;
		case SC_DIVIDE:
			if (sc_memoryGet(operand, &tmp))
			{
				sc_regSet(SC_F_OUTMEM, 1);
				return -1;
			}
			if (tmp == 0)
			{
				sc_regSet(SC_F_DIVZER, 1);
				return -1;
			}
			sc_accumulator /= tmp;
			sc_instrcntr++;
			break;
		case SC_MUL:
			if (sc_memoryGet(operand, &tmp))
			{
				sc_regSet(SC_F_OUTMEM, 1);
				return -1;
			}
			sc_accumulator *= tmp;
			sc_instrcntr++;
			break;
		case SC_JNEG:
			if ( (operand < 0) || (operand > 99) )
			{
				sc_regSet(SC_F_OUTMEM, 1);
				return -1;
			}
			if (sc_accumulator < 0)
				sc_instrcntr = operand;
			else
				sc_instrcntr++;
			break;
		case SC_JZ:
			if ( (operand < 0) || (operand > 99) )
			{
				sc_regSet(SC_F_OUTMEM, 1);
				return -1;
			}
			if (sc_accumulator == 0)
				sc_instrcntr = operand;
			else
				sc_instrcntr++;
			break;
		case SC_ADDC:
			if (sc_memoryGet(operand, &tmp))
			{
				sc_regSet(SC_F_OUTMEM, 1);
				return -1;
			}
			if (sc_memoryGet(sc_accumulator, &tmp2))
			{
				sc_regSet(SC_F_OUTMEM, 1);
				return -1;
			}
			if (sc_memoryGet(tmp2, &tmp3))
			{
				sc_regSet(SC_F_OUTMEM, 1);
				return -1;
			}
			sc_accumulator = tmp+tmp3;
			sc_instrcntr++;
			break;
		default:
			sc_regSet(SC_F_UNKCOM, 1);
			return -1;
	}
	return 0;
}

int CU(void)
{
	int command = 0, operand = 0, tmp = 0;
	int reg = 0, value = 0, checkreg = 0;
	repaint();
	sc_regGet(SC_F_RUNNIN, &reg);
	if (reg)
	{
		setAlarm(0);
		repaint();
		return 0;
	}
	/* Check Instructions Counter */
	if (sc_memoryGet(sc_instrcntr, &value))
		sc_regSet(SC_F_OUTMEM, 1);
	/* Check current command */
	if (sc_commandDecode(value, &command, &operand))
		sc_regSet(SC_F_UNKCOM, 1);
	/* Check errors */
	sc_regGet(SC_F_OUTMEM, &reg); checkreg |= reg;
	sc_regGet(SC_F_RUNNIN, &reg); checkreg |= reg;
	sc_regGet(SC_F_DIVZER, &reg); checkreg |= reg;
	sc_regGet(SC_F_OUTVAL, &reg); checkreg |= reg;
	sc_regGet(SC_F_UNKCOM, &reg); checkreg |= reg;
	if (checkreg)
	{
		sc_regSet(SC_F_RUNNIN, 1);
		setAlarm(0);
		repaint();
		return 0;
	}
	/* Timer */
	switch (command)
	{
		case SC_READ:
			mt_setstdcolor();
			rk_mytermsave(1);
			rk_mytermregime (1, 0, 0, 1, 0);
			mt_gotoXY(lastx++, 1);
			mwrite("Input: ");
			setAlarm(0);
			scanf("%d", &tmp);
			setAlarm(1);
			rk_mytermrestore(1);
			if (tmp >= 16384)
			{
				sc_regSet(SC_F_OUTVAL, 1);
				repaint();
				return -1;
			}
			if (sc_memorySet(operand, tmp))
			{
				sc_regSet(SC_F_OUTMEM, 1);
				repaint();
				return -1;
			}
			sc_instrcntr++;
			break;
		case SC_WRITE:
			if (sc_memoryGet(operand, &tmp))
			{
				sc_regSet(SC_F_OUTMEM, 1);
				repaint();
				return -1;
			}			
			mt_setstdcolor();
			mt_setfgcolor(COLOR_WHITE);
			mt_gotoXY(lastx++, 1);
			sprintf(str, "Output: %d", tmp);
			mwrite(str);
			sc_instrcntr++;
			break;
		case SC_LOAD:
			if (sc_memoryGet(operand, &tmp))
			{
				sc_regSet(SC_F_OUTMEM, 1);
				repaint();
				return -1;
			}
			sc_accumulator = tmp;
			sc_instrcntr++;
			break;
		case SC_STORE:
			if (sc_memorySet(operand, sc_accumulator))
			{
				sc_regSet(SC_F_OUTMEM, 1);
				repaint();
				return -1;
			}
			sc_instrcntr++;
			break;
		case SC_JUMP:
			if ( (operand < 0) || (operand > 99) )
			{
				sc_regSet(SC_F_OUTMEM, 1);
				repaint();
				return -1;
			}
			sc_instrcntr = operand;
			break;
		case SC_HALT:
			sc_regSet(SC_F_RUNNIN, 1);
			break;
		case SC_ADD:
		case SC_SUB:
		case SC_DIVIDE:
		case SC_MUL:
		case SC_JNEG:
		case SC_JZ:
		case SC_SUBC:
			ALU(command, operand);
			break;
		default:
			sc_regSet(SC_F_UNKCOM, 1);
			break;
	}
	repaint();
	setAlarm(1);
}

void reset(void)
{
	sc_memoryInit();
	sc_regInit();
	sc_regSet(SC_F_RUNNIN, 1);
	repaint();
}

int main(void)
{
	int value = 0;
	int reg = 0;
	int k = 0;
	char buf[20];
	unsigned short int tmp = 0;
	enum keys key;
	/* SimpleComputer Init */
	reset();
	/* Hardcoded factorial */
	sc_commandEncode(SC_READ, 12, &value);	sc_memorySet(0, value);
	sc_commandEncode(SC_LOAD, 12, &value);	sc_memorySet(1, value);
	sc_commandEncode(SC_JZ, 10, &value);	sc_memorySet(2, value);
	sc_commandEncode(SC_JNEG, 11, &value);	sc_memorySet(3, value);
	sc_commandEncode(SC_MUL, 14, &value);	sc_memorySet(4, value);
	sc_commandEncode(SC_STORE, 14, &value);	sc_memorySet(5, value);
	sc_commandEncode(SC_LOAD, 12, &value);	sc_memorySet(6, value);
	sc_commandEncode(SC_SUB, 13, &value);	sc_memorySet(7, value);
	sc_commandEncode(SC_STORE, 12, &value);	sc_memorySet(8, value);
	sc_commandEncode(SC_JUMP, 1, &value);	sc_memorySet(9, value);
	sc_commandEncode(SC_WRITE, 14, &value);	sc_memorySet(10, value);
	sc_commandEncode(SC_HALT, 0, &value);	sc_memorySet(11, value);
	sc_memorySet(12, 5);
	sc_memorySet(13, 1);
	sc_memorySet(14, 1);
	/* First paint */
	setbuf(stdout, 0);
	rk_mytermsave(0);
	mt_cursorVisible(0);
	rk_mytermregime (0, 0, 1, 0, 0);
	mt_clrscr();
	repaint();
	/* Main inf. loop */
	do
	{
		/* Signals handlers */
		signal(SIGUSR1, (void*)reset);
		signal(SIGALRM, (void*)CU);
		sc_regGet(SC_F_RUNNIN, &reg);
		k = rk_readkey(&key);
		if (k == 0) continue;
		switch (key)
		{
			case K_F5:
				if (reg == 0) break;
				mt_gotoXY(lastx++, 1);
				mwrite("Enter accumulator value: ");
				rk_mytermregime (1, 0, 0, 1, 0);
				scanf("%d", &sc_accumulator);
				rk_mytermregime (0, 0, 1, 0, 1);
				repaint();
				break;
			case K_F6:
				if (reg == 0) break;
				mt_gotoXY(lastx++, 1);
				mwrite("Enter instructions counter value: ");
				rk_mytermregime (1, 0, 0, 1, 0);
				scanf("%hu", &tmp);
				if (tmp < 0 || tmp > 99)
				{
					sc_regSet(SC_F_OUTMEM, 1);
				}
				else
				{
					sc_instrcntr = tmp;
				}
				rk_mytermregime (0, 0, 1, 0, 1);
				repaint();
				break;
			case K_I:
				reset();
				break;
			case K_R:
				if (reg)
				{
					sc_regSet(SC_F_RUNNIN, 0);
					sc_regSet(SC_F_OUTMEM, 0);
					sc_regSet(SC_F_OUTVAL, 0);
					sc_regSet(SC_F_DIVZER, 0);
					sc_regSet(SC_F_UNKCOM, 0);
					CU();
				}
				else
					sc_regSet(SC_F_RUNNIN, 1);
				break;
			case K_T:
				sc_regSet(SC_F_RUNNIN, 0);
				sc_regSet(SC_F_OUTMEM, 0);
				sc_regSet(SC_F_OUTVAL, 0);
				sc_regSet(SC_F_DIVZER, 0);
				sc_regSet(SC_F_UNKCOM, 0);
				CU();
				sc_regSet(SC_F_RUNNIN, 1);
				repaint();
				break;
			case K_S:
				if (reg == 0) break;
				mt_gotoXY(lastx++, 1);
				mwrite("Enter filename to save: ");
				rk_mytermregime (1, 0, 0, 1, 0);
				scanf("%s", buf);
				rk_mytermregime (0, 0, 1, 0, 1);
				if (sc_memorySave(buf))
				{
					mt_gotoXY(lastx++, 1);
					mwrite("Error saving dump!");
				}
				else
				{
					mt_gotoXY(lastx++, 1);
					mwrite("Dump saved!");
				}
				repaint();
				break;
			case K_L:
				if (reg == 0) break;
				mt_gotoXY(lastx++, 1);
				mwrite("Enter filename to load: ");
				rk_mytermregime (1, 0, 0, 1, 0);
				scanf("%s", buf);
				rk_mytermregime (0, 0, 1, 0, 1);
				if (sc_memoryLoad(buf))
				{
					mt_gotoXY(lastx++, 1);
					mwrite("Error loading dump!");
				}
				else
				{
					mt_gotoXY(lastx++, 1);
					mwrite("Dump loaded!");
				}
				repaint();
				break;
			case K_ENTER:
				mt_gotoXY(lastx++, 1);
				mwrite("Enter value: ");
				rk_mytermregime (1, 0, 0, 1, 0);
				scanf("%d", &value);
				rk_mytermregime (0, 0, 1, 0, 1);
				if (sc_memorySet(sc_instrcntr, value))
				{
					mt_gotoXY(lastx++, 1);
					mwrite("Error setting value!");
				}
				else
				{
					mt_gotoXY(lastx++, 1);
					mwrite("Value updated!");
				}
				repaint();
				break;
			case K_UP:
				if (reg == 0) break;
				if (sc_instrcntr < 10) break;
				sc_instrcntr -= 10;
				repaint();
				break;
			case K_DOWN:
				if (reg == 0) break;
				if (sc_instrcntr > 89) break;
				sc_instrcntr += 10;
				repaint();
				break;
			case K_LEFT:
				if (reg == 0) break;
				if (sc_instrcntr < 1) break;
				sc_instrcntr--;
				repaint();
				break;
			case K_RIGHT:
				if (reg == 0) break;
				if (sc_instrcntr > 98) break;
				sc_instrcntr++;
				repaint();
				break;
			default:
				repaint();
				break;
		}
	} while (key != K_ESC);
	/* Going down */
	setAlarm(0);
	mt_gotoXY(lastx+1, 0);
	rk_mytermrestore(0);
	mt_cursorVisible(1);
	return 0;
}

