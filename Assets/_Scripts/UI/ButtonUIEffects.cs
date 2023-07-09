using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Scripts.UI
{
    public class ButtonUIEffects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField] private RectTransform animationHandle;
        
        [Header("Hover over effects")]
        [SerializeField] private Vector3 expendScale;
        [SerializeField] private float expendTime;
        [SerializeField] private Ease expendEase;
        
        [Header("Click effects")]
        [SerializeField] private float clickYOffset;
        [SerializeField] private float clickReachOffsetTime;
        [SerializeField] private float clickReachNormalTime;
        [SerializeField] private Ease clickEase;
        
        private Vector3 _originalPosition;
        private Vector3 _originalScale;
        private Tween _tween;

        private void Start()
        {
            _originalPosition = transform.localPosition;
            _originalScale = transform.localScale;
        }

        public void Expend()
        {
            if(_tween != null && _tween.IsActive()) 
                _tween.Kill();
            
            _tween = animationHandle.DOScale(expendScale, expendTime).SetEase(expendEase);
        }
        
        public void Reset()
        {
            if(_tween != null && _tween.IsActive()) 
                _tween.Kill();
            _tween = animationHandle.DOScale(_originalScale, expendTime).SetEase(expendEase);
        }

        public void Click()
        {
            var sequence = DOTween.Sequence();
            sequence.Append(animationHandle.DOLocalMoveY(_originalPosition.y + clickYOffset, clickReachOffsetTime).SetEase(Ease.OutCubic));
            sequence.Append(animationHandle.DOLocalMoveY(0, clickReachNormalTime).SetEase(clickEase));
            _tween = sequence;
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            Expend();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Reset();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Click();
        }
    }
}