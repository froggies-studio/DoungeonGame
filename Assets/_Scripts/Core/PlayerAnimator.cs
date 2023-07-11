#region

using System;
using _Scripts.Units;
using UnityEngine;

#endregion

namespace _Scripts.Core
{
    public class PlayerAnimator : MonoBehaviour
    {
        private const string DWARF_IDLE_STATE_NAME = "Dwarf";
        private const string WALK_HORIZONTAL_STATE_NAME = "WalkHorizontal";
        private const string WALK_VERTICAL_STATE_NAME = "WalkVertical";

        [SerializeField] private Player player;
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject spriteHandle;
        [SerializeField] private GameObject lightHandle;
        [SerializeField] private SpriteRenderer spriteRenderer;

        [SerializeField] private Sprite frontView;
        [SerializeField] private Sprite backView;

        private AnimationStates _currentAnimationState = AnimationStates.Idle;

        private Vector3 _previousPlayerPosition;
        private void Update()
        {
            var velocity = (player.transform.position - _previousPlayerPosition)/Time.deltaTime;
            var absVelocity = new Vector2(Math.Abs(velocity.x), Math.Abs(velocity.y));
            var maxVelocity = Mathf.Max(absVelocity.x, absVelocity.y);
            var animationState = AnimationStates.Idle;
            
            if (maxVelocity > 0.1f)
            {
                animationState = absVelocity.x > absVelocity.y ? AnimationStates.HorizontalMovement : AnimationStates.VerticalMovement;
                PerformAnimation(animationState, velocity);
            }
            
            if (_currentAnimationState != animationState)
            {
                SwitchAnimationState(animationState);
            }

            _previousPlayerPosition = player.transform.position;
        }

        private void PerformAnimation(AnimationStates animationState, Vector2 velocity)
        {
            switch (animationState)
            {
                case AnimationStates.HorizontalMovement:
                    spriteRenderer.sprite = frontView;
                    lightHandle.transform.localScale = new Vector3(1, 1, 1);
                    spriteHandle.transform.localScale = velocity.x switch
                    {
                        > 0 => new Vector3(1, 1, 1),
                        < 0 => new Vector3(-1, 1, 1),
                        _ => spriteHandle.transform.localScale
                    };
                    break;
                case AnimationStates.VerticalMovement:
                    lightHandle.transform.localScale = velocity.y switch
                    {
                        > 0 => new Vector3(-1, 1, 1),
                        < 0 => new Vector3(1, 1, 1),
                        _ => spriteHandle.transform.localScale
                    };
                    spriteRenderer.sprite = velocity.y switch
                    {
                        > 0 => backView,
                        < 0 => frontView,
                        _ => frontView
                    };
                    break;
            }
        }

        private void SwitchAnimationState(AnimationStates animationState)
        {
            _currentAnimationState = animationState;
            
            switch (_currentAnimationState)
            {
                case AnimationStates.Idle:
                    animator.CrossFade(DWARF_IDLE_STATE_NAME, 0, 0);
                    break;
                case AnimationStates.HorizontalMovement:
                    animator.CrossFade(WALK_HORIZONTAL_STATE_NAME, 0, 0);

                    break;
                case AnimationStates.VerticalMovement:
                    animator.CrossFade(WALK_VERTICAL_STATE_NAME, 0, 0);

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private enum AnimationStates
        {
            Idle = 0,
            HorizontalMovement = 1,
            VerticalMovement = 2,
        }
    }
}