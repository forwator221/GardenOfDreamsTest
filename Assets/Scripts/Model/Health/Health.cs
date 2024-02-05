using System;

public class Health : IHealth
{
    private readonly IHealthView _view;

    public Health(int value, int maxValue, IHealthView view)
    {
        _view = view ?? throw new ArgumentNullException(nameof(view));
        Value = value;
        MaxValue = maxValue;
    }

    public bool IsAlive => Value > 0;

    public int Value { get; private set; }

    public int MaxValue { get; }

    public void Heal(int healAmount)
    {
        if (Value + healAmount > MaxValue)
            Value = MaxValue;
        else
            Value += healAmount;
    }

    public void TakeDamage(int damage)
    {
        if (!IsAlive)
            throw new Exception($"Health is died! You can't attack it!");

        Value = Math.Max(0, Value - damage);
        _view.Show(Value);

    }
}
