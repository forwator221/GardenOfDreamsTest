using UnityEngine;

[CreateAssetMenu(menuName = "Create/EnemyConfig", fileName = "EnemyConfig", order = 1)]
public class EnemyConfig : ScriptableObject
{
    [field: SerializeField] public int HealthMax { get; private set; } = 100;

    [field: SerializeField] public int BaseArmor { get; private set; } = 0;

}