using System;
using _Scripts.Stats;
using _Scripts.Units.Coins;
using UnityEngine;

namespace _Scripts.DamageReceivers
{
    public class CoinDamageDealer : MonoBehaviour, IDamageDealer
    {
        [SerializeField] private Coin coin;

        private void Start()
        {
            Damage = coin.Stats.GetStat(StatType.DamageAmount);
            
            coin.OnStatsChanged += CoinOnStatsChanged;
        }

        private void CoinOnStatsChanged()
        {
            Damage = coin.Stats.GetStat(StatType.DamageAmount);
        }

        public float Damage { get; private set; }
        public event Action<float> OnDamageDealt;
        public void DealDamage(IDamageReceiver damageReceiver)
        {
            damageReceiver.ReceiveDamage(this, Damage);
            OnDamageDealt?.Invoke(Damage);
        }
    }
}