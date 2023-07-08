#region

using UnityEngine;

#endregion

namespace _Scripts.Core
{
    public class CoinPusher : MonoBehaviour
    {
        private const int MAX_COLLIDER_COUNT = 50;
        private const string COIN_TAG = "Coin";

        [SerializeField] private float force;
        [SerializeField] private float effectRadius;
        [SerializeField] private Transform target;

        private Collider2D[] _colliders = new Collider2D[MAX_COLLIDER_COUNT];

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, effectRadius);
        }

        public void Push(Vector2 position)
        {
            int count = Physics2D.OverlapCircleNonAlloc(position, effectRadius, _colliders);
            for (int i = 0; i < count; i++)
            {
                var coinObject = _colliders[i].gameObject;
                
                if(!coinObject.CompareTag(COIN_TAG))
                    continue;
            
                var direction = (coinObject.transform.position - target.position).normalized;
                coinObject.GetComponent<Rigidbody2D>().AddForce(direction * force, ForceMode2D.Impulse);
            }
        }
    }
}
