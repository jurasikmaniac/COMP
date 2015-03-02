/*
 * myReadkey.c
 *
 *  Created on: 25.11.2011
 *      Author: x
 */

#include "myReadkey.h"

int rk_mytermsave(int nm)
{
    return tcgetattr(0, &term[nm]);
}

int rk_mytermrestore(int nm)
{
    return tcsetattr(0, TCSANOW, &term[nm]);
}


int rk_mytermregime (int canon, int vtime, int vmin, int echo, int sigint)
{
struct termios setting;
	int result;
	if((canon > 1) || (canon < 0) || (echo > 1) || (echo < 0) || (sigint > 1) || (sigint < 0))
		return(1);
	if((vtime < 0) || (vmin < 0))
		return(2);
	result = tcgetattr (0, &setting);
		if (result ==-1) return 3;
	setting.c_lflag &= ~ICANON;
	setting.c_lflag &= ~ECHO;
	setting.c_lflag &= ~ISIG;
	if(canon)
		setting.c_lflag |= ICANON;
	if(echo)
		setting.c_lflag |= ECHO;
	if(sigint)
		setting.c_lflag |= ISIG;
	setting.c_cc[VTIME] = vtime;
	setting.c_cc[VMIN] = vmin;
	result = tcsetattr (0,TCSANOW,&setting);
	if (result == -1)
		return 4;
	return(0);
}

int rk_readkey (enum keys *key)
{
	char buf;
	int result;
	*key=K_UNKNOWN;
	result = read(0, &buf, 1);
	if(!result)
	{
		return 0;
	}
	else
	switch (buf)
	{
		default:
			*key=K_UNKNOWN;
			break;
 		case 'l':
 			*key = K_L;
 			break;
 		case 's':
 			*key = K_S;
 			break;
 		case 'r':
 			*key = K_R;
 			break;
 		case 't':
 			*key = K_T;
 			break;
 		case 'i':
 			*key = K_I;
 			break;
 		case '\n':
 			*key = K_ENTER;
 			break;
 		case '\033':
			*key = K_ESC;
			read(0, &buf, 1);
			if (buf == '[')
 			{
 				*key=K_UNKNOWN;
 				read(0, &buf, 1);
 				if(!result)
				{
					return 1;
				}
				else
 				switch (buf)
             	{
                	case 'A':
                		*key = K_UP;
                    	break;
                    case 'B':
                    	*key = K_DOWN;
                    	break;
                    case 'C':
                    	*key = K_RIGHT;
                    	break;
                    case 'D':
                    	*key = K_LEFT;
                    	break;
                    case '1':
                    	result = read(0, &buf, 1);
						if(!result)
						{
							return 0;
						}
						else
                    	if (buf == '5')
                    	{
                    		read(0, &buf, 1);
                			*key = K_F5;
                		}
                		else
                		if (buf == '7')
                		{
                			read(0, &buf, 1);
                			*key = K_F6;
                		}
                		break;
            	}

           	}

 			break;
	}
return 2;
}
