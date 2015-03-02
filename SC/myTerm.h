/*
 * myTerm.h
 *
 *  Created on: 25.11.2011
 *      Author: x
 */

#ifndef MYTERM_H_
#define MYTERM_H_

#define OUT_STREAM 1

#include <sys/ioctl.h>
#include "mySimpleComputer.h"

enum colors {
	COLOR_BLACK,
	COLOR_RED,
	COLOR_GREEN,
	COLOR_YELLOW,
	COLOR_BLUE,
	COLOR_VIOLET,
	COLOR_BIRUZ,
	COLOR_WHITE
};

extern int mt_clrscr (void);
extern int mt_gotoXY (int x, int y);
extern int mt_getscreensize(int *rows, int *cols);
extern int mt_setfgcolor (enum colors color);
extern int mt_setbgcolor (enum colors color);
extern int mt_setstdcolor (void);
extern int mt_cursorVisible(int flag);
extern int mt_header(char * str);

#endif /* MYTERM_H_ */
