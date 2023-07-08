using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.Core
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private GameObject doorCollider;
        [SerializeField] private bool initialState;
        
        [SerializeField] private UnityEvent<bool> onDoorStateChanged;

        public bool DoorState => _doorState;

        private bool _doorState;

        private void Start()
        {
            UpdateStateInternal(initialState);
        }


        public void UpdateState(bool openDoor)
        {
            if(_doorState == openDoor)
                return;
            
            UpdateStateInternal(openDoor);
        }

        public void OpenDoor()
        {
            UpdateState(true);
        }

        public void CloseDoor()
        {
            UpdateState(false);
        }

        private void UpdateStateInternal(bool openDoor)
        {
            onDoorStateChanged?.Invoke(openDoor);
            doorCollider.SetActive(openDoor);
            _doorState = openDoor;
        }
    }
}