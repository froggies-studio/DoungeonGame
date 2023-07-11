using _Scripts.Core;
using UnityEngine;

namespace _Scripts.Traps
{
    public abstract class BaseTrap : MonoBehaviour
    {
        public abstract TrapType TrapType { get; }
    }
}