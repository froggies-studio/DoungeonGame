#region

using _Scripts.Core;
using _Scripts.Managers;
using UnityEngine;

#endregion

namespace _Scripts.Units.Coins
{
    public class CoinSpawner : MonoBehaviour
    {
        // [SerializeField] List<GameObject> coinPrefabs;
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
        // [SerializeField] private GameObject player;

        // public void Spawn()
        // {
        //     for (int i = 0; i < count; i++)
        //     {
        //         var randomIndex = Random.Range(0, coinPrefabs.Count);
        //         var randomCoin = coinPrefabs[randomIndex];
        //         var randomPosition = Random.insideUnitCircle * spawnRadius;
        //         var coin = Instantiate(randomCoin, transform.position + (Vector3) randomPosition, Quaternion.identity);
        //         // coin.GetComponent<AStartRigidBody>().SetTarget(player.transform);
        //     }
        // }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }
    }
}
