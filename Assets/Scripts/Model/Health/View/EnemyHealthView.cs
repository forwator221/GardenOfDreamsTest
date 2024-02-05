using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(EnemyHealth))]
public class EnemyHealthView : MonoBehaviour, IHealthView
{
    [Header("Links")]
    [SerializeField] private EnemyHealth _enemy;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private TextMeshProUGUI _healthText;

    private int _maxHealth;

    public void Initialize()
    {
        _enemy = GetComponent<EnemyHealth>();
        _maxHealth = _enemy.Health.MaxValue;
        Show(_maxHealth);
    }

    public void Show(int health)
    {
        _healthSlider.value = (float)health / (float)_maxHealth;
        _healthText.text = health.ToString();

        if (health <= 0)
        {
            Die();
        }

    }

    private void Die()
    {
        _enemy.Die();
    }
}