using System;
using _Scripts.Core;
using _Scripts.DamageReceivers;
using UnityEngine;

namespace _Scripts.UI
{
    public class Chest : MonoBehaviour
    {
        [SerializeField] private CoinDamageReceiver coinDamageReceiver;

        public static event Action<Vector3> OnChestCoinReceived;

        private void Start()
        {
            coinDamageReceiver.OnHealthChanged += CoinDamageReceiverOnHealthChanged;
        }

        private void CoinDamageReceiverOnHealthChanged(float obj)
        {
            OnChestCoinReceived?.Invoke(transform.position);
        }
    }
}