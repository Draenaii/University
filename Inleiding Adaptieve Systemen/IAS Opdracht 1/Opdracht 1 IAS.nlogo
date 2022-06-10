turtles-own [steps blocked]                           ;; blocked 0 is kan wel verder, blocked 1 is kan niet verder
patches-own [walkable afstand]                       ;; walkable 0 is unwalkable,  walkable 1 is walkable, afstand is afstand tot pad-patch

breed [front-turtles front-turtle]                   ;;front-turtles soort aanmaken voor frontdistance bepaling
front-turtles-own [f-afstand]                        ;;afstand variabele voor front-turtles

globals [n smoothed]                      ;; global variabelen, n voor de aantal turtles, smoothed voor de smoothness van de grafiek.

to setup
  clear-all                                           ;; reset alles
  reset-ticks
  create-turtles 11                                   ;; Creeer 11 turtles

  ask turtles [                                       ;; Zet startpunt, kleur en andere begininstellingen
    set xcor -72
    set ycor 61
    set color lime + 3
    set blocked 0
    set steps 0
    set size 5
  ]

  ask turtle 0 [facexy -72 + 1  61 + 2]                ;; Geef andere richting per turtle
  ask turtle 1 [facexy -72 + 2 61 + 1]
  ask turtle 2 [facexy -72 + 3 61 + 0]
  ask turtle 3 [facexy -72 + 2 61 + -1]
  ask turtle 4 [facexy -72 + 1 61 + -2]
  ask turtle 5 [facexy -72 + 0 61 + -3]
  ask turtle 6 [facexy -72 + -1 61 + -2]
  ask turtle 7 [facexy -72 + -2 61 + -1]
  ask turtle 8 [facexy -72 + -3 61 + 0]
  ask turtle 9 [facexy -72 + -2 61 + 1]
  ask turtle 10 [facexy -72 + -1 61 + 2]

  ask patches [
    ifelse (distancexy 0 0) > (max-pxcor - 10)         ;; Geef de bewandelbare patches aan
      [set pcolor brown
        set walkable 0]
      [set walkable 1]
    if (distancexy 225 -82) < 30
      [set walkable 0]
    if (distancexy -61 -69) < 24
      [set walkable 0]
    if (distancexy -220 -58) < 29
      [set walkable 0]
    if (distancexy 227 -61) < 28
      [set walkable 0]

    if (distancexy -227 -82) < 33
      [set walkable 0]
    if (distancexy 211 -122) < 28
      [set walkable 0]
    if (distancexy -181 -102) < 23
      [set walkable 0]
    if (distancexy 28 145) < 28
      [set walkable 0]

    if (distancexy -92 -22) < 26
      [set walkable 0]
    if (distancexy 77 -109) < 33
      [set walkable 0]
    if (distancexy 93 73) < 37
      [set walkable 0]
    if (distancexy 8 104) < 37
      [set walkable 0]

    if (distancexy -147 98) < 36
      [set walkable 0]
    if (distancexy -111 -7) < 39
      [set walkable 0]
    if (distancexy 166 19) < 31
      [set walkable 0]
    if (distancexy 133 57) < 36
      [set walkable 0]

    if (distancexy 82 -25) < 25
      [set walkable 0]
    if (distancexy -28 -141) < 39
      [set walkable 0]
    if (distancexy 110 18) < 26
      [set walkable 0]
    if (distancexy 84 -144) < 37
      [set walkable 0]

    if pxcor = 97 and pycor = -5
      [set walkable 0]
    if pxcor = 96 and pycor = -4
      [set walkable 0]
  ]

  ask patches[
    if (walkable = 0) [set pcolor brown]               ;; geef alle unwalkable patches de bruine kleur
    set afstand 0                                     ;; reset distance
  ]

  set smoothed 0                                       ;; Variabele voor smoothing van grafiek
  print count patches with [pcolor = black]
  print count patches
end

to blocked?                                            ;; methode om te kijken of een turtle geblocked is
  let view (patches in-cone look-forward look-aside)      ;; creeer agentset van de patches in gezichtsveld
  if member? patch-here view                              ;; Check of de eigen patch in de agentset zit
    [set view view with [[patch-here] of myself != self]] ;; Indien ja, verwijder dez
  let obstacles view with [walkable = 0]                  ;; maak agentset met alle patches die unwalkable zijn
  ifelse any? obstacles                                   ;; indien obstacles leeg is, zet blocked-property van turtle op 0, dus unblocked
    [set blocked 1]
    [set blocked 0]
end

to step                                                ;; methode om een stap te maken
  forward 1                                               ;; zet stap voorwaarts met grootte 1
  set pcolor color                                        ;; verander kleur van onderliggende patch in kleur van turtle
  set steps steps + 1                                     ;; update stappenteller
end

to move1                                               ;; methode om eerste actie te bepalen (stap zetten of hatchen)
  ifelse (blocked = 0) and (steps < hatch-modulus) and (can-move? 1)        ;; voorwaarde om stap te kunnen doen als waar, splitten als onwaar
    [step]                                                ;; zie step methode
    [split                                                ;; zie split methode
    rt (min-angle + random rand-extra-angle)              ;; draai naar rechts
    move2]                                                ;; zie methode move2
end

to move2                                               ;; methode om tweede actie te bepalen (stap zetten of dood gaan)
  ifelse (blocked = 0) and (steps < hatch-modulus) and (can-move? 1)       ;; voorwaarde om stap te kunnen doen als waar, doodgaan als onwaar
      [step]                                              ;; zie step methode
      [die]                                               ;; ga dood
end

to split                                               ;; methode om te hatchen
  set steps 0                                             ;; reset stappenteller
  hatch 1 [lt (min-angle + random rand-extra-angle)       ;; hatch, laat 'kind' naar links draaien en bepalen of hij een stap moet zetten of doodgaan
  move2]
end

to go
  ask turtles [
    blocked?
    move1
  ]
  set n count turtles                                        ;; aantal turtles voor grafiek
  set smoothed smoothness * smoothed + (1 - smoothness) * n  ;; formule om de grafiek te smoothen
  ask patches [
    if pcolor != black [set walkable 0]]
  if not any? turtles
  [frontdistance
   ask patches with [walkable = 1][
    set pcolor scale-color yellow (0 + 7.5 * afstand) 0 150]                                ;;geef de patches de juiste kleur, hoe hoger de afstand hoe feller het geel
   stop]
  ;;[probedistance]

  tick
end

to frontdistance
  ask patches with [pcolor = lime + 3][                                     ;; eerste front-turtles spawnen op bewandelde patches
    sprout-front-turtles 1 [set f-afstand 0]                                ;; begin configuratie 'afstand' variabelen
    set afstand 0
  ]
  let counter 1
  loop[
    if (not any? patches with [(pcolor = black) and (afstand = 0)]) [stop]    ;; een loop die front-turtles spawnt op neighbors en de goede afstandwaarde geeft aan de patch
    ask front-turtles [
      ask neighbors with [(pcolor = black) and (afstand = 0)][
        sprout-front-turtles 1 [set f-afstand f-afstand + counter]
        set afstand afstand + counter
      ]
    die                                                                      ;; oude turtles gaan dood zodat je niet oneindig veel turtles krijgt
    ]
   set counter counter + 1
  ]
end

to probedistance
  ask patches with [walkable = 1][
    let radius 2                                ;; beginconfiguratie cirkelgrootte
    let succes any? patches with [(distancexy pxcor pycor < radius) and (pcolor = lime + 3)] ;;succes is waar als er een pad-patch binnen de cirkel zit
    while [not succes]  ;; zolang succes niet waar is, vergroot de cirkel
      [set radius (radius + 1)
      set succes any? patches with [(distancexy pxcor pycor < radius) and (pcolor = lime + 3)]
      ]
    set afstand radius ;;radius is hetzelfde als afstand
    set pcolor scale-color yellow ((log afstand 2) + 3) 0 10  ;;geef de patches de juiste kleur, hoe hoger de afstand hoe veller het geel
   ]
end

to randomize
  set hatch-modulus random 100 + 1 ;;random nummer tussen 1 en 100
  set look-forward random 50 + 1 ;;random nummer tussen 1 en 50
  set look-aside random 200 + 1 ;;random nummer tussen 1 en 200
  set min-angle random 91 ;;random nummer tussen 0 en 90
  set rand-extra-angle random 91 ;;random nummer tussen 0 en 90
end
@#$#@#$#@
GRAPHICS-WINDOW
214
10
795
393
-1
-1
1.243
1
10
1
1
1
0
0
0
1
-230
230
-150
150
0
0
1
ticks
75.0

BUTTON
82
11
145
44
NIL
setup
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
148
11
211
44
NIL
go
T
1
T
OBSERVER
NIL
NIL
NIL
NIL
1

SLIDER
14
103
211
136
look-forward
look-forward
1
50
7.0
1
1
NIL
HORIZONTAL

SLIDER
14
137
211
170
look-aside
look-aside
1
200
44.0
1
1
NIL
HORIZONTAL

SLIDER
14
69
211
102
hatch-modulus
hatch-modulus
1
100
6.0
1
1
NIL
HORIZONTAL

SLIDER
12
170
211
203
min-angle
min-angle
0
90
18.0
1
1
NIL
HORIZONTAL

SLIDER
11
204
211
237
rand-extra-angle
rand-extra-angle
0
90
87.0
1
1
NIL
HORIZONTAL

PLOT
798
10
1071
200
Aantal Turtles
Ticks
Turtles
0.0
10.0
0.0
10.0
true
false
"" ""
PENS
"default" 1.0 0 -13345367 true "" "plot smoothed"

BUTTON
5
11
79
45
random
randomize
NIL
1
T
OBSERVER
NIL
NIL
NIL
NIL
1

MONITOR
450
397
616
442
percent-covered-by-path
((count patches with [pcolor = lime + 3]) / 81176) * 100
2
1
11

MONITOR
450
446
616
491
mean-distance-to-closest-path
mean [afstand] of patches
2
1
11

MONITOR
618
447
793
492
max-distance-to-closest-path
max [afstand] of patches
0
1
11

MONITOR
618
397
793
442
max-count-turtles
max smoothed
0
1
11

SLIDER
797
200
1072
233
smoothness
smoothness
0
1
0.9
0.01
1
NIL
HORIZONTAL

PLOT
797
235
1072
490
Distribution of distance to closest path
NIL
NIL
0.0
1000.0
0.0
1000.0
true
false
"set-plot-x-range 0 (max [afstand] of patches)\nset-plot-y-range 0 (count patches with [walkable = 1])\nset-histogram-num-bars 7" "set-plot-x-range 0 (max [afstand] of patches)"
PENS
"default" 1.0 0 -16777216 true "" "histogram [afstand] of patches"

@#$#@#$#@
## WHAT IS IT?



In dit model simuleren we een zogenmaande granular fluid, een patroon dat ontstaat wanneer een mengsel van korrels en vloeistof tussen twee glasplaten langzaam wordt afgevoerd.



## HOW IT WORKS



Op het tijdstip 0, staan er 11 exploreerders klaar, evenredig georienteerd op 360 graden. Deze exploreerders hebben de volgende eigenschappen: een stappenteller, een zichtsveld, een vaste draaihoek, en een random draaihoek. Deze eigenschappen hebben invloed op wanneer een exploreerde zich opsplitst of dood gaat.
    Een exploreerder splitst zich op indien zijn stappenteller groter is dan de door de gebruiker ingestelde “hatch-modulus”, hij tegen een onbewandelbare patch aanloopt, of van het canvas dreigt te lopen.
    Een exploreerder heeft vrij baan als deze geen onbewandelbare patch in zijn zichtspeld heeft. Dit gezichtsveld bestaat uit twee door de gebruiker in te stellen variabelen: “look-forward” en “look-aside”. “Look-forward” geeft aan hoe ver de exploreerder vooruit kijkt, “look-aside” geeft de hoek van het gezichtsveld aan.
    Als de exploreerder zich splits, draait zijn ‘kind’ naar links in de vooraf bepaalde “min-angle", plus een random aantal graden in de range van 0 tot de ingestelde “rand-extra-angle”. De ‘ouder’ exploreerder doet hetzelfde, maar dan in de andere richting, rechts. Zowel het ‘ouder’ als het ‘kind’ exploreerder reset zijn stappenteller, en kijkt of hij nu wel vrij baan heeft. Indien hij geen vrije baan heeft, zullen beide exploreerders dood gaan.

Als alle exploreerders zijn overleden, wordt er berekend hoe goed zij geëxploreerd hebben door te kijken wat de gemiddelde afstand is tussen de niet bewandelde behandelbare paden (de zwarte patches) tot het bewandelde pad (het lime-kleurige pad).



## HOW TO USE IT



De gebruiker heeft dus invloed op de volgende parameters: “hatch-modulus”, “look-forward”, “look-aside”, “min-angle”, “rand-extra-angle”.
    Deze parameters kunnen worden aangepast door de sliders naast het canvas te gebruiken.
    De knop “random” geeft de parameters random waardes. (dit is de extra feature)



## THINGS TO NOTICE



Doordat de hoek waarin de exploreerders draaien wordt beïnvloed door de random parameter “rand-extra-angle”, bewandelen ze steeds een ander patroon, ook als de parameters hetzelfde zijn. Hierdoor verschilt dus ook de efficiëntie van de exploreerders.



## FEATURES


Als extra feature hebben we een 'random' knop toegevoegt. Deze randomized de instellingen van het programma. Je zult altijd een werkende combinatie van instellingen krijgen.


## THINGS TO TRY



De gebruiker kan spelen met de parameter instellingen en zo ontdekken welke configuraties leiden tot efficiënte exploratie.



## EXTENDING THE MODEL



Indien de gebruiker wilt, kan het een aantal dingen veranderen. Allereerst is het misschien leuk om bepaalde onbewandelbare cirkels weg te halen, of juist andere toe te voegen. Daarnaast kan het interessant zijn om de exploreerden in plaats van één keer te laten splitsen, twee keer te laten splitsen en daarna pas dood te gaan.



## CREDITS AND REFERENCES



Dit model is gemaakt door Thijmen van der Meijden (1670786) en Sam Groen (6927769) voor het vak Inleiding Adaptieve Systemen, gegeven aan Universiteit Utrecht.
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
<experiments>
  <experiment name="experiment" repetitions="1" runMetricsEveryStep="true">
    <setup>setup</setup>
    <go>go</go>
    <metric>count turtles</metric>
    <enumeratedValueSet variable="look-forward">
      <value value="13"/>
    </enumeratedValueSet>
    <enumeratedValueSet variable="rand-extra-angle">
      <value value="71"/>
    </enumeratedValueSet>
    <enumeratedValueSet variable="look-aside">
      <value value="33"/>
    </enumeratedValueSet>
    <enumeratedValueSet variable="min-angle">
      <value value="14"/>
    </enumeratedValueSet>
    <enumeratedValueSet variable="hatch-modulus">
      <value value="16"/>
    </enumeratedValueSet>
  </experiment>
</experiments>
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
0
@#$#@#$#@
