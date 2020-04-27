:-dynamic especializacion/2.
:-dynamic materia/2.


agregar(X,Y):-asserta(materia(X,Y)).
remover(X):-retract(materia(X,_)).

adicionar(X):-asserta(especializacion(X)).
remover(X):-retract(especializacion(X)).

educacion:- exists_file('materia.dat'), consult('materia.dat').

guardar:-tell('materia.dat'),listing(especializacion),listing(materia),told.
