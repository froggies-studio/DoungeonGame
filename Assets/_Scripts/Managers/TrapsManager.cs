using _Scripts.Core;
using _Scripts.Helpers;
using _Scripts.Systems;
using UnityEngine;

namespace _Scripts.Managers
{
    public class TrapsManager : StaticInstance<TrapsManager>
    {
        public void SpawnTrap(TrapType type, Vector3 position)
        {
            var trapSO = ResourceSystem.Instance.GetTrapSO(type);

            var spawned = Instantiate(trapSO.prefab1, position, Quaternion.identity, transform);
        }
    }
}