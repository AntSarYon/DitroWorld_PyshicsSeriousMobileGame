using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;

    [Header("Text Params")]
    [SerializeField] private float typingSpeed;
    //Variable para controlar el efecto de Typeo
    private Coroutine displayLineCoroutine;
    //Flag para controlar si se cambia, o completa la linea
    private bool canContinueToNextLine = false;

    // variable for the load_globals.ink JSON
    [Header("Load Globals JSON")]
    [SerializeField] private TextAsset loadGlobalsJSON;
    private DialogueVariables dialogueVariables;

    [Header("Typing Audios")]
    //ScriptableObjects con Info de Audio de Tiypeo por defecto (no se especifico)
    [SerializeField] private DialogueAudioInfoSO defaultAudioInfo;
    //ScriptableObjects con Info de Audio de Tiypeo actual
    [HideInInspector] public DialogueAudioInfoSO currentAudioInfo;
    //Lista para contener los diferentes tipos de audio existentes
    [SerializeField] private DialogueAudioInfoSO[] audioInfos;
    //Diccionario para mapear los Sonidos en base a su ID
    private Dictionary<string, DialogueAudioInfoSO> audioInfoDictionary;

    private AudioSource mAudioSource;

    [Header("Ink Story")]
    private Story currentStory;

    [Header("Dialogue Flag")]
    [HideInInspector] public bool dialogueIsPlaying;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] btnsChoices;
    private TextMeshProUGUI[] txtChoices;

    [Header("External Functions")]
    private InkExternalFunctions inkExternalFunctions;

    #region Ink-TAGS

    private const string SPEAKER_TAG = "speaker";
    private const string AUDIO_TAG = "audio";

    #endregion

    //--------------------------------------------------

    private void Awake()
    {
        Instance = this;

        //Inicializamos la clase de Variables de Dialogo
        // -> colocamos el Ink de Variables globales como atributo
        dialogueVariables = new DialogueVariables(loadGlobalsJSON);

        //Agregamos el componente de AudioSource
        mAudioSource = this.gameObject.AddComponent<AudioSource>();

        //Al inicializarse, el Audio Actual sera el msimo que el Default
        currentAudioInfo = defaultAudioInfo;

        //Inicializamos el Script de Funciones Externas
        inkExternalFunctions = new InkExternalFunctions();
    }

    //--------------------------------------------------------------

    void Start()
    {
        //En un inicio, el Dialogo (panel) estara desactivado
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        //Inicializamos el Array de Textos de Opciones en base a la cantidad de opciones
        txtChoices = new TextMeshProUGUI[btnsChoices.Length];

        //Inicializamos indice del array en 0
        int index = 0;

        //Por cada opción en la lista...
        foreach (GameObject choice in btnsChoices)
        {
            //Obtenemos el TextMeshPro de su objeto hijo
            txtChoices[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            //Incrementamos el indice
            index++;
        }

        //Inicializamos diccionario de Sonidos de typeo
        InitializeAudioInfoDictionary();

    }

    //---------------------------------------------------------
    //FUNCION: Inicializar el diccionario de sonidos
    private void InitializeAudioInfoDictionary()
    {
        //Inicializamos el Diccionario
        audioInfoDictionary = new Dictionary<string, DialogueAudioInfoSO>();

        //Agregamos el Audio Default al Diccionario
        audioInfoDictionary.Add(defaultAudioInfo.id, defaultAudioInfo);

        //Usamos un Loop para registrar los demas Audios incluidos enla Lista total
        foreach (DialogueAudioInfoSO audioInfo in audioInfos)
        {
            audioInfoDictionary.Add(audioInfo.id, audioInfo);
        }

    }

    //---------------------------------------------------------
    //FUNCION: Actualizar el Sonido de Tipeo Actual
    private void SetCurrentAudioInfo(string ID)
    {
        //Iniciamos variable para contener el nuevo Audio
        DialogueAudioInfoSO newAudioInfo = null;

        //Trtamos de obtener el AudioInfo a traves del ID
        audioInfoDictionary.TryGetValue(ID, out newAudioInfo);

        //Si obtuvimos un AudioInfo del diccionario
        if (newAudioInfo != null)
        {
            //Asignamos la info Actual
            this.currentAudioInfo = newAudioInfo;
        }
        else
        {
            Debug.Log("No encontre ese AudioInfo -> Asigne el Default");
            //Asignamos el Default para prevenir errores
            currentAudioInfo = defaultAudioInfo;
        }
    }

    //---------------------------------------------------------

    void Update()
    {
        //Si no se esta reproduciendo dialogo...
        if (!dialogueIsPlaying)
            //Retornamos inmediatamente 
            return;

        //Caso contrario, si se está reproduciendo diálogo...

        //Si se oprime el boton para continuar con el Dialogo
        if (canContinueToNextLine && InputManager.Instance.GetSubmitPressed())
        {
            //Controlamos si se puede continuar con la historia, o no
            ContinueStory();
        }
    }


    //---------------------------------------------------------------
    // Funcion para entrar al modo de dialogo -> Requiere JSON de Ink

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        //Asignamos a la Historia Actual el Texto del JOSN de entrada
        currentStory = new Story(inkJSON.text);

        //Activamos el flag, y el panel de dialogo
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        //Hacemos que el objetod e Variables empiece a escuchar la historia dle JSON
        dialogueVariables.StartListening(currentStory);

        //Activamos el Binding para estar atentos a cualquier Llamada a una Funcion Externa (desde Ink)
        inkExternalFunctions.Bind(currentStory);

        //Asignamos valores por defecto y retornamos a la ANimacion original
        displayNameText.text = "???";

        //Controlamos si se puede controlar la historia, o no --> Iniciamos
        ContinueStory();
    }

    //---------------------------------------------------------------
    // Funcion (corutina) para salir del modo de dialogo
    private IEnumerator ExitDialogueMode()
    {
        //Utilizamos un breve retraso en este caso, dado que
        //el boton de CONTINUAR es el msimo que el de SALTAR
        yield return new WaitForSeconds(0.2f);

        //Hacemos que el objetod e Variables DEJE DE a escuchar la historia del JSON
        dialogueVariables.StopListening(currentStory);

        //Hacemos el Unbinding del Ink actual para ya no considerar Funciones Externas
        inkExternalFunctions.Unbind(currentStory);

        //Desactivamos el dialogo por completo
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

        //Retornamos el Audio de dialogo al Default
        SetCurrentAudioInfo(defaultAudioInfo.id);
    }

    //---------------------------------------------------------------

    private void ContinueStory()
    {
        //Corroboramos si podemos continuar la historia (JSON con texto)
        if (currentStory.canContinue)
        {
            //Si la corutine esta activa (existe una en ejecucion)
            if (displayLineCoroutine != null)
            {
                //La detenemos
                StopCoroutine(displayLineCoroutine);
            }

            //Obtenemos la siguiente linea de Dialogo que se reproducira
            string nextLine = currentStory.Continue();

            //Manejamos el caso donde la siguinete linea corresponde a una Funcion Externa
            if (nextLine.Equals("") && !currentStory.canContinue)
            {
                //Salimos del modo de Dialogo
                StartCoroutine(ExitDialogueMode());
            }

            //Si no es el caso, seguimos normlamente...
            else
            {
                //Controlamos los TAGS de la Linea
                HandleTags(currentStory.currentTags);

                //Asignamos la Corutina que dara inicio
                //Asignamos el Texto de Dialogo de la siguiente linea de Historia (usamos efecto de Typeo)
                displayLineCoroutine = StartCoroutine(DisplayLine(nextLine));
            }
        }
        //En caso ya no quede historia por contar (JSON vacio)...
        else
        {
            //Salimos del modo de Dialogo
            StartCoroutine(ExitDialogueMode());
        }
    }

    //-------------------------------------------------------------
    //FUNCION: Mostrar las opciones de la Historia
    private void DisplayChoices()
    {
        //Creamos una lista con las Opciones de la linea de dialogo en turno
        List<Choice> currentDialogueChoices = currentStory.currentChoices;

        //Si el numero de opciones de la Historia es mayor a la cantidad de Botones
        //que se tienen disponibles...
        if (currentDialogueChoices.Count > btnsChoices.Length)
        {
            Debug.LogError("La historia presenta más opciones de las esperadas. Se recibieron: " + currentDialogueChoices.Count);
        }

        //Inicializamos un indice
        int index = 0;

        //Activamos solo la cantidad de opciones requeridas por la linea de dialogo
        foreach (Choice choice in currentDialogueChoices)
        {
            btnsChoices[index].gameObject.SetActive(true);

            //Asignamos el texto de esta opcion
            txtChoices[index].text = choice.text;

            //Incrementamos el indice
            index++;
        }

        //Desactivamos las opciones Restantes (no utilizadas)
        for (int i = index; i < btnsChoices.Length; i++)
        {
            btnsChoices[i].gameObject.SetActive(false);
        }
        
        StartCoroutine(SelectFirstChoice());

    }

    //----------------------------------------------
    private void HandleTags(List<string> currentTags)
    {
        //Por cada etiqueta en la lista de Etiquetas actual
        foreach (string tag in currentTags)
        {
            //Parseamos el Tag separando su contenido mediante ':'
            string[] splitTag = tag.Split(':');

            //CONTROLAMOS ERRORES
            //si el arreglo posee mas de 2 elementos -> ALERTAMOS
            if (splitTag.Length != 2) print("El TAG no tiene los elementos correctos: " + tag);

            //Obtenemos el Key y el Value correspondiente
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();   // Trim() <-- Eliminamos los espacios en Blanco

            //Usamos un Switch para determinar el comportamiento en base al Tag
            switch (tagKey)
            {
                case SPEAKER_TAG:
                    //Actualizamos el Texto del Speaker
                    displayNameText.text = tagValue;
                    break;

                case AUDIO_TAG:
                    //Actualizamos el Audio utilizado por el dialogo
                    SetCurrentAudioInfo(tagValue);
                    break;

                default:
                    Debug.Log("La etiqueta presenta algunos errores");
                    break;
            }
        }
    }

    //----------------------------------------------
    //Corutina para "TIPPEAR" el Texto

    private IEnumerator DisplayLine(string line)
    {
        //Llenamos el cuadro de Texto con toda la linea
        dialogueText.text = line;

        //Configuramos que no se pueda visualizar ninguno de los carcateres
        dialogueText.maxVisibleCharacters = 0;

        //Desactivamos el Flag para permitir el cambio de linea
        canContinueToNextLine = false;

        //Ocultamos las opciones
        HideChoices();

        //Inicializamos Flag para saber si se esta agregando Texto Personalizado
        bool isAddingRichTextTag = false;

        //Por cada caracter en la Linea de Dialogo
        foreach (char c in line.ToCharArray()) // <-- Llevamos caracteres a un Array
        {
            //Controlamos si el Jugador quiere que el texto se muestre, o no, de golpe
            if (InputManager.Instance.GetSubmitPressed())
            {
                Debug.Log("Mostrando inmediatamente");

                //Hacemos que todos los caacteres del Texto sean visibles
                dialogueText.maxVisibleCharacters = line.Length;

                //Detenemos el Bucle para que ya no recorra las demas letras
                break;
            }

            //Revisamos si se esta introducinedo texto Perosnalizado
            //Verificamos si el caracter corresponde a un < (Inicio de personalizacion)
            //o si el Flag ESTÁ ACTIVADO
            if (c == '<' || isAddingRichTextTag)
            {
                //Activamos el Flag
                isAddingRichTextTag = true;

                //Si el caracter recien agregado es '>' (Fin de la personalizacion)
                if (c == '>')
                {
                    //Desactivamos el Flag
                    isAddingRichTextTag = false;
                }
            }

            //Lo que esta pasando aqui es que el texto de Personalizacion se introduce de forma
            //imperceptible para el usuario; asi, el usuario solo ve el resultado final.

            //En caso no se trate de ese carcater, y el Flag no este activado...
            else
            {
                PlayDialogueSound(dialogueText.maxVisibleCharacters);

                //Incrementamos la cantidad de caracateres que se visualizan
                dialogueText.maxVisibleCharacters++;

                //Esperamos un determinado tiempo
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        //Controlamos las Opciones que deben mostrarse
        DisplayChoices();

        //Activamos el Flag para continuar
        canContinueToNextLine = true;
    }

    //----------------------------------------------
    //Hacer que haya una primera opcion seleccionada
    private IEnumerator SelectFirstChoice()
    {
        //Limpiamos el selector de objetos
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();

        //Asignamos el objeto seleccionado
        EventSystem.current.SetSelectedGameObject(btnsChoices[0].gameObject);
    }

    //--------------------------------------------------------  
    //FUNCION: hacer una Eleccion en el dialogo
    public void MakeChoice(int choiceIndex)
    {
        //Si ya podemos cambiar de linea (acabó de escribirse)...
        if (canContinueToNextLine)
        {
            //Elegimos a partir del INDICE de la opcion
            currentStory.ChooseChoiceIndex(choiceIndex);
        }
    }

    //---------------------------------------------------------------------------------------------------
    // Funcion: Reproducir sonido de dialogo -> Recibe Numero de caracteres que se mostrara en el dialogo
    private void PlayDialogueSound(int currentDisplayedCharacterCount)
    {
        //Ooabtenemos variables provenientes del ScriptableObject de Audio actual
        AudioClip dialogueTypingSoundClip = currentAudioInfo.dialogueTypingSoundClips;
        int soundFrecuencyLevel = currentAudioInfo.soundFrecuencyLevel;
        float minPitch = currentAudioInfo.minPitch;
        float maxPitch = currentAudioInfo.maxPitch;
        bool stopAudioSource = currentAudioInfo.stopAudioSource;

        //Controlamos que el sonido sea cada N caracteres
        //N es definido por la variable {typingSoundTimeInterval}

        //Si el numero del caracter activado es multiplo de N...
        if (currentDisplayedCharacterCount % soundFrecuencyLevel == 0)
        {
            //Si el Flag para Detener el Audio esta activo
            if (stopAudioSource)
            {
                //Detenemos el sonido reproducido por el Audio Source
                mAudioSource.Stop();
            }

            //Modificamos el Pitch de forma aleatoria <-- Ligera variación
            mAudioSource.pitch = Random.Range(minPitch, maxPitch);

            //Hacemos que se reproduzca el sonido de Tipeo que haymos asignado
            mAudioSource.PlayOneShot(dialogueTypingSoundClip, 0.5f);
        }
    }

    //--------------------------------------------------------------

    private void HideChoices()
    {
        //Ocultamos todos los botones en la Lista
        foreach (GameObject btnChoice in btnsChoices)
        {
            btnChoice.SetActive(false);
        }
    }

    //--------------------------------------------------------------
    //FUNCION: Obtener el valor actual de una Variable Global
    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        //Inicializamos en Nulo el valor que se devolvera
        Ink.Runtime.Object variableValue = null;

        //Tratamos de obtener el valor de la Variable que se ha recibido
        dialogueVariables.DicVariables.TryGetValue(variableName, out variableValue);

        //Si no se encuentra la variable, o esta no se ha iniciado
        if (variableValue == null)
        {
            Debug.Log("La variable " + variableName + " es NULL");
        }

        //Retornamos el Valor (si lo hubiera)
        return variableValue;
    }

}
