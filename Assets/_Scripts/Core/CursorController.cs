#region

using Core;
using UnityEngine;

#endregion

namespace _Scripts.Core
{
    public class CursorController : MonoBehaviour
    {
        [SerializeField] private CoinPusher coinPusher;
        [SerializeField] private TrapSystem trapSystem;

        private Camera _mainCamera;
        private TrapType _trapType;
        private Transform _currentTrapPreview;

        private void Awake()
        {
            _mainCamera = Camera.main;

            _trapType = TrapType.None;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var cursorPosition = (Vector2)_mainCamera.ScreenToWorldPoint(Input.mousePosition);
                if (_trapType != TrapType.None)
                {
                    trapSystem.SpawnTrap(cursorPosition, _trapType);
                }
                else
                {
                    coinPusher.Push(cursorPosition);
                }
            }

            if (Input.GetMouseButtonDown(1) && _trapType != TrapType.None)
            {
                ResetTrap();
            }

            if (_trapType != TrapType.None)
            {
                var cursorPosition = (Vector2)_mainCamera.ScreenToWorldPoint(Input.mousePosition);

                _currentTrapPreview.position = cursorPosition;
            }
        }

        private void ResetTrap()
        {
            trapSystem.DisableTrapPreview(_trapType);
            _trapType = TrapType.None;
            Cursor.visible = true;
        }

        public void TrapSelected(TrapType trapType)
        {
            _trapType = trapType;
            trapSystem.EnableTrapPreview(_trapType);
            _currentTrapPreview = trapSystem.GetTrapPreview(_trapType);
            Cursor.visible = false;
        }
    }
}