% Naieve versie zonder accumulator (left recursive)
faculteitLeft(0, 1).
faculteitLeft(N, F) :- 
    N > 0, 
    N1 is N-1, 
    faculteitLeft(N1, F1), 
    F is N * F1.

% Versie met accumulator (tail recursive)
faculteitTail(N, F) :- faculteitAcc(N, 1, F).
faculteitAcc(0, Acc, Acc).
faculteitAcc(N, Acc, F) :- 
    N > 0,
    N1 is N-1,
    Acc1 is Acc*N,
    faculteitAcc(N1, Acc1, F).