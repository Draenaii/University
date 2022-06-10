globals [payoff-matrix strategy-colors strategies colors indices score-table displaynr]
patches-own [neighborhood strategy new-strategy mean-total-payoff dynamiek kronecker]

to setup
  set payoff-matrix (list (list CC-payoff-reward     CD-payoff-sucker    )
                          (list DC-payoff-temptation DD-payoff-punishment)) ; initialise payoff matrix
  set strategy-colors [                   ; links the strategies to their right color
    ["always-cooperate"    green  ]
    ["always-defect"       red    ]
    ["play-randomly"       grey   ]
    ["unforgiving"         102    ]
    ["tit-for-tat"         violet ]
    ["Pavlov"              brown  ]
  ]

  set strategies    map [ [x] -> item 0 x ] strategy-colors ; strip strategies from strategy-colors
  set colors        map [ [x] -> item 1 x ] strategy-colors ; strip colors     from strategy-colors
  set displaynr     1

  set indices       n-values length strategies [ [x] -> x ] ; 0, 1, .., n-1 where n is number of strategies

  ask patches [ set neighborhood (patch-set self neighbors) set dynamiek 0 ] ; 8 neighbors and myself

  initialise-run
  calculate-score-table
end

to initialise-run
  clear-output
  clear-all-plots
  reset-ticks            ; these commands clear the display and ticks but not the score-table

  ; strategy pool is a list of strategies where the multiplicity of every strategy is in accordance with its start ratio

  let strategy-bag map [ [i] -> rijtje i (1000 * run-result (word "start-" item i strategies)) ] indices
  ; strategy-bag now looks like [[0 0 0 ...] [1 1 ...] [2 2 2 2 2 ...] ...]
  ; the length of each sub-list corresponds to the start-proportion of that strategy

  let strategy-pool reduce [ [x y] -> sentence x y ] strategy-bag
  ; strategy-pool now looks like [0 0 0 ... 1 1 ... 2 2 2 2 2 ... ...]
  ; and contains about 1000 indices

  ask patches [
    set strategy one-of strategy-pool  ; "strategy" is a natural number; "one-of" is a Netlogo primitive
    set pcolor item strategy colors    ; give patch the color of the strategy it it assigned to
  ]
end

to-report rijtje [ x n ] ; e.g., rijtje 7 5 yields [7 7 7 7 7]
  report n-values n [ x ]
end

; this routine ensures that start-ratio's sum to one
to normalize-strategy-ratios
  let sum-of-strategies sum map [ [s] -> run-result (word "start-" s) ] strategies
  if abs(sum-of-strategies - 1) <= 0.001 [ stop ] ; already normalized
  foreach strategies [ [s] ->
    run (word "set start-" s " precision (start-" s " / " sum-of-strategies " ) 2")
  ]
end

; this routine is responsible for putting together the score-table, it gets its values from all the other score routines that follow
to calculate-score-table
  set score-table map [ [s] -> score-row-for s ] strategies
end

; helps the score-table routine with putting the values in rows
to-report score-row-for [ s1 ]
  report map [ [s2] -> score-entry-for s1 s2 ] strategies
end

; helps the score-row routine with calculating the values
to-report score-entry-for [ s1 s2 ]
  report mean n-values restarts [ score-for s1 s2 ]
end

; helps the score-row routine with calculating the values
to-report score-for [ s1 s2 ]
  let my-history       []
  let your-history     []
  let my-total-payoff  0
  repeat rounds [
    let my-action        play s1 my-history your-history
    let your-action      play s2 your-history my-history
    let my-payoff        item your-action (item my-action payoff-matrix)
    set my-total-payoff  my-total-payoff + my-payoff
    set my-history       fput my-action   my-history   ; most recent actions go first
    set your-history     fput your-action your-history ; same
  ]
  report (my-total-payoff / rounds)
end

; puts in the 'ruis' slider, (sometimes gives a random action) otherwise takes the action from normal strategy
to-report play [ some-strategy my-history your-history ]
  let random-action one-of [0 1] ; plays a 1 or a 0
  report ifelse-value (random-float 1.0 < ruis) [
    random-action ] [runresult (word some-strategy " my-history your-history")]
end

to-report always-cooperate [my-history your-history]
  report 0 ; always action C
end

to-report always-defect [my-history your-history]
  report 1 ; always action D
end

to-report play-randomly [my-history your-history]
  report one-of [0 1] ; plays C or D randomly
end

to-report unforgiving [my-history your-history]
  ifelse (member? 1 your-history) [report 1] [report 0] ; if opponent has played D once, always play D, otherwise C
end

to-report tit-for-tat [my-history your-history]
  ifelse (empty? your-history) [report 0] [report first your-history] ; play C but for the next round copy your opponent
end

to-report pavlov [my-history your-history]
  ifelse (empty? my-history) [report 0] [ifelse (first your-history = 1)[report (1 - (first my-history))] [report (first my-history)]] ; play C but if it loses it switches action, if it wins it keeps the action.
end

; to check whether the model is symmetrical (it most likely is)
to tapijt1
  setup
  ask patches [
    set strategy 0
  ]
  ask patch 0 0 [set strategy 1]
  ask patches [
    set pcolor item strategy colors
  ]
end

; another nice symmetrical pattern (extra feature)
to tapijt2
  setup
  ask patches [
    set strategy 0
  ]
  ask patch 30 -30 [set strategy 1]
  ask patch -30 30 [set strategy 1]
  ask patch 30 30 [set strategy 1]
  ask patch -30 -30 [set strategy 1]
  ask patches [
    set pcolor item strategy colors
  ]
end

to go
  ask patches [
    ; determine mean payoff over eight neighbors by asking them to look up in the global
    ; score-table to see what YOU (proponent patch) would earn by playing against them
    set mean-total-payoff ; a patch variable
      mean [
        item strategy item ([ strategy ] of myself) score-table
      ] of neighbors
  ]
  ask patches [
    let winner max-one-of neighborhood [mean-total-payoff]; let winner be one of patches in neighborhood with highest mean total payoff
    set new-strategy [strategy] of winner ; set new-strategy to the strategy of the winner
    ifelse new-strategy = strategy [set kronecker 1] [set kronecker 0] ; kronecker deltafunction to help calculate the 'dynamiek'
    set dynamiek 0.95 * dynamiek + 0.05 * kronecker ; these lines for dynamiek are put here because it always needs to update that variable incase you enable the dynamiek view, otherwise it has to run some ticks before it is initialised
  ]
  ask patches [
    set strategy new-strategy ; set strategy to new strategy
    if displaynr = 1 [set pcolor item strategy colors] ; strategy display (color with new strategy)
    if displaynr = 2 [set pcolor scale-color white mean-total-payoff 0.5 3] ; payoff display
    if displaynr = 3 [set pcolor scale-color white dynamiek 1 0] ; dynamiek display
  ]
  tick
  do-monitor ; output widget
end

to do-monitor
  let frequencies map [ [i] -> count patches with [ strategy = i ] ] indices
  let filtered-indices filter [ [i] -> item i frequencies > 0 ] indices ; filter dissapeared strategies
  let indices-sorted-by-proportion sort-by [ [f1 f2] -> item f1 frequencies > item f2 frequencies ] filtered-indices
  clear-output
  foreach indices-sorted-by-proportion [ [i] ->
    output-print (word count patches with [strategy = i] " "item i strategies)
  ]
end
@#$#@#$#@
GRAPHICS-WINDOW
235
10
985
761
-1
-1
6.132231405
1
10
1
1
1
0
1
1
1
-60
60
-60
60
0
0
1
ticks
30.0

SLIDER
55
185
230
218
CC-payoff-reward
CC-payoff-reward
0
5
3.0
0.1
1
NIL
HORIZONTAL

SLIDER
55
220
230
253
CD-payoff-sucker
CD-payoff-sucker
0
5
0.0
0.1
1
NIL
HORIZONTAL

SLIDER
55
255
230
288
DC-payoff-temptation
DC-payoff-temptation
0
5
5.0
0.1
1
NIL
HORIZONTAL

SLIDER
55
290
230
323
DD-payoff-punishment
DD-payoff-punishment
0
5
1.0
0.1
1
NIL
HORIZONTAL

BUTTON
55
10
140
43
setup
setup
NIL
1
T
OBSERVER
NIL
X
NIL
NIL
1

BUTTON
145
10
230
43
recalc
calculate-score-table
NIL
1
T
OBSERVER
NIL
C
NIL
NIL
1

BUTTON
55
150
110
183
reset
initialise-run
NIL
1
T
OBSERVER
NIL
R
NIL
NIL
1

BUTTON
115
150
170
183
step
go
NIL
1
T
OBSERVER
NIL
S
NIL
NIL
1

BUTTON
175
150
230
183
go
go
T
1
T
OBSERVER
NIL
G
NIL
NIL
1

SLIDER
990
550
1340
583
start-always-cooperate
start-always-cooperate
0
1
1.0
0.01
1
NIL
HORIZONTAL

SLIDER
990
585
1340
618
start-always-defect
start-always-defect
0
1
1.0
0.01
1
NIL
HORIZONTAL

SLIDER
990
620
1340
653
start-play-randomly
start-play-randomly
0
1
1.0
0.01
1
NIL
HORIZONTAL

SLIDER
990
655
1340
688
start-unforgiving
start-unforgiving
0
1
1.0
0.01
1
NIL
HORIZONTAL

SLIDER
990
690
1340
723
start-tit-for-tat
start-tit-for-tat
0
1
1.0
0.01
1
NIL
HORIZONTAL

SLIDER
990
725
1340
758
start-Pavlov
start-Pavlov
0
1
1.0
0.01
1
NIL
HORIZONTAL

SLIDER
55
45
230
78
restarts
restarts
0
1000
1000.0
1
1
NIL
HORIZONTAL

SLIDER
55
80
230
113
rounds
rounds
0
100
20.0
1
1
NIL
HORIZONTAL

SLIDER
55
115
230
148
ruis
ruis
0
1
0.0
0.01
1
NIL
HORIZONTAL

BUTTON
55
430
140
463
NIL
tapijt1
NIL
1
T
OBSERVER
NIL
NIL
NIL
NIL
1

OUTPUT
1345
550
1770
760
11

PLOT
990
10
1770
545
Proportions
NIL
NIL
0.0
10.0
0.0
1.0
true
true
"" ""
PENS
"always-cooperate" 1.0 0 -10899396 true "" "plot (count patches with [strategy = 0] / count patches)"
"always-defect" 1.0 0 -2674135 true "" "plot (count patches with [strategy = 1] / count patches)"
"play-randomly" 1.0 0 -7500403 true "" "plot (count patches with [strategy = 2] / count patches)"
"unforgiving" 1.0 0 -15390905 true "" "plot (count patches with [strategy = 3] / count patches)"
"tit-for-tat" 1.0 0 -8630108 true "" "plot (count patches with [strategy = 4] / count patches)"
"pavlov" 1.0 0 -6459832 true "" "plot (count patches with [strategy = 5] / count patches)"

BUTTON
55
355
110
388
strategy
set displaynr 1
NIL
1
T
OBSERVER
NIL
1
NIL
NIL
1

BUTTON
115
355
170
388
payoff
set displaynr 2
NIL
1
T
OBSERVER
NIL
2
NIL
NIL
1

BUTTON
145
430
230
463
NIL
tapijt2
NIL
1
T
OBSERVER
NIL
NIL
NIL
NIL
1

BUTTON
175
355
230
388
dynamiek
set displaynr 3
NIL
1
T
OBSERVER
NIL
3
NIL
NIL
1

TEXTBOX
85
330
165
348
Visualisations\n
13
0.0
1

TEXTBOX
75
395
225
426
Persian carpets (symmetry test)
13
0.0
1

@#$#@#$#@
## WHAT IS IT?

This model lets you have individuals play the spatial strategy iterated prisoner's dilemma (SSIEPD). The goal of this model is to see if players, each following their own strategy, nevertheless evolve towards collaboration (or defection). If the prisoner's dilemma is performed once, both players tend to renege, when they would be better off working together. Collaboration (and thus a higher return) can arise if parties operate in a social environment, and act on the basis of previous interactions, and after interactions adopt strategies from more successful players in their environment.

## HOW IT WORKS

Every individual is represented as a patch in a 121x121 grid. They each have a variable that is their strategy. There are 6 possible strategies: always-cooperate (always play C), always-defect (always plays D), play-randomly (randomly plays C and D), unforgiving (plays C but once an opponent has won from them, the individual will always play D), tit-for-tat (plays C but if the last action of the opponent was D, the individual copies the action for the next round), Pavlov (begins with C, if the strategy loses to another it shifts to the other action (from C to D or from D to C) and if it wins it stays the same). 

The individuals also switch strategies. They switch strategies based on the best performing neighbour. The best performing neighbour is the neighbour with the highest mean total pay-off, based on the interaction with its own neighbours. After each tick they determine who is the winning patch in their neighbourhood and they adapt that strategy.

## HOW TO USE IT

Buttons: **setup** (calculates the score-table and places the individuals according to their ratio), **recalc** (recalculates the score-table without affecting the cellular automata), **reset** (resets the cellular automata), **step** (does one tick), **go** (while active, it lets the model play), **strategy** (displays the strategies of the patches), **payoff** (visualises the payoff of the patches, white = high, black = low), **dynamic** (visualises how much a patch has switched strategy, white = many times, black = not often), **tapijt1** (shows a Persian carpet),  **tapijt2** (shows a Persian carpet).

Sliders: **restarts** (amount of restarts for calculating score-table), **rounds** (determines how many times the individuals play against each other before altering their strategies), **payoff sliders** (determines the payoff of patches according to what action they and their opponents take), **start sliders** (normalised starting ratios for all the strategies)

## THINGS TO NOTICE

The output widget orders the strategies by their amount of patches. As _**extra features we've added “Visualiseer Payoffs” and “Visualiseer Dynamiek”.**_

“Visualiseer Payoffs” looks at the individual payoffs of patches and changes their color accordingly. A white patch has a high pay-off, while a black patch has a low pay-off. Any pay-offs in between result in a shade in between white and black.

“Visualiseer Dynamiek” looks the amount a patch has changed strategy. White patches have switched strategy a relatively high amount of times, while black patches have switched strategy a relatively low amount of times.

Also, two buttons are added for aesthetically attractive patterns of patches, or so called “Perzisch Tapijt”. These patterns are also a good indicator for the symmetric process that is followed to make sure that the strategies are switched as they should be.

## THINGS TO TRY

Please try to play a bit with both the payoff sliders and the start sliders, this allows you to see what happens with different pay-off values and different population ratios. For example, try putting the restarts on '1000', rounds on '20', ruis on '0.00', standard pay-offs (3, 0, 5, 1) and all starting sliders on 1. You will get an unstable situation.

Try to use the “Dynamiek” button, this will give a good view of where most of the action happens, as this visualises the amount of times a patch has switched strategy.

Also, try to click the “Payoff” button to see which patches have the highest payoffs. The patches will be whiter than others. Patches with low payoffs will be black.

## CREDITS AND REFERENCES

Models is made by Thijmen van der Meijden (1670786) & Sam Groen (6927769), for the course Inleiding Adaptieve Systemen at Utrecht University.
@#$#@#$#@
default
true
0
Polygon -7500403 true true 150 5 40 250 150 205 260 250

airplane
true
0
Polygon -7500403 true true 150 0 135 15 120 60 120 105 15 165 15 195 120 180 135 240 105 270 120 285 150 270 180 285 210 270 165 240 180 180 285 195 285 165 180 105 180 60 165 15

arrow
true
0
Polygon -7500403 true true 150 0 0 150 105 150 105 293 195 293 195 150 300 150

box
false
0
Polygon -7500403 true true 150 285 285 225 285 75 150 135
Polygon -7500403 true true 150 135 15 75 150 15 285 75
Polygon -7500403 true true 15 75 15 225 150 285 150 135
Line -16777216 false 150 285 150 135
Line -16777216 false 150 135 15 75
Line -16777216 false 150 135 285 75

bug
true
0
Circle -7500403 true true 96 182 108
Circle -7500403 true true 110 127 80
Circle -7500403 true true 110 75 80
Line -7500403 true 150 100 80 30
Line -7500403 true 150 100 220 30

butterfly
true
0
Polygon -7500403 true true 150 165 209 199 225 225 225 255 195 270 165 255 150 240
Polygon -7500403 true true 150 165 89 198 75 225 75 255 105 270 135 255 150 240
Polygon -7500403 true true 139 148 100 105 55 90 25 90 10 105 10 135 25 180 40 195 85 194 139 163
Polygon -7500403 true true 162 150 200 105 245 90 275 90 290 105 290 135 275 180 260 195 215 195 162 165
Polygon -16777216 true false 150 255 135 225 120 150 135 120 150 105 165 120 180 150 165 225
Circle -16777216 true false 135 90 30
Line -16777216 false 150 105 195 60
Line -16777216 false 150 105 105 60

car
false
0
Polygon -7500403 true true 300 180 279 164 261 144 240 135 226 132 213 106 203 84 185 63 159 50 135 50 75 60 0 150 0 165 0 225 300 225 300 180
Circle -16777216 true false 180 180 90
Circle -16777216 true false 30 180 90
Polygon -16777216 true false 162 80 132 78 134 135 209 135 194 105 189 96 180 89
Circle -7500403 true true 47 195 58
Circle -7500403 true true 195 195 58

circle
false
0
Circle -7500403 true true 0 0 300

circle 2
false
0
Circle -7500403 true true 0 0 300
Circle -16777216 true false 30 30 240

cow
false
0
Polygon -7500403 true true 200 193 197 249 179 249 177 196 166 187 140 189 93 191 78 179 72 211 49 209 48 181 37 149 25 120 25 89 45 72 103 84 179 75 198 76 252 64 272 81 293 103 285 121 255 121 242 118 224 167
Polygon -7500403 true true 73 210 86 251 62 249 48 208
Polygon -7500403 true true 25 114 16 195 9 204 23 213 25 200 39 123

cylinder
false
0
Circle -7500403 true true 0 0 300

dot
false
0
Circle -7500403 true true 90 90 120

face happy
false
0
Circle -7500403 true true 8 8 285
Circle -16777216 true false 60 75 60
Circle -16777216 true false 180 75 60
Polygon -16777216 true false 150 255 90 239 62 213 47 191 67 179 90 203 109 218 150 225 192 218 210 203 227 181 251 194 236 217 212 240

face neutral
false
0
Circle -7500403 true true 8 7 285
Circle -16777216 true false 60 75 60
Circle -16777216 true false 180 75 60
Rectangle -16777216 true false 60 195 240 225

face sad
false
0
Circle -7500403 true true 8 8 285
Circle -16777216 true false 60 75 60
Circle -16777216 true false 180 75 60
Polygon -16777216 true false 150 168 90 184 62 210 47 232 67 244 90 220 109 205 150 198 192 205 210 220 227 242 251 229 236 206 212 183

fish
false
0
Polygon -1 true false 44 131 21 87 15 86 0 120 15 150 0 180 13 214 20 212 45 166
Polygon -1 true false 135 195 119 235 95 218 76 210 46 204 60 165
Polygon -1 true false 75 45 83 77 71 103 86 114 166 78 135 60
Polygon -7500403 true true 30 136 151 77 226 81 280 119 292 146 292 160 287 170 270 195 195 210 151 212 30 166
Circle -16777216 true false 215 106 30

flag
false
0
Rectangle -7500403 true true 60 15 75 300
Polygon -7500403 true true 90 150 270 90 90 30
Line -7500403 true 75 135 90 135
Line -7500403 true 75 45 90 45

flower
false
0
Polygon -10899396 true false 135 120 165 165 180 210 180 240 150 300 165 300 195 240 195 195 165 135
Circle -7500403 true true 85 132 38
Circle -7500403 true true 130 147 38
Circle -7500403 true true 192 85 38
Circle -7500403 true true 85 40 38
Circle -7500403 true true 177 40 38
Circle -7500403 true true 177 132 38
Circle -7500403 true true 70 85 38
Circle -7500403 true true 130 25 38
Circle -7500403 true true 96 51 108
Circle -16777216 true false 113 68 74
Polygon -10899396 true false 189 233 219 188 249 173 279 188 234 218
Polygon -10899396 true false 180 255 150 210 105 210 75 240 135 240

house
false
0
Rectangle -7500403 true true 45 120 255 285
Rectangle -16777216 true false 120 210 180 285
Polygon -7500403 true true 15 120 150 15 285 120
Line -16777216 false 30 120 270 120

leaf
false
0
Polygon -7500403 true true 150 210 135 195 120 210 60 210 30 195 60 180 60 165 15 135 30 120 15 105 40 104 45 90 60 90 90 105 105 120 120 120 105 60 120 60 135 30 150 15 165 30 180 60 195 60 180 120 195 120 210 105 240 90 255 90 263 104 285 105 270 120 285 135 240 165 240 180 270 195 240 210 180 210 165 195
Polygon -7500403 true true 135 195 135 240 120 255 105 255 105 285 135 285 165 240 165 195

line
true
0
Line -7500403 true 150 0 150 300

line half
true
0
Line -7500403 true 150 0 150 150

pentagon
false
0
Polygon -7500403 true true 150 15 15 120 60 285 240 285 285 120

person
false
0
Circle -7500403 true true 110 5 80
Polygon -7500403 true true 105 90 120 195 90 285 105 300 135 300 150 225 165 300 195 300 210 285 180 195 195 90
Rectangle -7500403 true true 127 79 172 94
Polygon -7500403 true true 195 90 240 150 225 180 165 105
Polygon -7500403 true true 105 90 60 150 75 180 135 105

plant
false
0
Rectangle -7500403 true true 135 90 165 300
Polygon -7500403 true true 135 255 90 210 45 195 75 255 135 285
Polygon -7500403 true true 165 255 210 210 255 195 225 255 165 285
Polygon -7500403 true true 135 180 90 135 45 120 75 180 135 210
Polygon -7500403 true true 165 180 165 210 225 180 255 120 210 135
Polygon -7500403 true true 135 105 90 60 45 45 75 105 135 135
Polygon -7500403 true true 165 105 165 135 225 105 255 45 210 60
Polygon -7500403 true true 135 90 120 45 150 15 180 45 165 90

sheep
false
15
Circle -1 true true 203 65 88
Circle -1 true true 70 65 162
Circle -1 true true 150 105 120
Polygon -7500403 true false 218 120 240 165 255 165 278 120
Circle -7500403 true false 214 72 67
Rectangle -1 true true 164 223 179 298
Polygon -1 true true 45 285 30 285 30 240 15 195 45 210
Circle -1 true true 3 83 150
Rectangle -1 true true 65 221 80 296
Polygon -1 true true 195 285 210 285 210 240 240 210 195 210
Polygon -7500403 true false 276 85 285 105 302 99 294 83
Polygon -7500403 true false 219 85 210 105 193 99 201 83

square
false
0
Rectangle -7500403 true true 30 30 270 270

square 2
false
0
Rectangle -7500403 true true 30 30 270 270
Rectangle -16777216 true false 60 60 240 240

star
false
0
Polygon -7500403 true true 151 1 185 108 298 108 207 175 242 282 151 216 59 282 94 175 3 108 116 108

target
false
0
Circle -7500403 true true 0 0 300
Circle -16777216 true false 30 30 240
Circle -7500403 true true 60 60 180
Circle -16777216 true false 90 90 120
Circle -7500403 true true 120 120 60

tree
false
0
Circle -7500403 true true 118 3 94
Rectangle -6459832 true false 120 195 180 300
Circle -7500403 true true 65 21 108
Circle -7500403 true true 116 41 127
Circle -7500403 true true 45 90 120
Circle -7500403 true true 104 74 152

triangle
false
0
Polygon -7500403 true true 150 30 15 255 285 255

triangle 2
false
0
Polygon -7500403 true true 150 30 15 255 285 255
Polygon -16777216 true false 151 99 225 223 75 224

truck
false
0
Rectangle -7500403 true true 4 45 195 187
Polygon -7500403 true true 296 193 296 150 259 134 244 104 208 104 207 194
Rectangle -1 true false 195 60 195 105
Polygon -16777216 true false 238 112 252 141 219 141 218 112
Circle -16777216 true false 234 174 42
Rectangle -7500403 true true 181 185 214 194
Circle -16777216 true false 144 174 42
Circle -16777216 true false 24 174 42
Circle -7500403 false true 24 174 42
Circle -7500403 false true 144 174 42
Circle -7500403 false true 234 174 42

turtle
true
0
Polygon -10899396 true false 215 204 240 233 246 254 228 266 215 252 193 210
Polygon -10899396 true false 195 90 225 75 245 75 260 89 269 108 261 124 240 105 225 105 210 105
Polygon -10899396 true false 105 90 75 75 55 75 40 89 31 108 39 124 60 105 75 105 90 105
Polygon -10899396 true false 132 85 134 64 107 51 108 17 150 2 192 18 192 52 169 65 172 87
Polygon -10899396 true false 85 204 60 233 54 254 72 266 85 252 107 210
Polygon -7500403 true true 119 75 179 75 209 101 224 135 220 225 175 261 128 261 81 224 74 135 88 99

wheel
false
0
Circle -7500403 true true 3 3 294
Circle -16777216 true false 30 30 240
Line -7500403 true 150 285 150 15
Line -7500403 true 15 150 285 150
Circle -7500403 true true 120 120 60
Line -7500403 true 216 40 79 269
Line -7500403 true 40 84 269 221
Line -7500403 true 40 216 269 79
Line -7500403 true 84 40 221 269

wolf
false
0
Polygon -16777216 true false 253 133 245 131 245 133
Polygon -7500403 true true 2 194 13 197 30 191 38 193 38 205 20 226 20 257 27 265 38 266 40 260 31 253 31 230 60 206 68 198 75 209 66 228 65 243 82 261 84 268 100 267 103 261 77 239 79 231 100 207 98 196 119 201 143 202 160 195 166 210 172 213 173 238 167 251 160 248 154 265 169 264 178 247 186 240 198 260 200 271 217 271 219 262 207 258 195 230 192 198 210 184 227 164 242 144 259 145 284 151 277 141 293 140 299 134 297 127 273 119 270 105
Polygon -7500403 true true -1 195 14 180 36 166 40 153 53 140 82 131 134 133 159 126 188 115 227 108 236 102 238 98 268 86 269 92 281 87 269 103 269 113

x
false
0
Polygon -7500403 true true 270 75 225 30 30 225 75 270
Polygon -7500403 true true 30 75 75 30 270 225 225 270
@#$#@#$#@
NetLogo 6.2.2
@#$#@#$#@
@#$#@#$#@
@#$#@#$#@
@#$#@#$#@
@#$#@#$#@
default
0.0
-0.2 0 0.0 1.0
0.0 1 1.0 0.0
0.2 0 0.0 1.0
link direction
true
0
Line -7500403 true 150 150 90 180
Line -7500403 true 150 150 210 180
@#$#@#$#@
1
@#$#@#$#@
