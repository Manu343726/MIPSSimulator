MIPSSimulator
=============

El objetivo del proyecto es implementar un interprete de un lenguaje ensamblador basado en la arquitectura MIPS, pero simplificada en su mayor parte.

Descripción de la arquitectura:
-------------------------------

En principio la arquitectura implementada utiliza direccionamiento de 16 bits, con palabras de 32 bits. Además, solo soporta operaciones con enteros sin signo.
La CPU contiene 32 registros de 32 bits (16 de proposito general, y 4 reservados. El resto no se utilizan por ahora). 

Por otro lado, al ser una arquitectura RISC, la mayoría de instrucciones son implementadas como pseudoinstrucciones (mov, por ejemplo).

Futuro:
-------

El objetivo primordial es conseguir implementar un intérprete del código máquina, y un sencillo ensamblador. Si todo funciona correctamente, se implementará un ensamblador de alto nivel (El cual compilará al ensamblador original) o incluso un compilador para un lenguaje de alto nivel sencillo.
