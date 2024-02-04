using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSO : ScriptableObject
{
    public int ID => GetInstanceID();

    [field: SerializeField] public string Name { get; set; }
    [field: SerializeField] public Sprite Image { get; set; }
    [field: SerializeField] public bool IsStackable { get; set; }
    [field: SerializeField] public int MaxStackSize { get; set; } = 1;    
    [field: SerializeField] public float Weight { get; set; }
    [field: SerializeField] public ActivityType ActivityType { get; set; }
}

public enum ActivityType
{
    Buy,
    Heal,
    Equip,
}
