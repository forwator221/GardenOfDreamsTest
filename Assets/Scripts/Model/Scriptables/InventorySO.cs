using System;
using System.Collections;
using System.Collections.Generic;
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

    public void AddItem(ItemSO item, int quantity)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].isEmpty)
            {
                items[i] = new InventoryItem
                {
                    item = item,
                    quantity = quantity
                };
                return;
            }
        }
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
