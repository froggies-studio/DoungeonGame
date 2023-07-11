using System;

namespace _Scripts.DamageReceivers
{
    public interface IDamageReceiver
    {
        float MaxHealth { get; }
        float CurrentHealth { get; }
        event Action OnDead;
        event Action<float> OnHealthChanged;
        void ReceiveDamage(IDamageDealer damageDealer, float damageAmount);
    }
}