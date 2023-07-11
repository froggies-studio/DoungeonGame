#region

using System;
using System.Collections;
using _Scripts.Traps;
using UnityEngine;

#endregion

namespace _Scripts.Managers
{
    public class TrapRecharger : MonoBehaviour
    {
        [SerializeField] private float rechargeRate = 1f;
        [SerializeField] private TrapType trapType;
        
        private bool _isRunning;

        private void Start()
        {
            TrapsManager.Instance.OnTrapCountChanged += TrapManagerOnTrapCountChanged;
            
            if (CheckCanRecharge())
            {
                StartCoroutine(RechargeCoroutine());
            }
        }

        private void TrapManagerOnTrapCountChanged(TrapType type)
        {
            if (trapType == type && CheckCanRecharge() && !_isRunning)
            {
                StartCoroutine(RechargeCoroutine());
            }
        }

        private bool CheckCanRecharge()
        {
            return TrapsManager.Instance.GetTrapCount(trapType) < TrapsManager.Instance.GetTrapMaxCount(trapType);
        }

        public static event Action<TrapType, float> OnRechargeChanged;

        private IEnumerator RechargeCoroutine()
        {
            _isRunning = true;
            float time = 0f;
            while (_isRunning)
            {
                time += Time.deltaTime;
                if (time >= rechargeRate)
                {
                    TrapsManager.Instance.TryIncreaseTrapCount(trapType, 1);
                    OnRechargeChanged?.Invoke(trapType, 1f);
                    time = 0f;
                    
                    _isRunning = CheckCanRecharge();
                }
                else
                {
                    OnRechargeChanged?.Invoke(trapType, time / rechargeRate);
                }

                yield return null;
            }
        }
    }
}