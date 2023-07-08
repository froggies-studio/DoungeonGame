using System;
using UnityEngine;

namespace Core
{
    public class CoinReceiver : MonoBehaviour
    {
        [SerializeField] private float maxHealth;

        public float MaxHealth => maxHealth;

        public float CurrentHealth => _currentHealth;

        public event Action<float> OnDamageReceived;
        public event Action OnDead;
        
        private bool _isDead;
        private float _currentHealth;
        
        private void Start()
        {
            _currentHealth = maxHealth;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if(_isDead)
                return;
            
            if (other.gameObject.TryGetComponent<CoinDamager>(out var damager))
            {
                ReciveDamage(damager);
            }
        }

        private void ReciveDamage(CoinDamager damager)
        {
            _currentHealth -= damager.Damage;

            if (_currentHealth <= 0)
            {
                if(!_isDead)
                {
                    OnDead?.Invoke();
                    _isDead = true;
                }

                _currentHealth = 0;
            }
            
            damager.DamageReceived();
            OnDamageReceived?.Invoke(_currentHealth);
        }
    }
}