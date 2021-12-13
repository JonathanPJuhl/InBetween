using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManager : MonoBehaviour
{
    public Animator animator;

    public Rigidbody2D rb;

    public void MoveNpc(GameObject npc)
    {
        Debug.Log(npc.ToString());
        animator = npc.GetComponent<Animator>();
        rb = npc.GetComponent<Rigidbody2D>();
        Vector2 movement;
        movement.x = 0;
        movement.y = 10;
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", 5);
        rb.MovePosition(rb.position + movement * 3 * Time.fixedDeltaTime);
    }

    private void FixedUpdate()
    {
       // rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}
