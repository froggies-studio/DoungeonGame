using _Scripts.Core;
using UI;
using UnityEngine;

namespace _Scripts.UI
{
    public class TrapSelectorUIComponent : MonoBehaviour
    {
        [SerializeField] private TrapSystem trapSystem;
        [SerializeField] private TrapSingleUI trapUITemplate;
        
        private void Start()
        {
            foreach (Transform child in transform)
            {
                if (child != trapUITemplate.transform)
                {
                    Destroy(child.gameObject);
                }
            }
            
            foreach (var trapInfoSO in trapSystem.TrapInfos)
            {
                TrapSingleUI trapUI = Instantiate(trapUITemplate, transform);
                trapUI.SetTrapInfoSO(trapInfoSO, trapSystem.GetTrapCount(trapInfoSO.TrapType));
            }
        }
    }
}