using System;
using UnityEngine;

namespace _Scripts.Core
{
    public class DwarfAnimator : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidbody2D;
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject spriteHandle;
        [SerializeField] private SpriteRenderer spriteRenderer;

        [SerializeField] private Sprite frontView;
        [SerializeField] private Sprite backView;
        
        private static readonly int State = Animator.StringToHash("AnimationState");

        private AnimationStates _currentAnimationState = AnimationStates.Idle;
        
        private enum AnimationStates
        {
            Idle = 0,
            HorizontalMovement = 1,
            VerticalMovement = 2,
        }

        private void Update()
        {
            var velocity = rigidbody2D.velocity;
            var absVelocity = new Vector2(Math.Abs(velocity.x), Math.Abs(velocity.y));
            var maxVelocity = Mathf.Max(absVelocity.x, absVelocity.y);
            var animationState = AnimationStates.Idle;
            if (maxVelocity > 0.1f)
            {
                animationState = absVelocity.x > absVelocity.y ? AnimationStates.HorizontalMovement : AnimationStates.VerticalMovement;

                switch (animationState)
                {
                    case AnimationStates.HorizontalMovement:
                        spriteRenderer.sprite = frontView;
                        spriteHandle.transform.localScale = velocity.x switch
                        {
                            > 0 => new Vector3(1, 1, 1),
                            < 0 => new Vector3(-1, 1, 1),
                            _ => spriteHandle.transform.localScale
                        };
                        break;
                    case AnimationStates.VerticalMovement:
                        spriteRenderer.sprite = velocity.y switch
                        {
                            > 0 => backView,
                            < 0 => frontView,
                            _ => frontView
                        };
                        break;
                }
            }
            
            if (_currentAnimationState != animationState)
            {
                _currentAnimationState = animationState;
                animator.SetInteger(State, (int) animationState);
            }
        }
    }
}