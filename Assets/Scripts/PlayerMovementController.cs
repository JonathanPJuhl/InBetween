using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovementController: Player
{
    [SerializeField] private DialogueUI dialogueUI;
    [SerializeField] private UIInventory uiInventory;
    public DialogueUI DialogueUI => dialogueUI;

    public IInteractable Interactable { get; set; }

    public float moveSpeed = 10f;

    public int health = 100;
    public int sanity = 100;
    public int morale = 100;

    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject blackOut;

    bool hide = false;
    bool isAlive = true;

    public Stats stats;
    
    private Inventory inventory;

    private bool uiInventoryActive = false;

    public Animator animator;
   
    public Rigidbody2D rb;

    GameObject uiInv;

    Vector2 movement;

    private void Start()
    {
        gameOver.SetActive(hide);
        restartButton.SetActive(hide);
        uiInv = GameObject.Find("UIInventory");
        uiInv.SetActive(uiInventoryActive);
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
        stats = new Stats();
        stats.UpdateAllStats();
}

    void Update()
    {
        if (dialogueUI.IsOpen)
        {
            return;
        }
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Interactable != null)
            {
                Interactable.Interact(this);
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (uiInventoryActive)
            {
                uiInventoryActive = false;
                uiInv.SetActive(uiInventoryActive);
            } else
            {
                uiInventoryActive = true;
                uiInv.SetActive(uiInventoryActive);
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Manager.PauseGame();
            //Manager.OpenPauseMenu();

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Manager.PauseGame();
            //Manager.OpenPauseMenu();

        }
    }

    public void Die()
    {
        UIController ui = (new GameObject("uiCont")).AddComponent<UIController>();
        ui.FadeIn(blackOut);
        gameOver.SetActive(!hide);
        restartButton.SetActive(!hide);
        isAlive = false;
    }

    public void Restart()
    {
        UIController ui = (new GameObject("uiCont")).AddComponent<UIController>();
        ui.FadeOut(blackOut);
       // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemWorld itemWorld = collision.GetComponent<ItemWorld>();
        if (itemWorld != null)
        {
            inventory.AddItemToInventory(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }
}
