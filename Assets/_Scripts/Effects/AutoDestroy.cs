using UnityEngine;

namespace _Scripts.Effects
{
    public class AutoDestroy : MonoBehaviour
    {
        [SerializeField] private float delay;
        
        private void Start()
        {
            Destroy(gameObject, delay);
        }
    }
}