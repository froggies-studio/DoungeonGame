using UnityEngine;

namespace _Scripts.Core
{
    public class DoorAnimator : MonoBehaviour
    {
        [SerializeField] RotationInterpolation rotationInterpolation;
        
        private bool _initialStateSet;
        
        public void Trigger(bool state)
        {
            if(!_initialStateSet)
            {
                rotationInterpolation.SetRotation(state ? 1 : 0);
                _initialStateSet = true;
            }
            else
                rotationInterpolation.AnimateRotation();
        }
    }
}