using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class InventorySO : ScriptableObject
{
    [SerializeField] private List<InventoryItem> items;

    [field: SerializeField] public int Size { get; private set; } = 30;

    public event Action<Dictionary<int, InventoryItem>> OnInventoryUpdated;

    public void Initialize()
    {
        items = new List<InventoryItem>();
        for (int i = 0; i < Size; i++)
        {
            items.Add(InventoryItem.GetEmpyItem());
        }
    }

    public int AddItem(ItemSO item, int quantity)
    {
        if (item.IsStackable == false)
        {
            for (int i = 0; i < items.Count; i++)
            {
                while (quantity > 0 && IsInventoryFull() == false)
                {
                    quantity -= AddItemToFirstFreeSlot(item, 1);
                }

                InformAboutChange();
                return quantity;
            }
        }

        quantity = AddStacableIteb(item, quantity);
        InformAboutChange();
        return quantity;
    }

    private int AddItemToFirstFreeSlot(ItemSO item, int quantity)
    {
        InventoryItem newItem = new InventoryItem
        {
            item = item,
            quantity = quantity
        };

        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].isEmpty)
            {
                items[i] = newItem;
                return quantity;
            }
        }

        return 0;
    }

    private bool IsInventoryFull() 
        => items.Where(item => item.isEmpty).Any() == false; 

    private int AddStacableIteb(ItemSO item, int quantity)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].isEmpty)
                continue;

            if (items[i].item.ID == item.ID)
            {
                int amountPossibleToTake =
                    items[i].item.MaxStackSize - items[i].quantity;

                if (quantity > amountPossibleToTake)
                {
                    items[i] = items[i].ChangeQuantity(items[i].item.MaxStackSize);
                    quantity -= amountPossibleToTake;
                }
                else
                {
                    items[i] = items[i].ChangeQuantity(items[i].quantity + quantity);
                    InformAboutChange();
                    return 0;
                }
            }
        }

        while (quantity > 0 && IsInventoryFull() == false)
        {
            int newQuantity = Mathf.Clamp(quantity, 0, item.MaxStackSize);
            quantity -= newQuantity;
            AddItemToFirstFreeSlot(item, newQuantity);
        }

        return quantity;
    }

    public void AddItem(InventoryItem item)
    {
        AddItem(item.item, item.quantity);
    }

    public Dictionary<int, InventoryItem> GetCurrentInventoryState() 
    {
        Dictionary<int, InventoryItem> returnValue = new Dictionary<int, InventoryItem>();
        for (int i = 0; i <  items.Count; i++)
        {
            if (items[i].isEmpty)
                continue;
            returnValue[i] = items[i];
        }
        return returnValue;
    }

    public InventoryItem GetItemAt(int itemIndex)
    {
        return items[itemIndex];
    }

    public void SwapItems(int itemIndex_1, int itemIndex_2)
    {
        InventoryItem item1 = items[itemIndex_1];
        items[itemIndex_1] = items[itemIndex_2];
        items[itemIndex_2] = item1;
        InformAboutChange();
    }

    private void InformAboutChange()
    {
        OnInventoryUpdated?.Invoke(GetCurrentInventoryState());
    }
}

[Serializable]
public struct InventoryItem
{
    public int quantity;
    public ItemSO item;
    public bool isEmpty => item == null;

    public InventoryItem ChangeQuantity(int newQuantity)
    {
        return new InventoryItem
        {
            item = this.item,
            quantity = newQuantity,
        };
    }
    public static InventoryItem GetEmpyItem()
        => new InventoryItem
        {
            item = null,
            quantity = 0,
        };
}
