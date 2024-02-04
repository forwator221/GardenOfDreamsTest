using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create/Items/Weapons", fileName = "Weapon", order = 0)]
public class WeaponSO : ItemSO
{
    [field: SerializeField] public WeaponType WeaponType { get; set; }
    [field: SerializeField] public AmmoSO Ammo { get; set; }
    
}

public enum WeaponType
{
    Pistol,
    Riffle,
}
