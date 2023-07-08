using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SelectorButtonUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text trapName;
        [SerializeField] private Button button;
            
        private int _index;
            
        public void SetTrapIndex(int index, Action<int> onTrapSelected)
        {
            _index = index;
            button.onClick.AddListener(() => { onTrapSelected?.Invoke(_index); });
        }
            
        public void SetTrapName(string name)
        {
            trapName.text = name;
        }
            
            
    }
}