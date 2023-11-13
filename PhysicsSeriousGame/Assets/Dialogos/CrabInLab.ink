VAR idDialogo = 0 
~ idDialogo = RANDOM(1,5)

{idDialogo:
    - 1: -> crab1
    - 2: -> crab2
    - 3: -> crab3
    - 4: -> crab4
    - 5: -> crab5
}

=== crab1 === 
#speaker: Crab #audio: animatedVoice
Siempre veo que los cientificos se acercan a esa computadora, imagino que debe ser muy importante.
-> END

=== crab2 === 
#speaker: Crab #audio: animatedVoice
Para los siguientes pasos de tu entrenamiento, necesitamos acceder a los salones del ala Norte, y el ala Este del Laboratorio. 
-> END

=== crab3 === 
#speaker: Crab #audio: animatedVoice
La puerta del lado Sur da hacia el campo.
Pero antes de salir, necesitas aprender a usar las herramientas que tenemos para ti.
-> END

=== crab4 === 
#speaker: Crab #audio: animatedVoice
Yo tambien fui creado en este laboratorio. Es como mi hogar.
-> END

=== crab5 === 
#speaker: Crab #audio: animatedVoice
Siempre que mis sensores detecten algo interesante en los alrededores, me acercaré a investigar. 
Te recomiendo que me sigas, podrias descubrir algo de mucha utilidad.
-> END