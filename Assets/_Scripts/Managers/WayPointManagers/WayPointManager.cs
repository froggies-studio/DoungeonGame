#region

using System;
using System.Collections.Generic;
using _Scripts.Helpers;
using _Scripts.Movement;
using UnityEngine;

#endregion

namespace _Scripts.Managers.WayPointManagers
{
    public class WayPointManager : StaticInstance<WayPointManager>
    {
        [SerializeField] private Transform pointsContainer; 
        [SerializeField] private MovementAIAgent movementAIAgent;

        private int _currentPointIndex;
        // private IMovementAI _movementAI;
        public List<Transform> Points { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            GatherAllPoints();
        }

        private void Start()
        {
            SetAgent();
        }

        public event Action OnLastPointReached;

        private void GatherAllPoints()
        {
            Points = new List<Transform>();
            foreach (Transform point in pointsContainer)
            {
               Points.Add(point);
            }
        }

        // public void SetAgent(GameObject agent)
        // {
        //     _movementAI = agent.GetComponent<IMovementAI>();
        //
        //     Debug.Assert(agent != null, "Incorrect agent");
        //
        //     _currentPointIndex = 0;
        //     _movementAI.OnTargetReached += OnTargetReached;
        //     _movementAI.SetTarget(Points[_currentPointIndex]);
        // }

        private void SetAgent()
        {
            _currentPointIndex = 0;
            movementAIAgent.OnTargetReached += OnTargetReached;
            movementAIAgent.SetTarget(Points[_currentPointIndex]);
        }

        private void OnTargetReached()
        {
            _currentPointIndex++;
            if (_currentPointIndex >= Points.Count)
            {
                OnLastPointReached?.Invoke();
                return;
            }

            movementAIAgent.SetTarget(Points[_currentPointIndex]);
        }
    }
}