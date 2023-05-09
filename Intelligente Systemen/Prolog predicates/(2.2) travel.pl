travel(X,Y, go(X,Y)) :- byCar(X,Y).
travel(X,Y, go(X,Z,G)) :-
  byCar(X,Z),
  travel(Z,Y,G).

travel(X,Y, go(X,Y)) :- byTrain(X,Y).
travel(X,Y, go(X,Z,G)) :-
  byTrain(X,Z),
  travel(Z,Y,G).

travel(X,Y, go(X,Y)) :- byPlane(X,Y).
travel(X,Y, go(X,Z,G)) :-
  byPlane(X,Z),
  travel(Z,Y,G).







