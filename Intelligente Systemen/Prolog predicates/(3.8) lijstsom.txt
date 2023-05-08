% 3.7
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

% 3.8
lijstsom(L,S) :-
    S > 0,
    N is floor(sqrt(2*S)),
    S is (N*(N+1))/2,
    vanTot(1,N,L).