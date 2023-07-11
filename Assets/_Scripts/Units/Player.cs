using System;
using _Scripts.DamageDealers;
using _Scripts.DamageReceivers;
using _Scripts.Stats;
using UnityEngine;

namespace _Scripts.Units
{
    public class Player : MonoBehaviour, IStatsHolder
    {
        [SerializeField] private CoinDamageReceiver coinDamageReceiver;
        [SerializeField] private Stats.Stats playerStats;

        public Stats.Stats Stats => playerStats;
        public static Player Instance { get; private set; }

        public event Action OnDead;
        public event Action OnStatsChanged;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            coinDamageReceiver.OnDead += CoinDamageReceiverOnDead;
        }

        private void CoinDamageReceiverOnDead()
        {
            OnDead?.Invoke();
        }

        private void Update()
        {
#if DEBUG
            if (Input.GetButtonDown("Fire1"))
            {
                // coinDamageReceiver.ReceiveDamage();
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                OnStatsChanged?.Invoke();
            }
#endif
        }
    }
}