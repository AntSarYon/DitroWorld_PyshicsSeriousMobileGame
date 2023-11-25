INCLUDE Globals.ink

{ KAOExp3AlreadyTalked: 
    - false: ->firstInstructions 
    - true: ->secondInstructions
}

=== firstInstructions ===
#speaker:Prof. Kao  #audio:default
¡<color=\#0C2BF2>DITRO</color>! ¡Me alegra mucho verte! Veo que te estás acostumbrando a tu cuerpo.

Es increíble todo lo que puedes hacer aplicando algo de <color=\#A20017>Fuerza</color>. ¿No te parece?



~ KAOExp3AlreadyTalked = true
~ ActivarEventoKAO()

->END

=== secondInstructions ===
#speaker:Prof. Kao  #audio:default


->END