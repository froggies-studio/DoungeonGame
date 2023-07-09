using System;
using _Scripts.Core;
using UnityEngine;

namespace _Scripts.UI
{
    public class Chest : MonoBehaviour
    {
        [SerializeField] private CoinReceiver coinReceiver;

        public static event Action<Vector3> OnChestCoinReceived;

        private void Start()
        {
            coinReceiver.OnDamageReceived += CoinReceiverOnDamageReceived;
        }

        private void CoinReceiverOnDamageReceived(float obj)
        {
            OnChestCoinReceived?.Invoke(transform.position);
        }

        private void OnDestroy()
        {
            coinReceiver.OnDamageReceived -= CoinReceiverOnDamageReceived;
        }
    }
}