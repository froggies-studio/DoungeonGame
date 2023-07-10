using _Scripts.Core;
using _Scripts.Units;
using UnityEngine;

namespace _Scripts.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Create TrapSO", fileName = "_TrapSO", order = 0)]
    public class TrapSO : ScriptableObject
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private TrapType trapType;
        [SerializeField] private GameObject trapPreview;
        [SerializeField] private Sprite icon;
        [SerializeField] private float reloadTime;
        [SerializeField] private float maxCapacity;
        
        public GameObject Prefab => prefab;
        public TrapType TrapType => trapType;
        public GameObject TrapPreview => trapPreview;
        public Sprite Icon => icon;
        public float ReloadTime => reloadTime;
        public float MaxCapacity => maxCapacity;
        
        
        // ------------------------

        public BaseTrap prefab1;
    }
}