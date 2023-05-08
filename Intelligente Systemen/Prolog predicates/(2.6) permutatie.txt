verwijdering(X, [X|L], L).
verwijdering(X, [Y|L], [Y|L2]) :- verwijdering(X, L, L2).

permutatieV([], []).
permutatieV([X|P], L) :-
    verwijdering(X, L, L1),
    permutatieV(P, L1).

invoeging(X, L, [X|L]).
invoeging(X, [Y|L1], [Y|L2]) :- invoeging(X, L1, L2).

permutatieI([], []).
permutatieI([X|P], L) :- 
    invoeging(X, L1, L),
    permutatieI(P, L1).