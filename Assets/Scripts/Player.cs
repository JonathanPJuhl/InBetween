using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    protected TMP_Text healthText;
    protected TMP_Text sanityText;
    protected TMP_Text moraleText;

    [SerializeField] public TMP_Text fightHealthText;
    [SerializeField] public TMP_Text fightSanityText;
    [SerializeField] public TMP_Text fightMoraleText;
    [SerializeField] public TMP_Text characterName;
    [SerializeField] public string charName;
    [SerializeField] public Sprite fightSprite;


    public int health = 100;
    public int sanity = 100;
    public int morale = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void Die()
    {
    }

}