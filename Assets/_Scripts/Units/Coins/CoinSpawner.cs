#region

using _Scripts.Core;
using _Scripts.Managers;
using UnityEngine;

#endregion

namespace _Scripts.Units.Coins
{
    public class CoinSpawner : MonoBehaviour
    {
        [SerializeField] private int spawnCount;
        [SerializeField] private float spawnRadius;
        [SerializeField] private CollisionTrigger collisionTrigger;

        private void Start()
        {
            collisionTrigger.OnTriggerEnter += CollisionTriggerOnTriggerEnter;
        }

        private void CollisionTriggerOnTriggerEnter()
        {
            for (int i = 0; i < spawnCount; i++)
            {
                CoinManager.Instance.SpawnCoinInRadius(transform.position, spawnRadius);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }
    }
}
