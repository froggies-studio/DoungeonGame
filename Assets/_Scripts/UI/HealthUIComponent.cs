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
        [SerializeField] private Image healthBarDamageEffect;
        [SerializeField] private TMP_Text healthText;
        [SerializeField] private CoinReceiver player;

        private float _maxHealth;
        private float _currentHealth;
        private Tween _hbTween;
        private Tween _hbDamageEffectTween;
        
        private void Start()
        {
            player.OnDamageReceived += OnHealthChanged;
            _maxHealth = player.MaxHealth;
            _currentHealth = player.CurrentHealth;
        }

        private void OnHealthChanged(float obj)
        {
            if (_hbTween != null && _hbTween.IsActive())
            {
                _hbTween.Kill();
            }

            _currentHealth = obj;
            _hbTween = healthBar.DOFillAmount(_currentHealth / _maxHealth, 0.17f).SetEase(Ease.OutExpo);
            _hbDamageEffectTween = healthBarDamageEffect.DOFillAmount(_currentHealth / _maxHealth, 2f).SetEase(Ease.InExpo);
            healthText.text = $"{_currentHealth}/{_maxHealth}";
        }
    }
}