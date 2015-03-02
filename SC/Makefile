all:			clean SimpleComputer asmt

SimpleComputer:		SimpleComputer.o libComputer.a
			gcc -o SimpleComputer SimpleComputer.o -L. -lComputer

SimpleComputer.o:	SimpleComputer.c
			gcc -c SimpleComputer.c

asmt:			asmt.o mySimpleComputer.a
			gcc -o asmt asmt.o -L. -lmySimpleComputer

asmt.o:			asmt.c
			gcc -c asmt.c

libComputer.a:		mySimpleComputer.o myTerm.o myBigChars.o myReadkey.o
			ar rc libComputer.a mySimpleComputer.o myTerm.o myBigChars.o myReadkey.o
			ranlib libComputer.a

mySimpleComputer.a:	mySimpleComputer.o
			ar rc libmySimpleComputer.a mySimpleComputer.o
			ranlib libmySimpleComputer.a

mySimpleComputer.o:	mySimpleComputer.c
			gcc -c mySimpleComputer.c

myTerm.o:		myTerm.c
			gcc -c myTerm.c

myBigChars.o:		myBigChars.c
			gcc -c myBigChars.c

myReadkey.o:		myReadkey.c
			gcc -c myReadkey.c

clean:
			rm -f *.o *.a SimpleComputer asmt
