using System;
using UnityEngine;

namespace Movement
{
    public interface IMovementAI
    {
        public event Action OnTargetReached;
        public void SetTarget(Transform point);
    }
}