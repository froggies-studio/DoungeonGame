using System;
using UnityEngine;

namespace _Scripts.UI
{
    public abstract class UI : MonoBehaviour
    {
        public static event Action OnUIPressed;
        protected void InvokeOnUIPressed()
        {
            OnUIPressed?.Invoke();
        }
    }
}