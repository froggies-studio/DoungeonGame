using System;
using UnityEngine;

namespace _Scripts.Movement
{
    public abstract class MovementAIAgent : MonoBehaviour, IMovementAI
    {
        public event Action OnTargetReached;
        public abstract void SetTarget(Transform point);
        public float Speed { get; protected set; }

        public void SetSpeed(float speed)
        {
            Speed = speed;
        }

        protected void InvokeOnTargetReached()
        {
            OnTargetReached?.Invoke();
        }
    }
}