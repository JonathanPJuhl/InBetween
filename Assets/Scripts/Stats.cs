using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stats: MonoBehaviour
{
    private PlayerMovementController player;

    private TMP_Text healthText;
    private TMP_Text sanityText;
    private TMP_Text moraleText;

    public Stats()
    {
        healthText = GameObject.Find("HealthText").GetComponent<TMP_Text>();
        sanityText = GameObject.Find("SanityText").GetComponent<TMP_Text>();
        moraleText = GameObject.Find("MoraleText").GetComponent<TMP_Text>();
        player = FindObjectOfType<PlayerMovementController>();
    }

    public void TakeDamage(int dmg)
    {
        player.health -= dmg;
        if (player.health == 0)
        {
            player.health = 0;
            player.Die();
        } else { 
        updateHealthText();
        }
    }
    public void healDamage(int heal)
    {
        player.health += heal;
        if(player.health >= 100)
        {
            player.health = 100;
        }
        updateHealthText();
    }

    public void TakeSanityDamage(int dmg)
    {
        player.sanity -= dmg;
        updateSanityText();
    }
    public void healSanity(int heal)
    {
        player.sanity += heal;
        if (player.sanity >= 100)
        {
            player.sanity = 100;
        }
        updateSanityText();
    }

    public void TakeMoraleDamage(int dmg)
    {
        player.morale -= dmg;
        updateMoraleText();
    }
    public void healMorale(int heal)
    {
        player.morale += heal;
        if (player.morale >= 100)
        {
            player.morale = 100;
        }
        updateMoraleText();
    }

    public void updateHealthText()
    {
        healthText.text = "HEALTH: " + player.health.ToString();
        if (player.health <= 60 && player.health > 40)
        {
            healthText.color = Color.yellow;
        }
        if (player.health <= 40)
        {
            healthText.color = Color.red;
        }
        if (player.health <= 0)
        {
            Debug.Log("You died");
        }
    }
    public void updateSanityText()
    {
        sanityText.text = "SANITY: " + player.sanity.ToString();
        if (player.sanity <= 60 && player.sanity > 40)
        {
            sanityText.color = Color.yellow;
        }
        if (player.sanity <= 40)
        {
            sanityText.color = Color.red;
        }
        if (player.sanity <= 0)
        {
            sanityText.color = Color.black;
        }
    }
    public void updateMoraleText()
    {
        moraleText.text = "MORALE: " + player.morale.ToString();
        if (player.morale <= 60 && player.morale > 40)
        {
            moraleText.color = Color.yellow;
        }
        if (player.morale <= 40)
        {
            moraleText.color = Color.red;
        }
        if (player.morale <= 0)
        {
            moraleText.color = Color.black;
        }
    }

    public void UpdateAllStats()
    {
        updateHealthText();
        updateMoraleText();
        updateSanityText();
    }

}
