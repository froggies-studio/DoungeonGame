using System;

namespace _Scripts.DamageReceivers
{
    public interface IDamageReceiver
    {
        event Action<float> OnDamageReceived;
        void ReceiveDamage(float damageAmount);
    }
}