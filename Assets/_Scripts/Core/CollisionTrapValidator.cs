using System;
using UnityEngine;

namespace _Scripts.Core
{
    public class CollisionTrapValidator : MonoBehaviour, ITrapPlacementValidator
    {
        [SerializeField] private LayerMask collisionLayers;
        [Tooltip("If false, placement is valid when there is no collision. If true, placement is valid when there is collision.")]
        [SerializeField]
        private bool reverse;

        public bool IsPlacementValid { get; private set; }
        public event Action<bool> OnPlacementStateChanged;

        private bool _canPlace;

        private int _triggersEntered;

        private void Start()
        {
            ChangeState(!reverse);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (CheckIfLayerMaskContainsLayer(other)) return;

            _triggersEntered++;
            ChangeState(reverse);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (CheckIfLayerMaskContainsLayer(other)) return;

            _triggersEntered--;
            if (_triggersEntered <= 0)
            {
                ChangeState(!reverse);
            }
        }

        private bool CheckIfLayerMaskContainsLayer(Collider2D other)
        {
            if (collisionLayers == (collisionLayers | (1 << other.gameObject.layer)))
            {
                return true;
            }

            return false;
        }

        private void ChangeState(bool canPlace)
        {
            IsPlacementValid = canPlace;
            OnPlacementStateChanged?.Invoke(canPlace);
        }
    }
}