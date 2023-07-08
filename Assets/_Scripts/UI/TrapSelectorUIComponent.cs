using _Scripts.Core;
using UI;
using UnityEngine;

namespace _Scripts.UI
{
    public class TrapSelectorUIComponent : MonoBehaviour
    {
        [SerializeField] private TrapSystem trapSystem;
        [SerializeField] private CursorController cursorController;
        [SerializeField] private SelectorButtonUI trapSelectorUI;
        [SerializeField] private TrapSingleUI trapUITemplate;
        private void Awake()
        {
            // trapSystem.OnTrapInfoChanged += OnTrapInfoChanged;
        }

        private void Start()
        {
            foreach (Transform child in transform)
            {
                if (child != trapUITemplate.transform)
                {
                    Destroy(child);
                }
            }
            
            foreach (var trapInfoSO in trapSystem.TrapInfos)
            {
                TrapSingleUI trapUI = Instantiate(trapUITemplate, transform);
                trapUI.SetTrapInfoSO(trapInfoSO, trapSystem.GetTrapCount(trapInfoSO.TrapType));
            }
            
            trapUITemplate.gameObject.SetActive(false);
        }

        private void OnTrapInfoChanged(TrapInfoSO[] obj)
        {
            // for (int i = 0; i < obj.Length; i++)
            // {
            //     var selectorObject = Instantiate(trapSelectorUI.gameObject, transform);
            //     var selectorButtonUI = selectorObject.GetComponent<SelectorButtonUI>();
            //     selectorButtonUI.SetTrapIndex((TrapType)(i+1), TrapSelected);
            //     selectorButtonUI.SetTrapName(obj[i].TrapType);
            // }
        }

        public void TrapSelected(TrapType trapType)
        {
            cursorController.TrapSelected(trapType);
        }
    }
}