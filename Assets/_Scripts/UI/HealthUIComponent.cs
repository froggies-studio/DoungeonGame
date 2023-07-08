using _Scripts.Core;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI
{
    public class HealthUIComponent : MonoBehaviour
    {
        [SerializeField] private Image healthBar;
        [SerializeField] private TMP_Text healthText;
        [SerializeField] private CoinReceiver player;

        private float _maxHealth;
        private float _currentHealth;
        private Tween _damageTween;
        
        private void Start()
        {
            player.OnDamageReceived += OnHealthChanged;
            _maxHealth = player.MaxHealth;
            _currentHealth = player.CurrentHealth;
        }

        private void OnHealthChanged(float obj)
        {
            if (_damageTween != null && _damageTween.IsActive())
            {
                _damageTween.Kill();
            }

            _currentHealth = obj;
            _damageTween = healthBar.DOFillAmount(_currentHealth / _maxHealth, 0.3f).SetEase(Ease.OutCirc);
            healthText.text = $"{_currentHealth}/{_maxHealth}";
        }
    }
}