using UnityEngine;
using UnityEngine.Serialization;

namespace Core
{
    [CreateAssetMenu()]
    public class TrapInfoSO : ScriptableObject
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private string trapName;
        
        public GameObject Prefab => prefab;
        public string TrapName => trapName;
    }
}