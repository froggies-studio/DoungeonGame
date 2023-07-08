using UnityEngine;

namespace _Scripts.Core
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private GameObject doorCollider;
        [SerializeField] private bool initialState;
        
        private bool _doorState;

        private void Start()
        {
            UpdateState(initialState);
        }

        private void OnMouseDown()
        {
            if (CursorController.Instance.ActiveTrapType == TrapType.Key)
            {
                UpdateState(true);
            }
        }

        private void UpdateState(bool openDoor)
        {
            if (_doorState == openDoor)
            {
                return;
            }

            if (openDoor)
            {
                OpenDoor();
            }
            else
            {
                CloseDoor();
            }

            _doorState = openDoor;
        }

        private void OpenDoor()
        {
            doorCollider.SetActive(true);
        }

        private void CloseDoor()
        {
            doorCollider.SetActive(false);
        }
    }
}