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
        
        public GameObject Prefab => prefab;
        public TrapType TrapType => trapType;
        public GameObject TrapPreview => trapPreview;
        public Sprite Icon => icon;
    }
}