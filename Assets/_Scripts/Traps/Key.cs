using _Scripts.Core;
using UnityEngine;

namespace _Scripts.Traps
{
    public class Key : MonoBehaviour
    {
        [SerializeField] private Collider2D interactionCollider;
        [SerializeField] private ContactFilter2D collisionMask;
        
        private readonly Collider2D[] _collisionsBuffer = new Collider2D[5];
        private void Start()
        {
            var resultCollider = Physics2D.OverlapCollider(interactionCollider,collisionMask,_collisionsBuffer);
            
            if (resultCollider > 0)
            {
                var door = _collisionsBuffer[0].GetComponent<Door>();
                if (door != null)
                {
                    door.UpdateState(!door.DoorState);
                }
            }
            
            Destroy(gameObject);
        }
    }
}