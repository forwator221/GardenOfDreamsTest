using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create/Items/Ammo", fileName = "Ammo", order = 0)]
public class AmmoSO : ItemSO
{
    [field: SerializeField] public AmmoType AmmoType { get; set; }
    [field: SerializeField] public int Damage { get; set; }
}

public enum AmmoType
{
    PistolAmmo,
    RiffleAmmo,
}
