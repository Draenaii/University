verwijder3([], []).
verwijder3([3|T], L2) :- verwijder3(T, L2).
verwijder3([H|T], [H|L2]) :- H \= 3, verwijder3(T, L2).