using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> items;
    public event EventHandler OnItemListChanged;
    public Inventory()
    {
        items = new List<Item>();
    }

    public void AddItemToInventory(Item item)
    {
        if (item.isStackable())
        {
            bool itemAldreadyInInv = false;
            foreach (Item itemInInventory in items)
            {
                if(itemInInventory.itemType == item.itemType)
                {
                    itemInInventory.amount += item.amount;
                    itemAldreadyInInv = true;
                }
            }
            if  (!itemAldreadyInInv)
            {
                items.Add(item);
            }
        } 
        else 
        { 
            items.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItemFromInventory(Item item)
    {
        if (item.isStackable())
        {
            int amt = 1;
            int counter = 0;
            foreach (Item itemInInventory in items)
            {
                if (itemInInventory.itemType == item.itemType && counter <= 0)
                {
                    amt = itemInInventory.amount;
                    itemInInventory.amount -= item.amount;
                    counter++;
                }
            }
            
            if (amt == 0)
            {
                items.Remove(item);
            }

        }
        else
        {
            items.Remove(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItems()
    {
        return items;
    }
}
