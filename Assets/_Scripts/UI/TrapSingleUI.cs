#region

using System;
using _Scripts.Managers;
using _Scripts.ScriptableObjects;
using _Scripts.Traps;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

#endregion

namespace _Scripts.UI
{
    public class TrapSingleUI : UIBase
    {
        [SerializeField] private Image trapIcon;
        [SerializeField] private Image reloadIcon;
        [SerializeField] private TextMeshProUGUI counterText;
        [SerializeField] private Button button;

        private TrapType _trapType;

        private void Start()
        {
            button.onClick.AddListener(() =>
            {
                TrapsManager.Instance.ToggleTrap(_trapType);
                OnTrapPressed?.Invoke(_trapType);
                InvokeOnUIPressed();
            });

            TrapsManager.Instance.OnTrapCountChanged += TrapManagerOnTrapCountChanged;
            TrapRecharger.OnRechargeChanged += TrapRechargerOnRechargeChanged;
        }

        private void OnDestroy()
        {
            TrapRecharger.OnRechargeChanged -= TrapRechargerOnRechargeChanged;
        }

        public static event Action<TrapType> OnTrapPressed;

        private void TrapRechargerOnRechargeChanged(TrapType trapType, float fillAmount)
        {
            if (trapType == _trapType)
            {
                ChangeFillAmount(fillAmount);
            }
        }

        private void TrapManagerOnTrapCountChanged(TrapType trapType)
        {
            if (_trapType == trapType)
            {
                counterText.text = TrapsManager.Instance.GetTrapCount(trapType).ToString();
            }
        }

        public void SetTrapSO(TrapSO trapSO, int count)
        {
            trapIcon.sprite = trapSO.Icon;
            counterText.text = count.ToString();
            _trapType = trapSO.TrapType;
        }

        private void ChangeFillAmount(float fillAmount)
        {
            reloadIcon.fillAmount = fillAmount;
        }
    }
}