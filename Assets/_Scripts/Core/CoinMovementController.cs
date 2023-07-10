using Movement;
using UnityEngine;

namespace _Scripts.Core
{
    public class CoinMovementController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidbody2D;
        // [SerializeField] private AStartRigidBody aStartRigidBody;
        
        public void Push(Vector2 direction, float force, float knockDownTime)
        {
            rigidbody2D.AddForce(direction * force, ForceMode2D.Impulse);
            // aStartRigidBody.enabled = false;
            Invoke(nameof(ResetPush), knockDownTime);
        }
        
        private void ResetPush()
        {
            // aStartRigidBody.enabled = true;
        }
    }
}