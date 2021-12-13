using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattelSystem : MonoBehaviour
{

    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleUnit npcUnit;

    private void Start()
    {
        SetupBattle();
    }

    public void SetupBattle()
    {
        playerUnit.Setup();
        npcUnit.Setup();
       // GameObject.Find("BatteSystem").SetActive(true);
    }
}
