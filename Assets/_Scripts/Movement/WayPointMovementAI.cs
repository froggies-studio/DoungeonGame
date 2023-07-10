using System;
using _Scripts.Stats;
using _Scripts.Units;
using JetBrains.Annotations;
using UnityEngine;

namespace _Scripts.Movement
{
    public class WayPointMovementAI : MovementAIAgent
    {
        private const float ACCURACY = .08f;

        [CanBeNull] private Transform _target;

        private Transform _transform;
        [SerializeField] private GameObject statsHolderGameObject;

        private IStatsHolder _statsHolder;

        private void Awake()
        {
            _transform = transform;
            _statsHolder = statsHolderGameObject.GetComponent<IStatsHolder>();
        }

        private void Start()
        {
            SetSpeed(_statsHolder.Stats.GetStat(StatType.Speed));
            Player.Instance.OnStatsChanged += PlayerOnStatsChanged;
        }

        private void PlayerOnStatsChanged()
        {
            SetSpeed(_statsHolder.Stats.GetStat(StatType.Speed));
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