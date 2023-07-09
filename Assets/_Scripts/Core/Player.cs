using System;
using UnityEngine;

namespace _Scripts.Core
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private CoinReceiver coinReceiver;
        public static Player Instance { get; private set; }
        public event Action OnDead;
        
        public CoinReceiver CoinReceiver => coinReceiver;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            coinReceiver.OnDead += CoinReceiverOnDead;
        }

        private void CoinReceiverOnDead()
        {
            OnDead?.Invoke();
        }
    }
}