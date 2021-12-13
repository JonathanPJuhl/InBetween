using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trap : MonoBehaviour
{
    public bool is_tick;
    public int amountOfDmg;
    public int amountOftimes;
    private bool isRunning;
    [SerializeField]
    private GameObject screenOverlay;
    private bool screenOverlayIsActive;
    private Stats stats;

    private void Awake()
    {
        screenOverlayIsActive = false;
        screenOverlay.SetActive(screenOverlayIsActive);
        isRunning = false;
        stats = new Stats(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovementController player = collision.GetComponent<PlayerMovementController>();
            if (is_tick && !isRunning)
            {
                stats.TakeDamage(amountOfDmg);
                StartCoroutine(TickDmg(player));
                StartCoroutine(FadeInAndOut());
            } else { 
                stats.TakeDamage(amountOfDmg);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerMovementController player = collision.GetComponent<PlayerMovementController>();
        StopCoroutine(TickDmg(player));
    }

    private IEnumerator TickDmg(PlayerMovementController player)
    {
        isRunning = true;
        int times = amountOftimes;
       
        while (times>0) {
           
            yield return new WaitForSecondsRealtime(1);
            
            stats.TakeDamage(amountOfDmg);
            times--;

        }
        isRunning = false;

    }

    private IEnumerator FadeInAndOut()
    {
        screenOverlayIsActive = true;
        int times = amountOftimes * 2;
        while (times > 0)
        {
            if (screenOverlayIsActive)
            {
                screenOverlay.SetActive(screenOverlayIsActive);
                screenOverlayIsActive = false;
            }
            else
            {
                screenOverlay.SetActive(screenOverlayIsActive);
                screenOverlayIsActive = true;
            }
            yield return new WaitForSecondsRealtime(0.5f);
            times--;
        }
        screenOverlayIsActive = false;
    }
}
