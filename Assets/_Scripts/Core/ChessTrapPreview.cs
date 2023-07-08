using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Core
{
    public class ChessTrapPreview : MonoBehaviour
    {
        [SerializeField] private GameObject canPlaceVisuals;
        [SerializeField] private GameObject canNotPlaceVisuals;
        [SerializeField] private LayerMask excludeLayers;


        private bool _canPlace;

        private int _triggersEntered;

        private void Awake()
        {
            ChangeState(true);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (CheckIfLayerMaskContainsLayer(other)) return;

            _triggersEntered++;
            ChangeState(false);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (CheckIfLayerMaskContainsLayer(other)) return;

            _triggersEntered--;
            if (_triggersEntered <= 0)
            {
                ChangeState(true);
            }
        }

        private bool CheckIfLayerMaskContainsLayer(Collider2D other)
        {
            if (excludeLayers == (excludeLayers | (1 << other.gameObject.layer)))
            {
                return true;
            }

            return false;
        }

        private void ChangeState(bool canPlace)
        {
            canPlaceVisuals.SetActive(canPlace);
            canNotPlaceVisuals.SetActive(!canPlace);
        }
    }
}