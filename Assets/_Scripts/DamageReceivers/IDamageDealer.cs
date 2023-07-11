using System;

namespace _Scripts.DamageReceivers
{
    public interface IDamageDealer
    {
        float Damage { get; }
        event Action<float> OnDamageDealt;
        void DealDamage(IDamageReceiver damageReceiver);
    }
}