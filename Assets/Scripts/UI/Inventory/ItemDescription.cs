using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ItemDescription : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _weight;
    [SerializeField] private TextMeshProUGUI _quantity;

    public void SetDescription(Sprite sprite, string itemName, float itemWeight)
    {
        _name.gameObject.SetActive(true);
        _image.sprite = sprite;
        _name.text = itemName;
        _weight.text = itemWeight.ToString();
    }

    public void ResetDescription()
    {
        Transform parent = transform.parent;
        parent.gameObject.SetActive(false);
        Destroy(gameObject);

    }
}
