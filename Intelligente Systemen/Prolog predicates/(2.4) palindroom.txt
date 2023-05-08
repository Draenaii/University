plak([], L, L) :- is_list(L).
plak([H|T], L2, [H|L3]) :- plak(T, L2, L3).

omgedraaid(L, R) :- omgedraaid(L, [], R).
omgedraaid([], A, A).
omgedraaid([H|T], A, R) :- omgedraaid(T, [H|A], R).

palindroomDraai(L) :- omgedraaid(L, L).
palindroomPlak(L) :- omgedraaid(L, L2), plak(L2, _, L).