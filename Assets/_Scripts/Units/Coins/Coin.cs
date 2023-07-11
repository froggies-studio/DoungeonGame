using System;
using _Scripts.DamageReceivers;
using _Scripts.Stats;
using UnityEngine;

namespace _Scripts.Units.Coins
{
    public class Coin : MonoBehaviour, IStatsHolder
    {
        [SerializeField] private CoinDamageDealer damageDealer;

        private void Start()
        {
            damageDealer.OnDamageDealt += DamageDealerOnDamageDealt;
        }

        private void DamageDealerOnDamageDealt(float obj)
        {
            Destroy(gameObject);
        }

        public event Action OnStatsChanged;
        public Stats.Stats Stats { get; private set; }
        public void SetStats(Stats.Stats coinStats) => Stats = coinStats;
    }
}