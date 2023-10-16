using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabDialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSONs")]
    [SerializeField] private TextAsset defaultInkJSON;
    [SerializeField] private TextAsset inkJSON;

    public TextAsset InkJSON { get => inkJSON; set => inkJSON = value; }
    public TextAsset DefaultInkJSON { get => defaultInkJSON; set => defaultInkJSON = value; }

    //------------------------------------------------------

    private void Awake()
    {
        //El VisualCue estara activo al inicio del juego
        visualCue.SetActive(false);
    }

    //------------------------------------------------------------------

    private void Start()
    {
        //Asignamos el InkJSON por Default;
        InkJSON = defaultInkJSON;
    }

    //------------------------------------------------------------------

    private void Update()
    {
        ControlarReproduccionDeDialogo();

        ControlarVisualizacionDeCUE();
        
    }

    //--------------------------------------------------------------------

    private void ControlarReproduccionDeDialogo()
    {
        //Si no se esta reproduciendo dialogo...
        if (!DialogueManager.Instance.dialogueIsPlaying)
        {
            //Si se oprime el boton de interaccion
            if (InputManager.Instance.GetCrabPressed())
            {
                //Activamos el Flag de CrabHablando
                DialogueManager.Instance.speakerIsCrab = true;
                //Mostramos el Texto del inkJSON correspondiente
                DialogueManager.Instance.EnterDialogueMode(inkJSON);
            }
        }
    }

    //--------------------------------------------------------------------

    private void ControlarVisualizacionDeCUE()
    {
        //Si el dialogo esta activo, y CRAB es quien esta hablando...
        if (DialogueManager.Instance.dialogueIsPlaying && DialogueManager.Instance.speakerIsCrab)
        {
            //Activamos el icono de DIALOGO DISPONIBLE
            visualCue.SetActive(true);
        }

        else visualCue.SetActive(false);
    }
}
