/*
 * myReadkey.h
 *
 *  Created on: 25.11.2011
 *      Author: x
 */

#ifndef MYREADKEY_H_
#define MYREADKEY_H_

#include <termios.h>
#include <unistd.h>

struct termios term[2];

enum keys{ K_UP, K_DOWN,
           K_LEFT, K_RIGHT, K_F5, K_F6,
           K_ESC, K_ENTER, K_L,
           K_S, K_R, K_T, K_I, K_UNKNOWN};

extern int rk_readkey(enum keys*);
extern int rk_mytermsave(int);
extern int rk_mytermrestore(int);
extern int rk_mytermregime(int canon, int vtime, int vmin, int echo, int sigint);

#endif /* MYREADKEY_H_ */
