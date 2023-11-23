INCLUDE Globals.ink

{ BaoExp2AlreadyTalked: 
    - false: ->firstInstructions 
    - true: ->secondInstructions
}

=== firstInstructions ===
#speaker:Prof. Bao  #audio:default
¡Hola <color=\#0C2BF2>DITRO</color>! ¡Soy el Profesor Bao!

Los módulos de energía de la puerta (esas cajas con pantalla naranja) se han quedado sin energía.

    * [¡Oh no!]
    * [¿Y ahora?]
    
    - La única forma de recargarlos es haciendo que absorban energía mediante el movimiento.
    
    * [¿No tienen pilas?]
        ¿Pilas? Por amor al cielo, NO.
        ¿Sabes lo mucho que esas cosas contaminan el ambiente?
    * [¿No hay enchufe?]
        Bueno, si lo hay; pero entonces el recibo de luz nos costaría muy caro, Jejeje.

    - Los módulos de energía se recargan tras recorrer cierta <color=\#A20017>distancia</color>... Mmm,  creo que con una distancia de <color=\#A20017>10 metros</color> sería más que suficiente.

    * [¿Solo los empujo?]
    * [¿Eso funcionará?]
    
    - Hay una cosa más: los sensores no abriran las puertas si los módulos muestran cierto <color=\#A20017>desplazamiento</color>. Es decir, que los Módulos deben terminar exactamente en el mismo lugar.

    * [Pero, ¿entonces?]
    * [¿Moverlos sin moverse?]

    - Verás <color=\#0C2BF2>DITRO</color>; la <color=\#A20017>distancia</color> se refiere a la longitud TOTAL del recorrido de un objeto. No importa si termina en el mismo lugar donde emepezó a moverse.

El DESPLAZAMIENTO, por otro lado, se refiere a la distancia que hay entre el punto exacto donde empezamos a movernos, y el punto en el cuál terminamos.

Eso quiere decir que los módulos de energía deben acumular una distancia de recorrido, pero finalmente deberán regresar a su posición de origen.

De esa forma, estarán activados, y su desplazamiento será 0; entonces las puertas se abrirán.

~ BaoExp2AlreadyTalked = true
~ EnableBoxes()

    * [¡Entendido!]
        -> DONE
        
    * [¿Puedes repetírmelo?]
        Los módulos de energía deben recorrer una distancia antes de encenderse. Cuando eso suceda, deben regresar a su posición de origen.
        Solo así el sensor detectará que su Desplazamiento ha sido igual a  0, y entonces las puertas podrán abrirse.

->END

=== secondInstructions ===
#speaker:Prof. Bao  #audio:default
Los módulos de energía deben recorrer una distancia antes de encenderse. Cuando eso suceda, deben regresar a su posición de origen.

Solo así el sensor detectará que su Desplazamiento ha sido igual a  0, y entonces las puertas se abrirán.

->END