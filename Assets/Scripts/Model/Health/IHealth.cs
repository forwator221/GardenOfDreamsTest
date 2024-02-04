public interface IHealth
{
    bool IsAlive { get; }

    int Value { get; }

    int MaxValue { get; }

    void TakeDamage(int damage);

}

