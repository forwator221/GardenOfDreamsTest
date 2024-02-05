using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponSO _startWeapon;

    private WeaponSO _currentWeapon;
    private int _damage;
    private int _shootCount;

    public void Initialize()
    {
        SetWeapon(_startWeapon);
    }

    public void Shoot(EnemyHealth enemy)
    {
        enemy.TakeDamage(_damage);
    }

    public void SetWeapon(WeaponSO weapon)
    {
        _currentWeapon = weapon;

        switch (_currentWeapon.WeaponType)
        {
            case WeaponType.Pistol:
                _shootCount = 1;
                break;
            case WeaponType.Riffle:
                _shootCount = 3;
                break;
        }

        _damage = _currentWeapon.Ammo.Damage * _shootCount;
    }
}
