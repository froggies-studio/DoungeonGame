using System;
using UnityEngine;

namespace _Scripts.Movement
{
    public interface IMovementAI
    {
        public event Action OnTargetReached;
        public void SetTarget(Transform point);
    }
}