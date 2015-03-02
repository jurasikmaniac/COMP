/*
 * myTerm.c
 *
 *  Created on: 25.11.2011
 *      Author: x
 */
#include "myTerm.h"

int mt_clrscr (void)
{
	char s[30];
	sprintf(s, "\033[H\033[H\033[2J");
	write(OUT_STREAM, s, strlen(s));
	return 0;
}

int mt_gotoXY (int x, int y)
{
	char s[30];
	sprintf(s, "\033[%d;%dH", x, y);
	write(OUT_STREAM, s, strlen(s));
	return 0;
}

int mt_setfgcolor (enum colors color)
{
	char s[30];
	sprintf(s, "\033[3%dm", color);
	write(OUT_STREAM, s, strlen(s));
	return 0;
}

int mt_setbgcolor (enum colors color)
{
	char s[30];
	sprintf(s, "\033[4%dm", color);
	write(OUT_STREAM, s, strlen(s));
	return 0;
}

int mt_getscreensize(int *rows, int *cols)
{
	struct winsize ws;
	if (ioctl(1, TIOCGWINSZ, &ws)) return 1;
	*rows=ws.ws_row;
	*cols=ws.ws_col;
	return 0;
}

int mt_setstdcolor (void)
{
	char s[30];
	sprintf(s, "\033[0m");
	write(OUT_STREAM, s, strlen(s));
	return 0;
}

int mt_cursorVisible(int flag)
{
	char s[30];
	if ((flag < 0) || (flag > 1)) return 1;
	if (flag)
		sprintf(s, "\033[?12;25h");
	else
		sprintf(s, "\033[?25l");
	write(OUT_STREAM, s, strlen(s));
	return 0;
}

/* wtf? */
int mt_header (char *str)
{
	char s[30];
	sprintf(s, "\033]2;");
	write (OUT_STREAM, s, strlen(s));
	while(*str!='\0')
	{
		write (OUT_STREAM, str, 1);
		str++;
	}
	sprintf(s, "\007");
	write (OUT_STREAM, s, strlen(s));
	return(0);
}
