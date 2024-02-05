using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private InventoryCell _itemPrefab;
    [SerializeField] private RectTransform _inventoryPanel;
    [SerializeField] private RectTransform _itemDescriptionPanel;
    [SerializeField] private MouseFollower _mouseFollower;

    private List<InventoryCell> _listOfItems = new List<InventoryCell>();

    private int _currentDraggingItemIndex = -1;

    public event Action<int> OnDescriptionRequested,
        OnItemActionRequested,
        OnStartDragging;

    public event Action<int, int> OnSwapCells;

    public void Initialize(int size)
    {
        for (int i = 0; i < size; i++)
        {
            InventoryCell inventoryCell = Instantiate(_itemPrefab, Vector3.zero, Quaternion.identity);
            inventoryCell.transform.SetParent(_inventoryPanel);
            _listOfItems.Add(inventoryCell);
            inventoryCell.OnCellClicked += HandleItemSelection;
            inventoryCell.OnCellBeginDrag += HandleBeginDrag;
            inventoryCell.OnCellDroppedOn += HandleSwap;
            inventoryCell.OnCellEndDrag += HandleEndDrag;
            inventoryCell.OnRightMouseBtnClick += HandleShowItemActions;
        }

        _mouseFollower.Toggle(false);
    }

    public void UpdateData(int itemIndex, Sprite sprite, int itemQuantity) 
    {
        if (_listOfItems.Count > itemIndex)
        {
            _listOfItems[itemIndex].SetData(sprite, itemQuantity);
        }
    }

    public void CreateDraggedItem(Sprite sprite, int itemQuantity)
    {
        _mouseFollower.Toggle(true);
        _mouseFollower.SetData(sprite, itemQuantity);
    }

    private void HandleShowItemActions(InventoryCell inventoryCell)
    {
        
    }

    private void HandleEndDrag(InventoryCell inventoryCell)
    {
        ResetDraggedItem();
    }

    private void HandleSwap(InventoryCell inventoryCell)
    {
        int index = _listOfItems.IndexOf(inventoryCell);

        if (index == -1)
        {
            return;
        }

        OnSwapCells?.Invoke(_currentDraggingItemIndex, index);
    }

    private void ResetDraggedItem()
    {
        _mouseFollower.Toggle(false);
        _currentDraggingItemIndex = -1;
    }

    private void HandleBeginDrag(InventoryCell inventoryCell)
    {
        int index = _listOfItems.IndexOf(inventoryCell);

        if (index == -1)
            return;

        _currentDraggingItemIndex = index;
        OnStartDragging?.Invoke(index);
    }

    private void HandleItemSelection(InventoryCell inventoryCell)
    {
        int index = _listOfItems.IndexOf(inventoryCell);

        if (index == -1)
            return;

        OnDescriptionRequested?.Invoke(index);        
    }

    public void UpdateDescription(ItemSO item)
    {
        _itemDescriptionPanel.gameObject.SetActive(true);
        ItemDescription itemDescription = _itemDescriptionPanel.GetComponentInChildren<ItemDescription>();        
        itemDescription.SetDescription(item);
    }

    public void ResetAllItems()
    {
        foreach (var item in _listOfItems)
        {
            item.ResetData();
        }
    }
}
