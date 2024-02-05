using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InventoryView _view;
    [SerializeField] private InventorySO _inventoryData;

    public List<InventoryItem> initialItems = new List<InventoryItem>();
    public List<InventoryItem> itemsBase = new List<InventoryItem>();
    
    public void Initialize()
    {
        PrepareUI();
        PrepareInventoryData();
    }

    public void AddRandomItem()
    {
        int randomItem = Random.Range(0, itemsBase.Count);
        InventoryItem item = itemsBase[randomItem];
        item.ChangeQuantity(Random.Range(1, item.item.MaxStackSize));
        int reminder = _inventoryData.AddItem(item.item, item.quantity);
        if (reminder == 0)
            return;
        else 
            item.quantity = reminder;
    }

    private void PrepareInventoryData()
    {
        _inventoryData.Initialize();
        _inventoryData.OnInventoryUpdated += UpdateInventoryView;
        foreach (InventoryItem item in initialItems)
        {
            if (item.isEmpty == true)
                continue;
            _inventoryData.AddItem(item);
        }
    }

    private void UpdateInventoryView(Dictionary<int, InventoryItem> inventoryState)
    {
        _view.ResetAllItems();
        foreach (var item in inventoryState)
        {
            _view.UpdateData(
                item.Key,
                item.Value.item.Image,
                item.Value.quantity);
        }
    }

    private void PrepareUI()
    {
        _view.Initialize(_inventoryData.Size);
        _view.OnDescriptionRequested += HandleDescriptionRequest;
        _view.OnSwapCells += HandleSwapRequest;
        _view.OnStartDragging += HandleStartDragging;
        _view.OnItemActionRequested += HandleItemActionReques;

    }

    private void HandleItemActionReques(int itemIndex)
    {
        
    }

    private void HandleStartDragging(int itemIndex)
    {
        InventoryItem inventoryItem = _inventoryData.GetItemAt(itemIndex);
        if (inventoryItem.isEmpty == true)
            return;
        _view.CreateDraggedItem(inventoryItem.item.Image, inventoryItem.quantity);
    }

    private void HandleSwapRequest(int itemIndex_1, int itemIndex_2)
    {
        _inventoryData.SwapItems(itemIndex_1, itemIndex_2);
    }

    private void HandleDescriptionRequest(int itemIndex)
    {
        InventoryItem inventoryItem = _inventoryData.GetItemAt(itemIndex);

        if (inventoryItem.isEmpty == true)
            return;

        ItemSO item = inventoryItem.item;

        float totalWeight = item.Weight * item.MaxStackSize;

        _view.UpdateDescription(itemIndex, item.Name, item.Image, totalWeight, item.ActivityType);
    }

    private void Update()
    {
        foreach (var item in _inventoryData.GetCurrentInventoryState())
        {
            _view.UpdateData(
                item.Key,
                item.Value.item.Image,
                item.Value.quantity);
        }
    }
}
