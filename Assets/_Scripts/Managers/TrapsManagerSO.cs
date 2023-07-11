using _Scripts.Traps;
using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace _Scripts.Managers
{
    [CreateAssetMenu(menuName = "Create TrapsManagerSO", fileName = "TrapsManagerSO", order = 0)]
    public class TrapsManagerSO : ScriptableObject
    {
        [SerializedDictionary("Trap type", "Base count")]
        public SerializedDictionary<TrapType, int> baseTrapsCounts;
        
        [SerializedDictionary("Trap type", "Max count")]
        public SerializedDictionary<TrapType, int> maxTrapsCounts;
    }
}