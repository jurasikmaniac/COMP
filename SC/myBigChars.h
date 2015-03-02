/*
 * myBigChars.h
 *
 *  Created on: 25.11.2011
 *      Author: x
 */

#ifndef MYBIGCHARS_H_
#define MYBIGCHARS_H_

#include <stdlib.h>
#include <string.h>
#include <stdio.h>
#include <unistd.h>
#include <sys/ioctl.h>
#include "mySimpleComputer.h"
#include "myTerm.h"

extern int bc_printA (char str);
//extern int bc_printStr (char * str);
extern int bc_box(int x1, int y1, int x2, int y2);
extern int bc_printbigchar (int big[2], int y, int x, enum colors bg_color, enum colors fg_color);
extern int bc_setbigcharpos (int * big, int x, int y, int value);
extern int bc_getbigcharpos(int * big, int x, int y, int *value);
extern int bc_bigcharwrite (int fd, int * big, int count);
extern int bc_bigcharread (int fd, int * big, int *need_count, int count);


#endif /* MYBIGCHARS_H_ */
