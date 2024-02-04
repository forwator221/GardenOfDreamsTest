using UnityEngine;

[CreateAssetMenu(menuName = "Create/CharacterConfig", fileName = "CharacterConfig", order = 0)]
public class CharacterConfig : ScriptableObject
{
    [field: SerializeField] public int HealthMax { get; private set; } = 100;

    [field: SerializeField] public int BaseArmor { get; private set; } = 0;

}