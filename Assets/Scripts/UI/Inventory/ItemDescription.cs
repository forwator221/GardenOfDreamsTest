using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class ItemDescription : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _weight;
    [SerializeField] private Button _activityButton;
    [SerializeField] private TextMeshProUGUI _activity;

    public UnityEvent OnHeal, OnBuy, OnEquip;

    public void SetDescription(ItemSO item)
    {
        _name.gameObject.SetActive(true);
        _image.sprite = item.Image;
        _name.text = item.Name;
        float totalWeight = item.Weight * item.MaxStackSize;
        _weight.text = totalWeight.ToString();
        SetDescriprionActivity(item.ActivityType);
    }

    public void ResetDescription()
    {
        Transform parent = transform.parent;
        parent.gameObject.SetActive(false);
        Destroy(gameObject);
    }

    private void SetDescriprionActivity(ActivityType activityType)
    {
        switch (activityType)
        {
            case ActivityType.Heal:
                _activity.text = "Лечить";
                _activityButton.onClick.AddListener(HealAction);
                break;
            case ActivityType.Buy:
                _activity.text = "Купить";
                _activityButton.onClick.AddListener(BuyAction);
                break;
            case ActivityType.Equip:
                _activity.text = "Надеть";
                _activityButton.onClick.AddListener(EquipAction);
                break;
        }
    }

    private void HealAction()
    {
        OnHeal?.Invoke();
    }

    private void BuyAction()
    {
        OnBuy?.Invoke();
    }

    private void EquipAction()
    {
        OnEquip?.Invoke();
    }


}
