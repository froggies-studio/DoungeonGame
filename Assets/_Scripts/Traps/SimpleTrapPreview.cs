using _Scripts.Traps.TrapPlacementValidators;
using UnityEngine;

namespace _Scripts.Traps
{
    public class SimpleTrapPreview : MonoBehaviour
    {
        [SerializeField] private GameObject canPlaceVisuals;
        [SerializeField] private GameObject canNotPlaceVisuals;
        [field: SerializeField] public TrapType TrapType { get; private set; }
        public bool IsPlacementValid { get; private set; } = true;

        private void Awake()
        {
            ChangeState(true);

            if (TryGetComponent(out ITrapPlacementValidator trapPlacementValidator))
            {
                trapPlacementValidator.OnPlacementStateChanged += ChangeState;
            }
        }

        private void ChangeState(bool canPlace)
        {
            canPlaceVisuals.SetActive(canPlace);
            canNotPlaceVisuals.SetActive(!canPlace);
            IsPlacementValid = canPlace;
        }
    }
}