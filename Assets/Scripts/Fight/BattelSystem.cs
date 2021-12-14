using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattelSystem : MonoBehaviour
{

    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleUnit npcUnit;
    [SerializeField] TMP_Text battelDialogue;
    [SerializeField] public GameObject dialogueBox;
    [SerializeField] GameObject battleCanvas;
    private Typewriter typewriter;
    private ResponseHandler responseHandler;
    [SerializeField] DialogueObj[] dialogueObjs;
    public bool IsOpen { get; private set; }

    private void Start()
    {
        typewriter = (new GameObject("typWri")).AddComponent<Typewriter>();
        responseHandler = (new GameObject("respHan")).AddComponent<ResponseHandler>();
        SetupBattle();
        CloseDialogue();
    }

    public void SetupBattle()
    {
        playerUnit.Setup();
        npcUnit.Setup();
    }

    public void DoFight(bool isNpc)
    {
        if (!isNpc)
        {
            ShowDialogue(dialogueObjs[3]);

            if (npcUnit.player.sanity >= 70 && npcUnit.player.morale >= 70)
            {
                ShowDialogue(dialogueObjs[5]);
                battleCanvas.SetActive(false);
            }
            else
            {
                ShowDialogue(dialogueObjs[4]);
                npcUnit.player.sanity -= 5;
            }
        }
    }

    public void DoInsult(bool isNpc)
    {
        if (!isNpc)
        {
            ShowDialogue(dialogueObjs[3]);

            if (npcUnit.player.sanity >= 70 && npcUnit.player.morale >= 70)
            {
                ShowDialogue(dialogueObjs[5]);
                battleCanvas.SetActive(false);
            }
            else
            {
                ShowDialogue(dialogueObjs[4]);
                npcUnit.player.sanity -= 5;
            }
        }
    }
    public void DoConsole(bool isNpc)
    {
        if (!isNpc)
        {
            ShowDialogue(dialogueObjs[3]);

            if (npcUnit.player.sanity >= 70 && npcUnit.player.morale >= 70)
            {
                ShowDialogue(dialogueObjs[5]);
                battleCanvas.SetActive(false);
            }
            else
            {
                ShowDialogue(dialogueObjs[4]);
                npcUnit.player.sanity -= 5;
            }
        }
    }
    public void DoForgive(bool isNpc)
    {
        if (!isNpc)
        {
            ShowDialogue(dialogueObjs[3]);

            if (npcUnit.player.sanity >=70 && npcUnit.player.morale >= 70)
            {
                ShowDialogue(dialogueObjs[5]);
                if(Input.GetKeyDown(KeyCode.Space)) { 
                    battleCanvas.SetActive(false);
                }
            }
             else
            {
                ShowDialogue(dialogueObjs[4]); 
                npcUnit.player.sanity -= 5;
            }
        }
    }

    private IEnumerator NextDialogue(DialogueObj dialogueObj)
    {

        for (int i = 0; i < dialogueObj.Dialouge.Length; i++)
        {
            string dialogue = dialogueObj.Dialouge[i];

            yield return RunTypewriter(dialogue);

            battelDialogue.text = dialogue;

            if (i == dialogueObj.Dialouge.Length - 1 && dialogueObj.HasResponses) break;

            yield return null;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        if (dialogueObj.HasResponses)
        {
            responseHandler.ShowResponses(dialogueObj.Responses);
        }
        else
        {
            CloseDialogue();
        }

    }
    private IEnumerator RunTypewriter(string dialogue)
    {
        typewriter.Run(dialogue, battelDialogue);

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
        battelDialogue.text = string.Empty;
    }

    public void ShowDialogue(DialogueObj dialogueObj)
    {
        IsOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(NextDialogue(dialogueObj));
    }

}
