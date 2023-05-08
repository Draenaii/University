fibonacciL(1, 1).
fibonacciL(2, 1).
fibonacciL(N, F) :-
    N > 2,
    N1 is N - 1,
    N2 is N - 2,
    fibonacciL(N1, F1),
    fibonacciL(N2, F2),
    F is F1 + F2.

fibonacciT(N, F) :- 
    N > 0,
    fibonacciT(N, 0, 1, F).
fibonacciT(0, A, _, A).
fibonacciT(N, A, B, F) :-
    N > 0,
    N1 is N - 1,
    Sum is A + B,
    fibonacciT(N1, B, Sum, F).