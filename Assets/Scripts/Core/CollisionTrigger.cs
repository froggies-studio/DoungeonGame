using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    public class CollisionTrigger : MonoBehaviour
    {
        [SerializeField] private UnityEvent onTriggerEnter;
        [SerializeField] [CanBeNull] private GameObject target;
        [SerializeField] private bool isTriggeredOnce;
        
        private bool _isTriggered;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(target != null && other.gameObject != target) 
                return;
            
            if (isTriggeredOnce && _isTriggered)
                return;
                
            onTriggerEnter?.Invoke();
            _isTriggered = true;
        }
        
    }
}