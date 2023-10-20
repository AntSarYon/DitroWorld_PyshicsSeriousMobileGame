INCLUDE Globals.ink

-> main

=== main ===
¡Oh cielos, Oh cielos! ¡Está despertando! ¡Todos calmados!

    * [¿Por que corres?]
        ~ AnimarCientifico("Writting")
        ¡Increible! El modulo de voz parece funcionar sin inconvenientes...
        Respondiendo a tu pregunta, corria porque no todos los dias veo despertar a un ser tan avanzado como tu, <color=\#0C2BF2>DITRO</color>...
        
        ** [¿DITRO?]
            Si, ese es el nombre que se te ha sido asignado.
        
        ** [¿Ser avanzado?]
            Tu existencia es fruto del esfuerzo de muchas horas de trabajo, estudio, y muchas noches sin dormir.
            
        -- Pero no nos adelantemos...
        
    * [¿Quien eres?]
        ~ AnimarCientifico("Writting") 
        ¡Increible! El modulo de voz parece funcionar sin inconvenientes...
        
    - Mi nombre es Kao, querido <color=\#0C2BF2>DITRO</color>, pero todos suelen llamarme: Profesor Kao.
    
#speaker: Profesor Kao
Aunque, al ser tu creador, puedes llamarme PADRE, si así lo deseas.... 

    * [¡Claro!]
        ¿En serio? ¡GUAU! Debo admitir que me siento algo halagado; jejeje.
        
    * [Ejem...]
        ...  ...  ... ¿No?
        Bueno, no puedo obligarte a hacerlo.
        
    - Después de todo, como Inteligencia Artificial super avanzada, eres libre de tomar tus propias decisiones.
    
    * [¿Inteligencia avanzada?]
        -> parteDos
    
    * [¿Decisiones?]
        -> parteDos 


-> DONE

=== parteDos ===
Veras Ditro...

~ AnimarCientifico("Writting") 
Hoy, es el dia en que una Super Inteligencia Artificial Sintética despierta por primera vez
Y estamos emocionados por ver de lo que es capaz de hacer.

    * [¡Suena increíble!]
        ¿Verdad que si? tengo los pelos de punta
        
    * [¡Quiero conocerla!]
        Jajaja, creo que te lleverás una gran sorpresa
    
    - Porque esa super inteligencia de la que tanto hablamos...


Eres tú... <color=\#0C2BF2>DITRO</color>.

    * [¿Yo?]
    * [¿Me lo juras?]
    
    - En efecto, eres tú, <color=\#0C2BF2>DITRO</color>.
Quería ser al primero que vieras cuando despertaras, y por eso vine corriendo.

    *[¿Desde donde corriste?]
        Desde el baño, jeje.
        ~ AnimarCientifico("Scared")
        ¡Pero eso no es lo importante!
        -> parteTres
        
    *[¿Y ahora qué?]
        ->parteTres

-> DONE

=== parteTres ===
Ahora es cuando empieza tu misión para <color=\#0D8E2C>evolucionar</color>...
Tu misión de <color=\#938D00>Aprendizaje</color>.

    *[¿Evolucionar?]
        No es una evolución fisica, jaja, sino más una evolución intelectual, por decirlo de alguna manera.
        
    *[¿Aprendizaje?]
        Asi es, toda inteligencia artifical necesita aprender antes de funcionar como es debido... Y tu no eres la excepción.
    
    - Veras Ditro; haberte creado, y que hayas logrado despertar, no es suficiente. 
    
Necesitamos que hagas funcionar todas esas redes que hemos instalado en tu mente.

Tienes un GRAN POTENCIAL para comprender y aplicar los principios que rigen nuestro universo... 

Es por ese motivo que tu <color=\#B2AD00>Misión Principal</color> será  entender aquellas leyes naturales que rigen este mundo. Empezando por los <color=\#BF0000>PRINCIPIOS FÍSICOS</color>.

    * [¿Leyes Naturales?]
    * [¿Principios fisicos?]
    
    - Para todo lo que se mueve en este mundo, hay un POR QUÉ; así como también hay un CÓMO.

<color=\#A9A64C>Tu primera misión es entender por qué algunas cosas se mueven de la forma en que lo hacen, y por qué lo hacen. </color>.

    * [¿Y cómo haré eso?]
    
    * [¿Yo solito?]

    - Mi querido <color=\#0C2BF2>DITRO</color>... Eres capaz de lograr grandes cosas, yo lo sé.

Interactúa con las cosas y personas que encuentres a tu alrededor.
El conocimiento llega de muchas maneras...

Pero sobretodo, busca siempre <color=\#E86600>aplicar</color> lo que has aprendido. 
No hay mejor manera de aprender que HACIENDO. Si señor.

Y no creas que te dejaremos solo. ¡No señor!

~ AnimarCientifico("Scared")
¡CRAB! ¡Ven aqui en este instante!

Nuestro querido dron, CRAB, se ha ofrecido a acompañarte durante tu aventura.

Es un dron muy servicial, cuando tengas alguna duda sobre algo, puedes confiar en que él sabrá cómo ayudarte.

~ AnimarCientifico("Running")
~ FadeInPrologo()

¡Adelante <color=\#0C2BF2>DITRO</color>, ya quiero ver las grandes cosas de las que eres capaz!

~ AnimarCientifico("Running")
~ FadeInPrologo()

-> END




A medida que avances, los desafíos que enfrentes podrán parecerte más complejos, o más secillos, dependiendo de tu desempeño a lo largo de tu aventura.

Cuando interactúes con objetos, obtendrás información crucial sobre sus atributos físicos, lo que te permitirá entender de mejor forma su  comportamiento.

El uso de conceptos como la fuerza, la Masa, y la velocidad será crucial para alcanzar tus objetivos.

Pero no nos adelantemos...




Por cierto, antes de salir, te recomiendo ir a la SALA ESTE del laboratorio; mis compañeros han preparado algo muy especial para tí. 



-> DONE
*/