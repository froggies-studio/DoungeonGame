using System;
using JetBrains.Annotations;
using UnityEngine;

namespace _Scripts.Movement
{
    public class DirectMovementAI : MovementAIAgent
    {
        private const float ACCURACY = .08f;

        [CanBeNull] private Transform _target;

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void Start()
        {
#if DEBUG

            Speed = 5f;

#endif
        }

        public override void SetTarget(Transform point)
        {
            _target = point;
        }

        private void Update()
        {
            if (_target == null) return;

            var position = _transform.position;
            var targetPosition = _target.position;

            _transform.position = Vector3.MoveTowards(position, targetPosition, Speed * Time.deltaTime);

            if (Vector3.Distance(position, targetPosition) < ACCURACY)
            {
                transform.position = targetPosition;
                _target = null;

                InvokeOnTargetReached();
            }
        }
    }
}