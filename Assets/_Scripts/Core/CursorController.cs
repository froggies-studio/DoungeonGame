#region

using _Scripts.Traps;
using _Scripts.UI;
using UnityEngine;

#endregion

namespace _Scripts.Core
{
    public class CursorController : MonoBehaviour
    {
        // [SerializeField] private CoinPusher coinPusher;
        // [SerializeField] private TrapSystem trapSystem;
        //
        // [SerializeField] private float clickRechargingTime;
        //
        // private Transform _currentTrapPreview;
        //
        // private float _lastClickTime;
        // private Camera _mainCamera;
        // public TrapType ActiveTrapType { get; private set; }
        //
        // public static CursorController Instance { get; private set; }
        //
        // private void Awake()
        // {
        //     Instance = this;
        //     
        //     _mainCamera = Camera.main;
        //
        //     // ActiveTrapType = TrapType.None;
        //
        //     _lastClickTime = float.MinValue;
        // }
        //
        // private void Start()
        // {
        //     TrapSingleUI.OnTrapPressed += TrapSingleUIOnTrapPressed;
        // }
        //
        // private void Update()
        // {
        //     if (Input.GetMouseButtonDown(0))
        //     {
        //         if (Time.time - _lastClickTime < clickRechargingTime)
        //         {
        //             return;
        //         }
        //         
        //         var cursorPosition = (Vector2)_mainCamera.ScreenToWorldPoint(Input.mousePosition);
        //         if (ActiveTrapType != TrapType.None)
        //         {
        //             UseTrap(cursorPosition);
        //         }
        //         else
        //         {
        //             coinPusher.Push(cursorPosition);
        //         }
        //
        //         _lastClickTime = Time.time;
        //     }
        //
        //     if (Input.GetMouseButtonDown(1))
        //     {
        //         ResetTrap();
        //     }
        //
        //     if (ActiveTrapType != TrapType.None)
        //     {
        //         TrapPreviewFollowCursor();
        //     }
        // }
        //
        // private void OnDestroy()
        // {
        //     TrapSingleUI.OnTrapPressed -= TrapSingleUIOnTrapPressed;
        // }
        //
        // private void TrapSingleUIOnTrapPressed(TrapType trapType)
        // {
        //     if (ActiveTrapType != trapType && trapSystem.GetTrapCount(trapType) > 0)
        //     {
        //         TrapSelected(trapType);
        //     }
        //     else
        //     {
        //         ResetTrap();
        //     }
        // }
        //
        // private void UseTrap(Vector2 cursorPosition)
        // {
        //     if (!trapSystem.TryUseTrapAt(ActiveTrapType, cursorPosition))
        //     {
        //         // ResetTrap();
        //     }
        //
        //     if (trapSystem.GetTrapCount(ActiveTrapType) <= 0)
        //     {
        //         ResetTrap();
        //     }
        // }
        //
        // private void TrapPreviewFollowCursor()
        // {
        //     var cursorPosition = (Vector2)_mainCamera.ScreenToWorldPoint(Input.mousePosition);
        //
        //     _currentTrapPreview.position = cursorPosition;
        // }
        //
        // private void ResetTrap()
        // {
        //     if (ActiveTrapType== TrapType.None)
        //     {
        //         return;
        //     }
        //     
        //     trapSystem.DisableTrapPreview(ActiveTrapType);
        //     ActiveTrapType = TrapType.None;
        // }
        //
        // public void TrapSelected(TrapType trapType)
        // {
        //     ActiveTrapType = trapType;
        //     trapSystem.EnableTrapPreview(ActiveTrapType);
        //     _currentTrapPreview = trapSystem.GetTrapPreview(ActiveTrapType);
        // }
    }
}