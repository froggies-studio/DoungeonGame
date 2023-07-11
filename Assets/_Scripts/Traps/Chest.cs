using System;
using _Scripts.DamageDealers;
using UnityEngine;

namespace _Scripts.Traps
{
    public class Chest : MonoBehaviour
    {
        [SerializeField] private CoinDamageReceiver coinDamageReceiver;

        public static event Action<Vector3> OnChestCoinReceived;

        private void Start()
        {
            coinDamageReceiver.OnHealthChanged += CoinDamageReceiverOnHealthChanged;
            coinDamageReceiver.OnDead += CoinDamageReceiverOnDead;
        }

        private void CoinDamageReceiverOnDead()
        {
            coinDamageReceiver.OnHealthChanged -= CoinDamageReceiverOnHealthChanged;
            coinDamageReceiver.enabled = false;
        }

        private void CoinDamageReceiverOnHealthChanged(float obj)
        {
            OnChestCoinReceived?.Invoke(transform.position);
        }
    }
}