using System;
using Core;
using UnityEngine;

namespace _Scripts.Core
{
    public class CoinReceiver : MonoBehaviour
    {
        [SerializeField] private float maxHealth;
        [SerializeField] private GameObject coinDamageEffectPrefab;

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
                ReceiveDamage(damager, other.contacts[0].point);
            }
        }

        private void ReceiveDamage(CoinDamager damager, Vector2 impactPoint)
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

            if(coinDamageEffectPrefab != null)
            {
                var effect = Instantiate(coinDamageEffectPrefab, impactPoint, Quaternion.identity);
                effect.transform.right = (Vector3) impactPoint - transform.position;
            }
            
            damager.DamageReceived();
            OnDamageReceived?.Invoke(_currentHealth);
        }
    }
}