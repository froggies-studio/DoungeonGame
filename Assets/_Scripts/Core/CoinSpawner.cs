using System.Collections.Generic;
using Movement;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> coinPrefabs;
    [SerializeField] private int count;
    [SerializeField] private float spawnRadius;
    [SerializeField] private GameObject player;

    public void Spawn()
    {
        for (int i = 0; i < count; i++)
        {
            var randomIndex = Random.Range(0, coinPrefabs.Count);
            var randomCoin = coinPrefabs[randomIndex];
            var randomPosition = Random.insideUnitCircle * spawnRadius;
            var coin = Instantiate(randomCoin, transform.position + (Vector3) randomPosition, Quaternion.identity);
            coin.GetComponent<AStartRigidBody>().SetTarget(player.transform);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
