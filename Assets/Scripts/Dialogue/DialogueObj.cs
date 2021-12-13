using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObj")]
public class DialogueObj : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialogue;
    [SerializeField] Response[] responses;
    [SerializeField] FightObj fightObj;

    public bool HasResponses => responses != null && responses.Length > 0;

    public string[] Dialouge => dialogue;

    public Response[] Responses => responses;

    public FightObj FightObj => fightObj;
}
