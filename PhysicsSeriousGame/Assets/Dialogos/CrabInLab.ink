VAR idDialogo = 0 
~ idDialogo = RANDOM(1,5)

{idDialogo:
    - 1: -> crab1
    - 2: -> crab2
    - 3: -> crab3
    - 4: -> crab4
    - else: -> crab5
}

=== crab1 === 
#speaker: Crab #audio: laserVoice
Yo tambien fui creado en este laboratorio.
Es como mi hogar.
-> END

=== crab2 === 
#speaker: Crab #audio: laserVoice
El Cientifico Kao es el hombre mas amable que conozco, una vez me construyó una novia dron.
-> END

=== crab3 === 
#speaker: Crab #audio: laserVoice
Yo propuse la idea de que tengas cabello azul.
Si alguien te hace un cumplido, tomaré todo el crédito.
-> END

=== crab4 === 
#speaker: Crab #audio: laserVoice
La habitacion de al lado tiene objetos para experiemntar, vamos a echar un vistazo.
-> END

=== crab5 === 
#speaker: Crab #audio: laserVoice
No soy muy veloz, pero procuraré estar siempre a tu lado para lo que necesites.
-> END