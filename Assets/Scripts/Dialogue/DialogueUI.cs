using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject dialogueBox;
    public GameObject mcCam;
    public GameObject npcCam;

    public bool IsOpen { get; private set; }

    private Typewriter typewriter;
    private ResponseHandler responseHandler;

    private void Start()
    {
        typewriter = GetComponent<Typewriter>();
        responseHandler = GetComponent<ResponseHandler>();

        CloseDialogue();
    }

    public void ShowDialogue(DialogueObj dialogueObj)
    {
        IsOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(NextDialogue(dialogueObj));
    }

    private IEnumerator NextDialogue(DialogueObj dialogueObj)
    {
        
        for (int i = 0; i < dialogueObj.Dialouge.Length; i++)
        {
            string dialogue = dialogueObj.Dialouge[i];

            yield return RunTypewriter(dialogue);

            text.text = dialogue;

            if (i == dialogueObj.Dialouge.Length - 1 && dialogueObj.HasResponses) break;

            yield return null;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        if (dialogueObj.HasResponses)
        {
            responseHandler.ShowResponses(dialogueObj.Responses);
        } else
        {
            CloseDialogue();
        }
        
    }

    private IEnumerator RunTypewriter(string dialogue)
    {
        typewriter.Run(dialogue, text);

        while (typewriter.IsRunning)
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                typewriter.Stop();
            }
        }
    } 

    private void CloseDialogue()
    {
        IsOpen = false;
        dialogueBox.SetActive(false);
        npcCam.SetActive(false);
        mcCam.SetActive(true);
        FindObjectOfType<PlayerMovementController>().moveSpeed = 5f;
        text.text = string.Empty; 
    }
}
