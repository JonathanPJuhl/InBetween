using UnityEngine;

[System.Serializable]
public class Response
{
    [SerializeField] private string responseText;
    [SerializeField] private string functionText;
    [SerializeField] private DialogueObj dialogueObj;

    public string ResponseText => responseText;

    public string FunctionText => functionText;

    public DialogueObj DialogueObj => dialogueObj;

}
