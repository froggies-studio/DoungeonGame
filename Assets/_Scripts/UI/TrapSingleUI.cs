using System;
using _Scripts.Core;
using _Scripts.Managers;
using _Scripts.ScriptableObjects;
using _Scripts.Traps;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Scripts.UI
{
    public class TrapSingleUI : UIBase
    {
        [SerializeField] private Image trapIcon;
        [SerializeField] private Image reloadIcon;
        [SerializeField] private TextMeshProUGUI counterText;
        [SerializeField] private Button button;

        public static event Action<TrapType> OnTrapPressed;

        private TrapType _trapType;

        private void Start()
        {
            button.onClick.AddListener(() =>
            {
                OnTrapPressed?.Invoke(_trapType);
                InvokeOnUIPressed();
            });

            TrapsManager.Instance.OnTrapCountChanged += TrapManagerOnTrapCountChanged;
            TrapRecharger.OnRechargeChanged += TrapRechargerOnRechargeChanged;
        }

        private void OnDestroy()
        {
            // TrapsManager.Instance.OnTrapCountChanged -= TrapManagerOnTrapCountChanged;
            TrapRecharger.OnRechargeChanged -= TrapRechargerOnRechargeChanged;
        }

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

        // private void TrapSystemOnTrapReloadChanged(TrapType trapType, float newCount)
        // {
        //     if (_trapType == trapType)
        //     {
        //         reloadIcon.fillAmount = newCount;
        //     }
        // }

        // private void TrapSystemOnTrapCountChanged(TrapType trapType, int newCount)
        // {
        //     if (_trapType == trapType)
        //     {
        //         counterText.text = newCount.ToString();
        //     }
        // }

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