vanTot(X, Y, L) :-
    number(X),
    number(Y),
    X =< Y,
    maaklijst(X, Y, L).
    
vanTot(X, Y, L) :-
    number(X),
    number(Y),
    X > Y,
    maaklijst(Y, X, RL),
    reverse(RL, L).
    
maaklijst(X, Y, [X|L]) :- 
    X < Y,
    NX is X+1,
    maaklijst(NX, Y, L).
    
maaklijst(Y, Y, [Y]).