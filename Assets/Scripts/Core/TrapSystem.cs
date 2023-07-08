using System;
using UnityEngine;

namespace Core
{
    public class TrapSystem : MonoBehaviour
    {
        [SerializeField] private TrapInfoSO[] trapInfo;
        
        public event Action<TrapInfoSO[]> OnTrapInfoChanged;
        
        private void Start()
        {
            OnTrapInfoChanged?.Invoke(trapInfo);
        }
        
        public void SpawnTrap(Vector2 position, int trapIndex)
        {
            var trap = trapInfo[trapIndex];
            SpawnTrap(position, trap);
        }
        
        public void SpawnTrap(Vector2 position, TrapInfoSO trap)
        {
            Instantiate(trap.Prefab, position, Quaternion.identity);
        }
    }
}