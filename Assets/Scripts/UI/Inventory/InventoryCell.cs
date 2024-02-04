using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class InventoryCell : MonoBehaviour , IPointerClickHandler,
    IBeginDragHandler, IEndDragHandler, IDropHandler, IDragHandler
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private TextMeshProUGUI _itemCountText;

    private bool _isEmpty = true;

    public event Action<InventoryCell> OnCellClicked, OnCellDroppedOn,
        OnCellBeginDrag, OnCellEndDrag, OnRightMouseBtnClick;

    void Awake()
    {
        ResetData();
    }

    public void SetData(Sprite sprite, int quantity)
    {
        _itemImage.gameObject.SetActive(true);
        _itemImage.sprite = sprite;
        _itemCountText.text = quantity.ToString();
        if (quantity == 1)
            _itemCountText.enabled = false;
        else
            _itemCountText.enabled = true;
        _isEmpty = false;
    }

    public void ResetData()
    {
        _itemImage.gameObject.SetActive(false);
        _isEmpty = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightMouseBtnClick?.Invoke(this);
        }
        else
            OnCellClicked?.Invoke(this);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_isEmpty == true)
            return;
        OnCellBeginDrag?.Invoke(this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnCellEndDrag?.Invoke(this);
    }

    public void OnDrop(PointerEventData eventData)
    {
        OnCellDroppedOn?.Invoke(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }
}
