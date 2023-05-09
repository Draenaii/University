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