INCLUDE Globals.ink

{ ForemanExp4AlreadyTalked: 
    - false: ->firstInstructions 
    - true: ->secondInstructions
}

=== firstInstructions ===
#speaker:Prof. Foreman  #audio:default
Hola de nuevo <color=\#0C2BF2>DITRO</color>, esta es tu lección final.
Existe la popular creencia de que un objeto puede caer más rápido que otro, por el simple hecho de tener más masa.

    * [Claro, es obvio]
    * [¿Y no es así?]
    
    - Me temo que no lo es... En realidad, la <color=\#A20017>masa</color> de un objeto <color=\#A20017>no influye en su velocidad al caer</color>.
    
Para que puedas comprobarlo, he traído varios objetos que están siendo utilizados en una construcción muy cerca de aquí...

    * [¿Y pesan mucho?]
    
    * [¿Los robaste?]
        Claro que no; solo los tomé prestados. Los devolveré luego.

    - La mayoría de ellos son muy pesados si los comparamos con esa pelota de fútbol. Uff...

Adelante, puedes usar la <color=\#1BA808>Zona Cero</color> para jugar un poco con los objetos que traje, comprobar lo que te acabo de contar.

Cuando hayas acabado, encuentranos a mí y a los otros científicos en el salón principal. Está cruzando la puerta de la izquierda.

~ ForemanExp4AlreadyTalked = true
~ ActivarEventoFinalForeman()

->END

=== secondInstructions ===
#speaker:Prof. Kao  #audio:default

Usa la <color=\#1BA808>Zona Cero</color> para manipular los objetos que traje y experimentar con su Peso y la Gravedad.

Cuando hayas acabado, encuentranos a mí y a los otros científicos en el salón principal. Está cruzando la puerta de la izquierda.

->END