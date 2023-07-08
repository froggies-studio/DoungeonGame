using UnityEngine;

namespace _Scripts.Core
{
    public class ChessTrapPreview : MonoBehaviour
    {
        [SerializeField] private GameObject canPlaceVisuals;
        [SerializeField] private GameObject  canNotPlaceVisuals;

        private bool _canPlace;

        private int _triggersEntered;

        private void Awake()
        {
            ChangeState(true);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _triggersEntered++;
            ChangeState(false);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _triggersEntered--;
            if (_triggersEntered == 0)
            {
               ChangeState(true); 
            }
        }

        private void ChangeState(bool canPlace)
        {
            canPlaceVisuals.SetActive(canPlace);
            canNotPlaceVisuals.SetActive(!canPlace);
        }
    }
}