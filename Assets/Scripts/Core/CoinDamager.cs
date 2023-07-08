using UnityEngine;

namespace Core
{
    public class CoinDamager : MonoBehaviour
    {
        [SerializeField] private float damage;

        public float Damage => damage;
        
        public void DamageReceived()
        {
            Destroy(gameObject);
        }
    }
}