using System;
using System.Collections.Generic;
using Movement;
using UnityEngine;

namespace DefaultNamespace
{
    public class WayPointSystem : MonoBehaviour
    {
        [SerializeField] private List<Transform> points;
        [SerializeField] private LineRenderer lineRenderer;

        public event Action OnLastPointReached;
        
        private int _currentPointIndex;
        private IMovementAI _movementAI;

        private void Start()
        {
            lineRenderer.positionCount = points.Count;
            for (int i = 0; i < points.Count; i++)
            {
                lineRenderer.SetPosition(i, points[i].position);
            }
        }

        public void SetAgent(GameObject agent)
        {
            _movementAI = agent.GetComponent<IMovementAI>();
            
            if(_movementAI == null)
                return;

            _currentPointIndex = 0;
            _movementAI.OnTargetReached += OnTargetReached;
            _movementAI.SetTarget(points[_currentPointIndex]);
        }

        private void OnTargetReached()
        {
            _currentPointIndex++;
            if (_currentPointIndex >= points.Count)
            {
                OnLastPointReached?.Invoke();
                return;
            }
            
            _movementAI.SetTarget(points[_currentPointIndex]);
        }
    }
}