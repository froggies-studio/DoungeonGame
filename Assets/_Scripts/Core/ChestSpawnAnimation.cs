using DG.Tweening;
using UnityEngine;

namespace _Scripts.Core
{
    public class ChestSpawnAnimation : MonoBehaviour
    {
        [SerializeField] private GameObject spriteHandle;
        
        [SerializeField] private Vector3 fromScale;
        [SerializeField] private Vector3 toScale;
        [SerializeField] private float duration;
        [SerializeField] private Ease ease;
        
        private void Start()
        {
            spriteHandle.transform.localScale = fromScale;
            spriteHandle.transform.DOScale(toScale, duration).SetEase(ease);
        }
    }
}