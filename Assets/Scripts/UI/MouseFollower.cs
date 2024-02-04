using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Camera _mainCam;

    private InventoryCell _inventoryCell;

    private void Awake()
    {
        _mainCam = Camera.main;
        _inventoryCell = GetComponentInChildren<InventoryCell>();
    }

    public void SetData(Sprite sprite, int quantity)
    {
        _inventoryCell.SetData(sprite, quantity);
    }

    void Update()
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)_canvas.transform,
            Input.mousePosition,
            _canvas.worldCamera,
            out position);
        transform.position = _canvas.transform.TransformPoint(position);
    }

    public void Toggle(bool value)
    {
        gameObject.SetActive(value);
    }


}
