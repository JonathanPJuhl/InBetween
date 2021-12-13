using System;
using UnityEngine;

[Serializable]
public class Item
{
    public enum ItemType
    {
        HealthPotion,
        LeafTrimmer,
        Alcohol,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.HealthPotion: return ItemAssets.Instance.healthPotionSprite;
            case ItemType.Alcohol: return ItemAssets.Instance.alcoholSprite;
        }
    }

    public void GetEffectValue(Item item)
    {
        Stats stats = new Stats();
        if(item.itemType == ItemType.HealthPotion)
        {
            stats.healDamage(25);
        }
        if(item.itemType == ItemType.Alcohol)
        {
            stats.healSanity(25);
        }
    }

    public bool isStackable()
    {
        switch(itemType)
        {
            default:
            case ItemType.HealthPotion: 
            case ItemType.Alcohol:
                return true;
            //case ItemType.Sword:
            //    return false;
        }
    }
}
