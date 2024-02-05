using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyHealth _health;

    public void Initialize()
    {
        _health.Initialize();
    }
}
