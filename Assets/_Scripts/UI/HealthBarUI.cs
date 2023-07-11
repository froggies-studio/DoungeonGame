using _Scripts.DamageDealers;
using _Scripts.DamageReceivers;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI
{
    public class HealthBarUI : MonoBehaviour
    {
        [SerializeField] private Image healthBar;
        [SerializeField] private Image healthBarDamageEffect;
        [SerializeField] private TMP_Text healthText;
        [SerializeField] private CoinDamageReceiver player;

        private float _maxHealth;
        private float _currentHealth;
        private Tween _hbTween;
        private Tween _hbDamageEffectTween;

        private void Start()
        {
            player.OnHealthChanged += OnHealthChanged;

            _maxHealth = player.MaxHealth;
            _currentHealth = player.CurrentHealth;
            UpdateHealthBarText();
        }

        private void OnHealthChanged(float newHealth)
        {
            if (_hbTween != null && _hbTween.IsActive())
            {
                _hbTween.Kill();
            }

            _currentHealth = newHealth;
            _hbTween = healthBar.DOFillAmount(_currentHealth / _maxHealth, 0.17f).SetEase(Ease.OutExpo);
            _hbDamageEffectTween =
                healthBarDamageEffect.DOFillAmount(_currentHealth / _maxHealth, 2f).SetEase(Ease.InExpo);
            UpdateHealthBarText();
        }

        private void UpdateHealthBarText()
        {
            healthText.text = $"{_currentHealth}/{_maxHealth}";
        }
    }
}