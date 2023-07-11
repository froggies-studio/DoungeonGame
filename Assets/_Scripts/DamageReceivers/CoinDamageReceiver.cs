#region

using System;
using _Scripts.Stats;
using UnityEngine;

#endregion

namespace _Scripts.DamageReceivers
{
    public class CoinDamageReceiver : MonoBehaviour, IDamageReceiver
    {
        [SerializeField] private GameObject statsHolderGameObject;
        private IStatsHolder _statsHolder;

        public float MaxHealth { get; private set; }
        public float CurrentHealth { get; private set; }

        private void Awake()
        {
            _statsHolder = statsHolderGameObject.GetComponent<IStatsHolder>();
            MaxHealth = _statsHolder.Stats.GetStat(StatType.MaxHp);
            CurrentHealth = MaxHealth;
        }

        private void Start()
        {
            
            _statsHolder.OnStatsChanged += StatsHolderOnStatsChanged;
            
        }

        private void StatsHolderOnStatsChanged()
        {
            MaxHealth = _statsHolder.Stats.GetStat(StatType.MaxHp);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<IDamageDealer>(out var damageDealer))
            {
                damageDealer.DealDamage(this);
            }
        }

        public event Action<float> OnHealthChanged;
        public event Action OnDead;

        public void ReceiveDamage(IDamageDealer damageDealer, float damageAmount)
        {
            CurrentHealth -= damageAmount;
            OnHealthChanged?.Invoke(CurrentHealth);

            if (CurrentHealth <= 0f)
            {
                CurrentHealth = 0f;
                OnDead?.Invoke();
            }
        }
    }
}