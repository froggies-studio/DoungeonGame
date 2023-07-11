using _Scripts.Helpers;
using _Scripts.Managers;
using _Scripts.Systems;
using UnityEngine;

namespace _Scripts.UI
{
    public class TrapSelectorUI : MonoBehaviour
    {
        [SerializeField] private TrapSingleUI trapUITemplate;
        
        private void Start()
        {
            transform.DestroyChildren();
            
            foreach (var trapSO in ResourceSystem.Instance.TrapsSO)
            {
                TrapSingleUI trapUI = Instantiate(trapUITemplate, transform);
                trapUI.SetTrapSO(trapSO, TrapsManager.Instance.GetTrapCount(trapSO.TrapType));
            }
        }
    }
}