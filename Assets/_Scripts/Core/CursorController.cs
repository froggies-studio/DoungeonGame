#region

using _Scripts.UI;
using UnityEngine;

#endregion

namespace _Scripts.Core
{
    public class CursorController : MonoBehaviour
    {
        [SerializeField] private CoinPusher coinPusher;
        [SerializeField] private TrapSystem trapSystem;

        [SerializeField] private float clickRechargingTime;

        private Transform _currentTrapPreview;

        private float _lastClickTime;
        private Camera _mainCamera;
        private TrapType _trapType;

        private void Awake()
        {
            _mainCamera = Camera.main;

            _trapType = TrapType.None;

            _lastClickTime = float.MinValue;
        }

        private void Start()
        {
            TrapSingleUI.OnTrapPressed += TrapSingleUIOnTrapPressed;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Time.time - _lastClickTime < clickRechargingTime)
                {
                    return;
                }
                
                var cursorPosition = (Vector2)_mainCamera.ScreenToWorldPoint(Input.mousePosition);
                if (_trapType != TrapType.None)
                {
                    SpawnTrap(cursorPosition);
                }
                else
                {
                    coinPusher.Push(cursorPosition);
                }

                _lastClickTime = Time.time;
            }

            if (Input.GetMouseButtonDown(1))
            {
                ResetTrap();
            }

            if (_trapType != TrapType.None)
            {
                TrapPreviewFollowCursor();
            }
        }

        private void OnDestroy()
        {
            TrapSingleUI.OnTrapPressed -= TrapSingleUIOnTrapPressed;
        }

        private void TrapSingleUIOnTrapPressed(TrapType trapType)
        {
            if (_trapType != trapType && trapSystem.GetTrapCount(trapType) > 0)
            {
                TrapSelected(trapType);
            }
            else
            {
                ResetTrap();
            }
        }

        private void SpawnTrap(Vector2 cursorPosition)
        {
            if (!trapSystem.TryUseTrapAt(_trapType, cursorPosition))
            {
                ResetTrap();
            }

            if (trapSystem.GetTrapCount(_trapType) <= 0)
            {
                ResetTrap();
            }
        }

        private void TrapPreviewFollowCursor()
        {
            var cursorPosition = (Vector2)_mainCamera.ScreenToWorldPoint(Input.mousePosition);

            _currentTrapPreview.position = cursorPosition;
        }

        private void ResetTrap()
        {
            if (_trapType== TrapType.None)
            {
                return;
            }
            
            trapSystem.DisableTrapPreview(_trapType);
            _trapType = TrapType.None;
        }

        public void TrapSelected(TrapType trapType)
        {
            _trapType = trapType;
            trapSystem.EnableTrapPreview(_trapType);
            _currentTrapPreview = trapSystem.GetTrapPreview(_trapType);
        }
    }
}