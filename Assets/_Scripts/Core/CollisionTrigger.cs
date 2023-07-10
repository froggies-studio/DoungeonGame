#region

using System;
using _Scripts.Helpers;
using UnityEngine;

#endregion

namespace _Scripts.Core
{
    public class CollisionTrigger : MonoBehaviour
    {
        [SerializeField] private bool oneTimeTrigger;
        [SerializeField] private LayerMask targetLayers;
        
        private bool _isTriggered;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!targetLayers.ContainsLayer(other.gameObject.layer))
            {
                return;
            }

            if (oneTimeTrigger && _isTriggered)
                return;

            _isTriggered = true;

            OnTriggerEnter?.Invoke();
        }

        public event Action OnTriggerEnter;
    }
}