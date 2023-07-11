#region

using System;
using _Scripts.Helpers;
using UnityEngine;

#endregion

namespace _Scripts.Traps.TrapPlacementValidators
{
    public class CollisionTrapValidator : MonoBehaviour, ITrapPlacementValidator
    {
        [SerializeField] private LayerMask collisionLayers;

        private int _triggersEntered;
        public bool IsPlacementValid { get; private set; }

        private void Start()
        {
            ChangeState(true);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!collisionLayers.ContainsLayer(other.gameObject.layer)) return;

            _triggersEntered++;
            ChangeState(false);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!collisionLayers.ContainsLayer(other.gameObject.layer)) return;

            _triggersEntered--;
            if (_triggersEntered <= 0)
            {
                ChangeState(true);
            }
        }

        public event Action<bool> OnPlacementStateChanged;

        private void ChangeState(bool canPlace)
        {
            IsPlacementValid = canPlace;
            OnPlacementStateChanged?.Invoke(canPlace);
        }
    }
}