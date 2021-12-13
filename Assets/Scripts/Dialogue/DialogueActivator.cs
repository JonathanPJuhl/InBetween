using UnityEngine;

public class DialogueActivator : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueObj dialogueObj;
    public GameObject mcCam;
    public GameObject npcCam;

    public IInteractable Interactable { get; set; }

    public void Interact(PlayerMovementController player)
    {
        player.DialogueUI.ShowDialogue(dialogueObj);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.TryGetComponent(out PlayerMovementController player))
        {
            player.Interactable = this;
            
            if(gameObject.CompareTag("EventInteractable"))
            {
                player.moveSpeed = 0f;
                Interact(player);
                
                if (mcCam != null && npcCam !=null) { 
                    mcCam.SetActive(false);
                    npcCam.SetActive(true);
                }
            }
            
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.TryGetComponent(out PlayerMovementController player))
        {
            if(player.Interactable is DialogueActivator dialogueActivator && dialogueActivator == this)
            {
                player.Interactable = null;
            }
            
        }
    }
}
