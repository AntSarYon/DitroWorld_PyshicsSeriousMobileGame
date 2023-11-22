VAR idDialogo2 = 0 
~ idDialogo2 = RANDOM(1,2)

{idDialogo2:
    - 1: -> crab1
    - 2: -> crab2
}

=== crab1 === 
#speaker: Crab #audio: animatedVoice
La <color=\#1BA808>Zona Cero</color> tiene mucho potencial! No puedo esperar para ver si podemos utilizarla de nuevo más adelante.
-> END

=== crab2 === 
#speaker: Crab #audio: animatedVoice
Vayamos a las siguientes habitaciones, estoy seguro de que hay cosas más interesantes para hacer. 
-> END