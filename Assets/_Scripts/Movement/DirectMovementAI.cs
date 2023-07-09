using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace Movement
{
    public class DirectMovementAI : MonoBehaviour, IMovementAI
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float speed = 5;
        [SerializeField] private float accuracy = .02f;

        public event Action OnTargetReached;
        
        [CanBeNull] private Transform _target;
        
        public void SetTarget(Transform point)
        {
            _target = point;
        }

        private void Update()
        {
            if (_target == null) return;
            
            var distance = _target.position - transform.position;
            rb.velocity = distance.normalized * speed;
            if (distance.sqrMagnitude < (accuracy * accuracy))
            {
                transform.position = _target.position;
                rb.velocity = Vector2.zero;
                _target = null;
                OnTargetReached?.Invoke();
            }
        }
    }
}