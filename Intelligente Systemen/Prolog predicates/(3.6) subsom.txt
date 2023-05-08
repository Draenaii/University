% 3.4
% Naieve versie zonder accumulator
somlijstZ([], 0).
somlijstZ([H|T], S) :- somlijstZ(T, S1), S is S1 + H.

% Versie met accumulator
somlijst(L, S) :- somlijstAcc(L, 0, S, 0).
somlijstAcc([], Acc, Acc, Total) :- Acc = Total.
somlijstAcc([H|T], Acc, S, Total) :-
    number(H),
    Acc1 is Acc + H,
    Total1 is Total + H,
    somlijstAcc(T, Acc1, S, Total1).

% 3.5
sublijst([],_).
sublijst([X|XS],[X|YS]) :- sublijst(XS,YS).
sublijst([X|XS],[_|YS]) :- sublijst([X|XS],YS).

% 3.6
subsom([], 0, []).
subsom([H|T], N, [H|X]) :- subsom(T, N1, X), N is N1 + H.
subsom([_|T], N, X) :- subsom(T, N, X).