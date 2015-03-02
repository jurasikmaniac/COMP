/*
 * myBigChars.c
 *
 *  Created on: 25.11.2011
 *      Author: x
 */

#include "myBigChars.h"

int bc_printA (char str)
{
	int len;
	char buf[9];
	len=sprintf(buf,"\033(0%c\033(B",str);
	write (1,buf,len);
	return(0);
}

/*
int bc_printStr (char * str)
{
	if(str == NULL)
		return(1);
	write (1,"\033(0",3);
	while(*str!='\0')
	{
		write (1,str,1);
		str++;
	}
	write (1,str,1);
	write (1,"\033(B",3);
	return(0);

}
*/

int bc_box(int x1, int y1, int x2, int y2)
{
	int i;

	if ((x1<0)||(x2<0)||(y1<0)||(y2<0))
		return 2;

	for (i=(x1+1); i < (x1+x2-1); i++)
	{
		mt_gotoXY (i, y1);
		bc_printA ('x');
		mt_gotoXY (i, y1+y2-1);
		bc_printA ('x');
	}

	for (i=(y1+1); i < (y1+y2-1); i++)
	{
		mt_gotoXY (x1, i);
		bc_printA ('q');
		mt_gotoXY (x1+x2-1, i);
		bc_printA ('q');
	}

	mt_gotoXY (x1, y1);
	bc_printA ('l');
	mt_gotoXY (x1+x2-1, y1);
	bc_printA ('m');
	mt_gotoXY (x1, y1+y2-1);
	bc_printA ('k');
	mt_gotoXY (x1+x2-1, y1+y2-1);
	bc_printA ('j');

	return 0;
}

int bc_printbigchar (int big[2], int y, int x, enum colors bg_color, enum colors fg_color)
{
	int i,j;

	mt_setfgcolor (fg_color);
	mt_setbgcolor (bg_color);

	for (i=-0; i < 4; i++)
		for (j=-1; j < 8; j++)
		{
			mt_gotoXY(i+1+x,j+1+y);
			if (big[0]&(0x1<<(31-i*8-j)))
				bc_printA ('a');
			else
				bc_printA (' ');
		}

	for (i=0; i < 4; i++)
		for (j=-1; j < 8; j++)
		{
			mt_gotoXY(i+5+x,j+1+y);
			if (big[1]&(0x1<<(31-i*8-j)))
				bc_printA ('a');
			else
				bc_printA (' ');
		}
	mt_setstdcolor();
	return 0;
}

int bc_bigcharwrite (int fd, int * big, int count)
{
	int i;
	lseek(fd,sizeof(int)*(count*2),SEEK_SET);
	for(i=0; i < 2; i++)
		write(fd,&big[i],sizeof(int));
	return 0;
}
int bc_bigcharread (int fd, int * big, int *need_count, int count)
{
	int i;
	*need_count=0;
	lseek(fd,sizeof(int)*(count*2),SEEK_SET);
	for(i=0; i < 2; i++)
		(*need_count)=read(fd,&big[i],sizeof(int));
	return 0;
}

int bc_setbigcharpos (int* big, int x, int y, int value)
{
	if((value < 0) || (value > 1))
		return 1;
	if((x > 8) || (x < 1) || (y > 8) || (y < 1))
		return 2;
	value <<= ((x - 1) * 8) + y - 1;
	if (value)
		*big |= value;
	else
		*big &= (~value);
	return 0;
}

int bc_getbigcharpos(int* big, int x, int y, int* value)
{
	if ((x > 8) || (x < 1) || (y > 8) || (y < 1))
		return 1;
	*value = ((*big) >> (((x - 1) * 8) + y - 1)) & 0x1;
	return(0);
}
