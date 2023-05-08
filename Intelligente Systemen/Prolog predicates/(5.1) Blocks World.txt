action_scheme(move(a1, b1, b2),
                            [on(a1, b1), clear(a1), clear(b2), block(a1), block(b2)],
                            [on(a1, b2), clear(b1)],
                            [on(a1,b1), clear(b2)]).
              
action_scheme(move_to_table(b1, b2),
                            [on(b1, b2), clear(b1), block(b1), block(b2)],
                            [on(b1, table), clear(b2)],
                            [on(b1,b2)]).