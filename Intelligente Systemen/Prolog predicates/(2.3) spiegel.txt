spiegel(leaf(X), leaf(X)).
spiegel(tree(X, Y), tree(RevY, RevX)) :-
    spiegel(X, RevX),
    spiegel(Y, RevY).







