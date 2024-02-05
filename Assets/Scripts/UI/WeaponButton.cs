using UnityEngine;
using TMPro;

public class WeaponButton : MonoBehaviour
{
    [SerializeField] private Weapon _playerWeapon;
    [SerializeField] private WeaponSO _targetWeapon;
    [SerializeField] private TextMeshProUGUI _damageText;

    public void EquipWeapon()
    {
        _playerWeapon.SetWeapon(_targetWeapon);

    }

    private void Start()
    {
        SetButtonView();
    }

    private void SetButtonView()
    {
        int damage = 0;
        switch (_targetWeapon.WeaponType)
        {
            case WeaponType.Pistol:
                damage = _targetWeapon.Ammo.Damage;
                break;
            case WeaponType.Riffle:
                damage = _targetWeapon.Ammo.Damage * 3;
                break;
        }

        _damageText.text = damage.ToString();
    }

    
}
