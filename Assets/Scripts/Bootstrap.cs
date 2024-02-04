using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Inventory _inventory;

    private void Awake()
    {
        _character.Initialize();
        _enemy.Initialize();
        _inventory.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
