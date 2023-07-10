#region

using System;
using System.Collections.Generic;
using _Scripts.Helpers;
using _Scripts.Movement;
using UnityEngine;

#endregion

namespace _Scripts.Core
{
    public class WayPointSystem : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private LayerMask pointLayer;

        private int _currentPointIndex;
        private IMovementAI _movementAI;
        private List<Transform> _points;

        private void Awake()
        {
            LoadAllPoints();
        }

        private void Start()
        {
            lineRenderer.positionCount = _points.Count;
            for (int i = 0; i < _points.Count; i++)
            {
                lineRenderer.SetPosition(i, _points[i].position);
            }
        }

        public event Action OnLastPointReached;

        private void LoadAllPoints()
        {
            _points = new List<Transform>();
            foreach (Transform point in transform)
            {
                if (pointLayer.ContainsLayer(point.gameObject.layer))
                {
                    _points.Add(point);
                }
            }
        }

        public void SetAgent(GameObject agent)
        {
            _movementAI = agent.GetComponent<IMovementAI>();

            if (_movementAI == null)
                return;

            _currentPointIndex = 0;
            _movementAI.OnTargetReached += OnTargetReached;
            _movementAI.SetTarget(_points[_currentPointIndex]);
        }

        private void OnTargetReached()
        {
            _currentPointIndex++;
            if (_currentPointIndex >= _points.Count)
            {
                OnLastPointReached?.Invoke();
                return;
            }

            _movementAI.SetTarget(_points[_currentPointIndex]);
        }
    }
}