using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyHealth _health;

    // Start is called before the first frame update
    public void Initialize()
    {
        _health.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
