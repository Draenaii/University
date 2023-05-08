% fp/3 is een predicaat voor het vinden van een plan van een bepaalde toestand naar een doeltoestand.
fp(Initial, Goal, Plan) :-
    fp([([], [], Initial)], Goal, X, []), % Zoek het pad van de huidige toestand naar de doeltoestand.
    omgedraaid(X, Plan). % Keer het pad om en gebruik dit als het uiteindelijke plan.

% fp/4 is een helper predicaat dat een plan vindt vanaf de huidige toestand naar een doeltoestand met behulp van een stapsgewijze zoekprocedure.
fp([(_, P, GoalSS)|_], Goal, P, _) :-
    onderdeelL(Goal, GoalSS). % Als de huidige toestand overeenkomt met de doeltoestand, is de zoektocht voltooid.

fp([(Bezochteknoop, Acties, Knoop)|T], Goal, Plan, BezochteKnopen) :-
    % Zoek de mogelijke acties vanaf de huidige toestand en filter de ongeldige acties uit.
    findall(X, (possible_action(Actie, Knoop, X), not(subset(X, Bezochteknoop)), not((subset(X, BezochteKnopen))), not(onderdeel(Actie, Acties))), List),
    plaklijst(Bezochteknoop, Acties, Knoop, List, TList), % Voeg de nieuwe acties toe aan het huidige pad.
    plak(T, TList, Toest2), % Voeg de nieuwe knooppunten toe aan de lijst van bezochte knooppunten.
    fp(Toest2, Goal, Plan, [Knoop | BezochteKnopen]).

% possible_action/3 is een predicaat dat de nieuwe toestand berekent die ontstaat door een bepaalde actie uit te voeren.
possible_action(Action, Toest, Res) :-
    action_scheme(Action, Pre, Add, Del), % Haal de precondities, additieve en substractieve effecten op voor de opgegeven actie.
    onderdeelL(Pre, Toest), % Controleer of de precondities in de huidige toestand aanwezig zijn.
    subtract(Toest, Del, Toest2), % Verwijder de substractieve effecten uit de huidige toestand.
    union(Toest2, Add, Res). % Voeg de additieve effecten toe aan de huidige toestand.
    

% plak/3 is een predicaat om twee lijsten samen te voegen.
plak([], X, X) :- is_list(X).
plak([X|Y], Z, [X|W]) :-
    plak(Y, Z, W).

% omgedraaid/2 is een predicaat dat een lijst omkeert.
omgedraaid(X, Omgedraaid) :- omgedraaid(X, [], Omgedraaid).
omgedraaid([], X, X).
omgedraaid([X|Y], Z, Omgedraaid) :-
    omgedraaid(Y, [X|Z], Omgedraaid).

% onderdeel/2: Controleert of het eerste argument voorkomt in de lijst die wordt gegeven als het tweede argument.
%
% X: Het element dat gezocht wordt in de lijst.
% [X|]: Het element X komt voor in de lijst.
% onderdeel(X, [|T]): Het element X komt niet voor in het hoofd van de lijst, dus controleer de rest van de lijst.
onderdeel(X, [X|_]).
onderdeel(X, [_|T]) :- onderdeel(X, T).

% onderdeelL/2: Controleert of alle elementen van de eerste lijst voorkomen in de tweede lijst.
%
% []: De lege lijst is altijd een subset van een andere lijst.
% [H|T]: Controleer of het element H voorkomt in de tweede lijst, en controleer vervolgens de rest van de lijst.
onderdeelL([],_).
onderdeelL([H|T], L) :-
    onderdeel(H, L),
    onderdeelL(T, L).

% subset/2: Controleert of de eerste lijst een subset is van de tweede lijst.
%
% S: De lijst waarvan wordt gecontroleerd of deze een subset is.
% [H|]: Als de lijst S begint met het element H, dan kan S een subset zijn van de lijst.
% subset(S, [|T]): Als de lijst S niet begint met het element H, dan kan S een subset zijn van de rest van de lijst.
subset(S, [H|_]) :-
    onderdeelL(S,H).
subset(S,[_|T]) :-
    subset(S, T).

% plaklijst/5: Genereert een lijst van tupels waarin elke tupel bestaat uit een lijst met bezochte knopen, een lijst met acties en een knoop.
%
% Knoop: De knoop waarvan mogelijke acties worden gegenereerd.
% Plan: De lijst met acties die zijn uitgevoerd tot nu toe.
% Root: De initiële knoop.
% [H|T]: De lijst met mogelijke volgende knopen vanuit de huidige knoop.
% [([Root|Knoop],[Actie|Plan],H)|T2]: De lijst met tupels die wordt opgebouwd, waarin Root en Knoop de lijst zijn van bezochte knopen, Plan is de lijst met uitgevoerde acties, H is de volgende knoop en Actie is de actie die wordt uitgevoerd om van de huidige knoop naar de volgende knoop te gaan.
plaklijst(_,_,_, [], []).
plaklijst(Knoop,Plan,Root,[H|T],[([Root|Knoop],[Actie|Plan],H)|T2]) :-
    possible_action(Actie,Root,H),
    plaklijst(Knoop,Plan,Root,T,T2).




