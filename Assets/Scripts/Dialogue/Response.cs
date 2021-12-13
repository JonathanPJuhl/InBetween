using UnityEngine;

[System.Serializable]
public class Response
{
    [SerializeField] private string responseText;
    [SerializeField] private DialogueObj dialogueObj;

    public string ResponseText => responseText;

    public DialogueObj DialogueObj => dialogueObj;

}
