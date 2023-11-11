INCLUDE Globals.ink

-> main

=== main ===
#audio:default
¡Oh cielos, Oh cielos! ¡Está despertando! ¡Todos calmados!

    * [¿Por qué corres?]
        ~ AnimarCientifico("Writting")
        ¡Increíble! El modulo de voz parece funcionar sin inconvenientes...
        Respondiendo a tu pregunta, corría porque no todos los dias veo despertar a un ser tan avanzado como tu, <color=\#0C2BF2>DITRO</color>...
        
        ** [¿DITRO?]
            Si, ese es el nombre te hemos asignado.
        
        ** [¿Ser avanzado?]
            Tu existencia es fruto del esfuerzo de muchas horas de trabajo, estudio, y muchas noches sin dormir.
            
        -- Pero no nos adelantemos...
        
    * [¿Quién eres?]
        ~ AnimarCientifico("Writting") 
        ¡Increible! El modulo de voz parece funcionar sin inconvenientes...
        
    - Mi nombre es Kao, querido <color=\#0C2BF2>DITRO</color>, pero todos suelen llamarme: Profesor Kao.
    
#speaker:Profesor Kao
Aunque, al ser tu creador, puedes llamarme PADRE, si así lo deseas.... 

    * [¡Claro!]
        ¿En serio? ¡GUAU! Debo admitir que me siento algo halagado; jejeje.
        
    * [Ejem...]
        ...  ...  ... ¿No?
        Bueno, no puedo obligarte a hacerlo.
        
    - Después de todo, como <color=\#0C2BF2>Inteligencia Artificial</color> super avanzada, eres libre de tomar tus propias decisiones.
    
    * [¿Inteligencia avanzada?]
        -> parteDos
    
    * [¿Decisiones?]
        -> parteDos 


-> DONE

=== parteDos ===
Veras Ditro...
Hoy es el dia en que un Robot con inteligencia super avanzada despierta por primera vez... Y todos estamos emocionados por ver lo que es capaz de hacer.

    * [¡Suena increíble!]
        ¿Verdad que si? tengo los pelos de punta.
        
    * [¡Quiero conocerlo!]
        Jajaja, creo que te lleverás una gran sorpresa...
    
    - Porque ese super inteligente robot del que tanto hablamos...


Eres tú... <color=\#0C2BF2>DITRO</color>.

    * [¿Yo?]
    * [¿Me lo juras?]
    
    - En efecto, ¡eres tú!

-> parteTres

-> DONE

=== parteTres ===
Y es ahora cuando empieza tu misión para <color=\#0D8E2C>evolucionar</color>...

    *[¿Evolucionar?]
    *[¿Misión?]
    
    - Verás <color=\#0C2BF2>DITRO</color>, a pesar de tu GRAN POTENCIAL, depende de tí convertirte en lo que estás destinado a ser.
Necesitamos que pongas a trabajar todos esos circuitos que hemos instalado en tu cabeza.

Por ese motivo hemos programado tu primera <color=\#A20017>Misión</color>:
<color=\#A20017>Comprender las leyes naturales que rigen este mundo.</color>

    * [¿Leyes Naturales?]
    * [¿Cuales son esas?]
    
    - Te daré una pista: <color=\#707000>"Para todo lo que se mueve, hay un POR QUÉ; y tambien un CÓMO".</color>
    
    * [Suena interesante]
        ¡Eso es porque realmente lo es!
    
    * [¿Me lo repites?]
        Deberás entender <color=\#707000>por qué las cosas se mueven de la forma en que lo hacen, y qué es lo que eso significa.</color>
        
    - De acuerdo <color=\#0C2BF2>DITRO</color>, sera mejor que te pongas en marcha.

Y recuerda que el conocimiento llega de muchas maneras...
<color=\#E86600>Habla</color> con las personas que encuentres a tu alrededor...
<color=\#E86600>Observa</color> y <color=\#E86600>mueve</color> tantas cosas como puedas...

Pero sobretodo, busca siempre <color=\#E86600>experimentar</color> con todo lo que hayas aprendido. 
No hay mejor manera de aprender que <color=\#E86600>HACIENDO</color>; ¡Si señor!

~ AnimarCientifico("Scared")
¡Oh! ¡aguarda! No creas que te dejaremos solo.

~ AnimarCientifico("Idle")
¡¡CRAAAAAB!! ¡Ven aqui en este instante!

~ AnimarCRAB("Aparicion")
#speaker:CRAB #audio: animatedVoice
¡¿Qué ocurre Profesor?!

#speaker: Profesor Kao #audio:default
Nuestro querido dron <color=\#AB9618>CRAB</color> se ha ofrecido a acompañarte durante tu aventura.

#speaker:CRAB #audio: animatedVoice
¿Qué? ¿Cuándo hice eso?

#speaker:Profesor Kao #audio:default
<color=\#AB9618>CRAB</color> te hará una pequeña guía sobre todo lo que necesitas saber para empezar tu aventura.

#speaker:CRAB #audio: animatedVoice
¡¿Yo?!

#speaker:Profesor Kao #audio:default
Es un dron muy servicial, cuando tengas alguna duda sobre algo, oprime <color=\#E86600>[C]</color> para llamarlo.
Puedes confiar en que él siempre sabrá cómo ayudarte.

#speaker:CRAB #audio: animatedVoice
Profesor, usted nunca me dijo...

~ AnimarCientifico("Running")
#speaker:Profesor Kao #audio:default
Bueno, los veo luego muchachos! <color=\#AB9618>CRAB</color> cuida muy bien a <color=\#0C2BF2>DITRO</color> y enseñale todo lo necesario antes de partir...!

#speaker:CRAB #audio: animatedVoice
¡Profesooor...!
... Oh bueno, será mejor que nos pongamos en marcha...
Vamos <color=\#0C2BF2>DITRO</color>, utiliza las <color=\#E86600>[Flechas]</color> o <color=\#E86600>[WASD]</color> para moverte por el escenario.

~ AnimarCRAB("Retirada")
~ FadeInPrologo()

-> END

-> DONE