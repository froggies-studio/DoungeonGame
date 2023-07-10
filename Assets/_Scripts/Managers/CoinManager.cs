using _Scripts.Helpers;
using _Scripts.Systems;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;

namespace _Scripts.Managers
{
    public class CoinManager : Singleton<CoinManager>
    {
        public void SpawnCoin(Vector3 position)
        {
            var coinSO = ResourceSystem.Instance.GetCoinSO();

            var spawned = Instantiate(coinSO.prefab, position, Quaternion.identity, transform);
            
            spawned.SetStats(coinSO.BaseStats);
        }
    }
}