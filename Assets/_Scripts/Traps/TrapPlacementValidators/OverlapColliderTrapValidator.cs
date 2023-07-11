using System;
using UnityEngine;

namespace _Scripts.Traps.TrapPlacementValidators
{
    public class OverlapColliderTrapValidator : MonoBehaviour, ITrapPlacementValidator
    {
        [SerializeField] private Collider2D overlapCollider;
        [SerializeField] private ContactFilter2D collisionMask;
        [Tooltip("If false, placement is valid when there is no collision. If true, placement is valid when there is collision.")]
        [SerializeField]
        private bool reverse;
        
        public bool IsPlacementValid { get; private set; }
        public event Action<bool> OnPlacementStateChanged;
        
        private Collider2D[] _collidersBuffer = new Collider2D[1];
        
        private void Start()
        {
            IsPlacementValid = !reverse;
            OnPlacementStateChanged?.Invoke(IsPlacementValid);
        }

        private void Update()
        {
            if (overlapCollider == null) 
                return;
            
            var count = Physics2D.OverlapCollider(overlapCollider, collisionMask, _collidersBuffer);
            if(count > 0)
            {
                ChangeState(reverse);
            }
            else
            {
                ChangeState(!reverse);
            }
        }

        private void ChangeState(bool canPlace)
        {
            if(canPlace == IsPlacementValid)
                return;
            
            IsPlacementValid = canPlace;
            OnPlacementStateChanged?.Invoke(canPlace);
        }
    }
}