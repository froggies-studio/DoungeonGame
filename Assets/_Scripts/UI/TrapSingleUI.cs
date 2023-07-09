using System;
using _Scripts.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI
{
    public class TrapSingleUI : MonoBehaviour
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
            });
            
            TrapSystem.Instance.OnTrapCountChanged += TrapSystemOnTrapCountChanged;
            TrapSystem.Instance.OnTrapReloadChanged += TrapSystemOnTrapReloadChanged;
        }

        private void TrapSystemOnTrapReloadChanged(TrapType trapType, float newCount)
        {
            if (_trapType == trapType)
            {
                reloadIcon.fillAmount = newCount;
            }
        }

        private void TrapSystemOnTrapCountChanged(TrapType trapType, int newCount)
        {
            if (_trapType == trapType)
            {
                counterText.text = newCount.ToString();
            }
        }

        public void SetTrapInfoSO(TrapInfoSO trapInfoSO, int count)
        {
            trapIcon.sprite = trapInfoSO.Icon;
            counterText.text = count.ToString();
            _trapType = trapInfoSO.TrapType;
        }
    }
}