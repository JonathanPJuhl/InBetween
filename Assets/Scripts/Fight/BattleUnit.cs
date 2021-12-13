using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    public Player player;
    public void Setup()
    {
        GetComponent<Image>().sprite = player.fightSprite;   
    }
}
