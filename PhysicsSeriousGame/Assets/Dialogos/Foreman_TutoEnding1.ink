INCLUDE Globals.ink

{ ForemanTutoFinishedDoorOpen: 
    - false: ->DoorClosed 
    - true: ->DoorOpen
}

=== DoorClosed ===
#speaker:Prof. Foreman  #audio:default
¿Qué te pareció la <color=\#1BA808>Zona Cero</color>? ¿Verdad que es una maravilla?

    * [Fue asombroso]
        ¿Verdad que si? Es mi más grande invento.
    * [No entendí nada]
        ...eh? ... en serio?
        Bueno bueno, no hay que apresurarnos. Estoy seguro que practicando te acostumbrarás a ella.
    - Ahora que ya conoces la <color=\#1BA808>Zona Cero</color>, podemos empezar a instuirte sobre las <color=\#A20017>Leyes naturales</color>.

Recuerda que la <color=\#1BA808>Zona Cero</color> es una herramienta para que puedas experimentar. Trata de utilizarla siempre que aprendas algo nuevo que quieras poner a prueba.

Y hablando de eso, mis compañeros te están esperando en las siguientes habitaciones. Me dijeron que han preparado muchas cosas para ayudarte con tu misión.

~ ForemanTutoFinishedDoorOpen = true

Adelante, ve a verlos!
~ AbrirPuertaTuto()

-> DONE



=== DoorOpen ===
#speaker:Prof. Foreman  #audio:default
Recuerda que la <color=\#1BA808>Zona Cero</color> es una herramienta para que puedas experimentar. Trata de utilizarla siempre que aprendas algo nuevo que quieras poner a prueba.

Mis compañeros te están esperando en las habitaciones que hay más adelante.
Adelante, ve a verlos!

-> DONE