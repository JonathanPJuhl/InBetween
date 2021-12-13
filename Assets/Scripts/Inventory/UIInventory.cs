using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    private void Awake()
    {
        itemSlotContainer = transform.Find("ItemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("Inventory_slot_template");
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        UpdateInventory();
    }

    private void Inventory_OnItemListChanged(object sender, EventArgs e)
    {
        UpdateInventory();
    }

    private void UpdateInventory()
    {
        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }
        
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 50f;
       
        foreach (Item item in inventory.GetItems())
        {
            RectTransform itemSlotRectTrans = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTrans.gameObject.SetActive(true);
            itemSlotRectTrans.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);

            Image image = itemSlotRectTrans.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();

            TextMeshProUGUI uiText = itemSlotRectTrans.Find("Amount").GetComponent<TextMeshProUGUI>();
            
            
            image.GetComponent<Button>().onClick.AddListener(() => OnActivate(item));

            if (item.amount > 1)
            {
                uiText.SetText(item.amount.ToString());
            } else
            {
                uiText.SetText("");
            }


            x++;
            if (x > 4)
            {
                x = 0;
                y++;
            }
        }
    }
    public void OnActivate(Item item)
    {
        item.GetEffectValue(item);
        inventory.RemoveItemFromInventory(item);
    }
}
