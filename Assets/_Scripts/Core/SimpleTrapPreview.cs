using UnityEngine;

namespace _Scripts.Core
{
    public class SimpleTrapPreview : MonoBehaviour
    {
        [SerializeField] private GameObject canPlaceVisuals;
        [SerializeField] private GameObject canNotPlaceVisuals;

        private void Awake()
        {
            var trapValidator = GetComponent<ITrapPlacementValidator>();
            Debug.Assert(trapValidator != null, "SimpleTrapPreview requires ITrapPlacementValidator component!");
            trapValidator.OnPlacementStateChanged += ChangeState;
        }

        public void ChangeState(bool canPlace)
        {
            canPlaceVisuals.SetActive(canPlace);
            canNotPlaceVisuals.SetActive(!canPlace);
        }
    }
}