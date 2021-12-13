using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class ResponseHandler : MonoBehaviour
{
    [SerializeField] private RectTransform responseBox;
    [SerializeField] private RectTransform responseButton;
    [SerializeField] private RectTransform responseContainer;

    private DialogueUI dialogueUI;

    List<GameObject> tempRespBtns = new List<GameObject>();

    private void Start()
    {
        dialogueUI = GetComponent<DialogueUI>();
    }
    public void ShowResponses(Response[] responses)
    {
        float responseBoxheight = 250;
        float responsesHeight = 0;

        foreach (Response response in responses)
        {
            GameObject respButton = Instantiate(responseButton.gameObject, responseContainer);
            respButton.gameObject.SetActive(true);
            respButton.GetComponent<TMP_Text>().text = response.ResponseText;
            respButton.GetComponent<Button>().onClick.AddListener(() => OnResponse(response));

            tempRespBtns.Add(respButton);
            responsesHeight += responseButton.sizeDelta.y;
            
            if(responsesHeight >= responseBoxheight) {
                responseBoxheight += responseButton.sizeDelta.y;
            }
        }

        responseBox.sizeDelta = new Vector2(responseBox.sizeDelta.x, responseBoxheight);
        responseBox.gameObject.SetActive(true);
    }

    private void OnResponse(Response response)
    {
        responseBox.gameObject.SetActive(false);

        foreach (GameObject btn in tempRespBtns)
        {
            Destroy(btn);
        }

        tempRespBtns.Clear();

        dialogueUI.ShowDialogue(response.DialogueObj);
    }
}
