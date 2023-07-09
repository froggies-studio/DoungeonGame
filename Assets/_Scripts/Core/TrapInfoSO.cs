using UnityEngine;

namespace _Scripts.Core
{
    [CreateAssetMenu()]
    public class TrapInfoSO : ScriptableObject
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
    }
}