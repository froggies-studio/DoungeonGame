using _Scripts.Core;
using _Scripts.DamageDealers;
using _Scripts.DamageReceivers;
using _Scripts.Units;
using Cinemachine;
using UnityEngine;

namespace _Scripts.Effects
{
    public class CameraShake : MonoBehaviour
    {
        public static CameraShake Instance { get; private set; }
        [SerializeField] private float shakeForce = 0.7f;
        [SerializeField] private CinemachineImpulseSource impulseSource;

        [SerializeField] private CoinDamageReceiver targetDamageReceiver;
        

        private void Awake()
        {
            Instance = this;
            
        }

        private void Start()
        {
            // Player.Instance.CoinReceiver.OnDamageReceived += CoinReceiverOnDamageReceived;
            targetDamageReceiver.OnHealthChanged += CoinReceiverOnHealthChanged;
        }

        private void CoinReceiverOnHealthChanged(float obj)
        {
            CameraShakeOnce();
        }

        private void CameraShakeOnce()
        {
            impulseSource.GenerateImpulseWithForce(shakeForce);
        }
    }
}