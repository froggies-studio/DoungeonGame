using System;
using UnityEngine;

namespace _Scripts.DamageReceivers
{
    public class CoinDamageReceiver : MonoBehaviour, IDamageReceiver
    {
        public event Action<float> OnDamageReceived;
        public void ReceiveDamage(float damageAmount)
        {
            // throw new NotImplementedException();
            OnDamageReceived?.Invoke(damageAmount);
        }
    }
}