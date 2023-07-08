using _Scripts.Core;
using Core;
using UnityEngine;

namespace UI
{
    public class TrapSelectorUIComponent : MonoBehaviour
    {
        [SerializeField] private TrapSystem trapSystem;
        [SerializeField] private CursorController cursorController;
        [SerializeField] private SelectorButtonUI trapSelectorUI;

        private void Awake()
        {
            trapSystem.OnTrapInfoChanged += OnTrapInfoChanged;
        }

        private void OnTrapInfoChanged(TrapInfoSO[] obj)
        {
            for (int i = 0; i < obj.Length; i++)
            {
                var selectorObject = Instantiate(trapSelectorUI.gameObject, transform);
                var selectorButtonUI = selectorObject.GetComponent<SelectorButtonUI>();
                selectorButtonUI.SetTrapIndex((TrapType)(i+1), TrapSelected);
                selectorButtonUI.SetTrapName(obj[i].TrapType);
            }
        }

        public void TrapSelected(TrapType trapType)
        {
            cursorController.TrapSelected(trapType);
        }
    }
}