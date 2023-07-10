using System;
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
            ResetCurrentHp();
        }

        private void ResetCurrentHp()
        {
            float maxHealth = playerStats.statsDictionary[StatType.MaxHp];
            if (!playerStats.statsDictionary.TryAdd(StatType.CurrentHp, maxHealth))
            {
                playerStats.statsDictionary[StatType.CurrentHp] = maxHealth;
            }
        }

        private void Start()
        {
            coinDamageReceiver.OnDamageReceived += CoinDamageReceiverOnDamageReceived;
        }

        private void CoinDamageReceiverOnDamageReceived(float damageAmount)
        {
            playerStats.statsDictionary[StatType.CurrentHp] -= damageAmount;

            if (playerStats.statsDictionary[StatType.CurrentHp] <= 0)
            {
                OnDead?.Invoke();
            }
        }

        private void Update()
        {
#if DEBUG
            if (Input.GetButtonDown("Fire1"))
            {
                coinDamageReceiver.ReceiveDamage(1f);
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                playerStats.statsDictionary[StatType.Speed] -= 1f;
                OnStatsChanged?.Invoke();
            }

            if (GUI.changed)
            {
                OnStatsChanged?.Invoke();
            }
#endif
        }
    }
}