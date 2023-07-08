using System;
using _Scripts.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SelectorButtonUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text trapName;
        [SerializeField] private Button button;
            
        private TrapType _trapType;
            
        public void SetTrapIndex(TrapType trapType, Action<TrapType> onTrapSelected)
        {
            _trapType = trapType;
            button.onClick.AddListener(() => { onTrapSelected?.Invoke(_trapType); });
        }
            
        public void SetTrapName(TrapType trapType)
        {
            trapName.text = trapType.ToString();
        }
    }
}