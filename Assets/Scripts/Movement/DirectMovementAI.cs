using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Movement
{
    public class DirectMovementAI : MonoBehaviour, IMovementAI
    {
        [SerializeField] private float speed;

        public event Action OnTargetReached;
        
        [CanBeNull] private Transform _target;
        
        public void SetTarget(Transform point)
        {
            _target = point;
        }

        private void Update()
        {
            if (_target == null) return;
            
            transform.position = Vector3.MoveTowards(transform.position, _target.position, speed * Time.deltaTime);
            var distance = _target.position - transform.position;
            if (distance.sqrMagnitude < .0001f)
            {
                transform.position = _target.position;
                _target = null;
                OnTargetReached?.Invoke();
            }
        }
    }
}