using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterHealth _health;
    [SerializeField] private CharacterHealthView _healthView;
    public void Initialize()
    {
        _health.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
