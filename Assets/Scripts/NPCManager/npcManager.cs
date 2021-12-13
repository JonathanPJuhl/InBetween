using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NpcManager : Player
{
    public Animator animator;

    public Rigidbody2D rb;

    [SerializeField] GameObject battleCanvas;

    public void MoveNpc(GameObject npc)
    {
        Debug.Log(npc.ToString());
        animator = npc.GetComponent<Animator>();
        rb = npc.GetComponent<Rigidbody2D>();
        Vector2 movement;
        movement.x = 0;
        movement.y = 15;
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", 5);
        rb.MovePosition(rb.position + movement * 3 * Time.fixedDeltaTime);
    }

    public void FightNpc(GameObject npc)
    {
        Sprite img = npc.GetComponent<Sprite>();
        Stats npcStats = new Stats(true);
        battleCanvas.SetActive(true);

    }

}
