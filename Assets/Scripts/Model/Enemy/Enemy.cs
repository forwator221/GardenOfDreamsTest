using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyHealth _health;

    public EnemyHealth Health { get;private set; }

    public void Initialize()
    {
        _health.Initialize();
    }
}
