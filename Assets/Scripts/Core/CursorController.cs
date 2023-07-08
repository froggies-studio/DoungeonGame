using System;
using UnityEngine;

namespace Core
{
    public class CursorController : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        [SerializeField] private CoinPusher coinPusher;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var cursorPosition = camera.ScreenToWorldPoint(Input.mousePosition);
                coinPusher.Push(cursorPosition);
            }
        }
    }
}