verwijder([], L, L).
verwijder([H|T], L, L2) :- verwijder_element(H, L, L3), verwijder(T, L3, L2).

verwijder_element(_, [], []).
verwijder_element(X, [X|T], L) :- verwijder_element(X, T, L).
verwijder_element(X, [H|T], [H|L]) :- X \= H, verwijder_element(X, T, L).