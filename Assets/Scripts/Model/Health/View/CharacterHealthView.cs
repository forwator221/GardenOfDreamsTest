using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterHealth))]
public class CharacterHealthView : MonoBehaviour, IHealthView
{
    [Header("Links")]
    [SerializeField] private CharacterHealth _character;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private TextMeshProUGUI _healthText;

    private int _maxHealth;

    public void Initialize()
    {
        _character = GetComponent<CharacterHealth>();
        _maxHealth = _character.Health.MaxValue;
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

    }
}