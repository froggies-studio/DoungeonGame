using System;
using UnityEngine;

namespace Core
{
    public class CursorController : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        [SerializeField] private CoinPusher coinPusher;
        [SerializeField] private TrapSystem trapSystem;

        private int _trapIndex = -1;
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var cursorPosition = (Vector2) camera.ScreenToWorldPoint(Input.mousePosition);
                if(_trapIndex != -1)
                {
                    trapSystem.SpawnTrap(cursorPosition, _trapIndex);
                    _trapIndex = -1;
                }
                else
                {
                    coinPusher.Push(cursorPosition);
                }
            }
        }

        public void TrapSelected(int index)
        {
            _trapIndex = index;
        }
    }
}