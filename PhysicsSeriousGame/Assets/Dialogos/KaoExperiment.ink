INCLUDE Globals.ink

{ KAOExp3AlreadyTalked: 
    - false: ->firstInstructions 
    - true: ->secondInstructions
}

=== firstInstructions ===
#speaker:Prof. Kao  #audio:default
¡<color=\#0C2BF2>DITRO</color>! ¡Me alegra mucho verte! Veo que te estás acostumbrando a tu cuerpo.

Es increíble todo lo que puedes hacer aplicando algo de <color=\#A20017>Fuerza</color>. ¿No te parece?

    * [Es verdad]
        ¡Pues claro que sí! 
        Además de hacer que un objeto gane <color=\#A20017>velocidad</color>, podemos controlar su <color=\#A20017>dirección</color> si nos encontramos en la posición correcta.
    
    * [No es la gran cosa]
        ¡Pero <color=\#0C2BF2>DITRO</color>! ¿Como puedes decir eso..?
        La fuerza nos permite usar nuestra energía, para darle <color=\#A20017>velocidad</color> a las cosas, además de que nos permite controlar la <color=\#A20017>dirección</color> en que se mueven.

    - ¡Y eso no es todo! si nos encontramos en las mejores condiciones, podemos hacer que un objeto alcance su <color=\#A20017>velocidad máxima</color>.
    
    * [Velocidad Maxima]
    * [Mejores condiciones]
    
    - Ya sabes, cuando no existe ninguna fuerza que frene el movimiento de un objeto, este puede alcanzar su velocidad máxima.

    * [¿Y cuando sí existe?]
        Si existe una fuerza en dirección opuesta a la velocidad de un objeto, esta se reduciría lentamente, hasta llegar a 0 de nuevo.
    * [Podemos controlar eso]
        Bueno, depende de las fuerzas que actúen sobre un cuerpo. 
        Hay cosas que en el Mundo Real no podemos controlar, como la Gravedad.
        
    - Experimentemos un poco, ¿te parece?
    
Utiliza la <color=\#1BA808>Zona Cero</color> para hacer que las pelotas ganen mucha velocidad, y luego utilízalas para golpear esos sensores de ahí.

~ KAOExp3AlreadyTalked = true
~ ActivarEventoKAO()

->END

=== secondInstructions ===
#speaker:Prof. Kao  #audio:default

Usar la fuerza para que los objetos ganen velocidad es muy divertido; y puede hacerse de muchas formas.

No es lo mismo empujar un objeto que impulsarlo.
Si empujas un objeto, su velocidad puede aumenta conforme pasa el tiempo; mientras que con un impulso, el objeto recibe fuerza en un solo instante, y su velocidad puede subir rapidamente.

Utiliza la <color=\#1BA808>Zona Cero</color> para hacer que las pelotas ganen mucha velocidad, y luego utilízalas para golpear esos sensores de ahí.

->END