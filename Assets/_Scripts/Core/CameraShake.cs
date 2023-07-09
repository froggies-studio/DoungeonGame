using System;
using Cinemachine;
using UnityEngine;

namespace _Scripts.Core
{
    public class CameraShake : MonoBehaviour
    {
        public static CameraShake Instance { get; private set; }
        [SerializeField] private float shakeForce = 0.7f;
        [SerializeField] private CinemachineImpulseSource impulseSource;
        

        private void Awake()
        {
            Instance = this;
            
        }

        private void Start()
        {
            Player.Instance.CoinReceiver.OnDamageReceived += CoinReceiverOnDamageReceived;

        }

        private void CoinReceiverOnDamageReceived(float obj)
        {
            CameraShakeOnce();
        }

        private void CameraShakeOnce()
        {
            impulseSource.GenerateImpulseWithForce(shakeForce);
        }
    }
}