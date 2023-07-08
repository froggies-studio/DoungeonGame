using DG.Tweening;
using UnityEngine;

public class RotationInterpolation : MonoBehaviour
{
    [SerializeField] private Transform rotationHandle;
    [SerializeField] private Transform[] rotations;
    [SerializeField] private float rotationTime;
    [SerializeField] private Ease rotationEase;
    
    private int _currentRotationIndex = 0;
    
    private void Start()
    {
        rotationHandle.rotation = rotations[_currentRotationIndex].rotation;
    }
    
    public void SetRotation(int index)
    {
        _currentRotationIndex = index;
        rotationHandle.rotation = rotations[_currentRotationIndex].rotation;
    }

    public void AnimateRotation()
    {
        _currentRotationIndex++;
        if (_currentRotationIndex >= rotations.Length)
        {
            _currentRotationIndex = 0;
        }

        rotationHandle
            .DORotate(rotations[_currentRotationIndex].rotation.eulerAngles, rotationTime)
            .SetEase(rotationEase);
    }
}
