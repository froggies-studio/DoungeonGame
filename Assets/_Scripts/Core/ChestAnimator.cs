#region

using _Scripts.DamageReceivers;
using UnityEngine;

#endregion

namespace _Scripts.Core
{
    [RequireComponent(typeof(Animator))]
    public class ChestAnimator : MonoBehaviour
    {
        private const string CHEST_DAMAGE_RECEIVED_STATE_NAME = "ChestDamageReceived";
        private static readonly int DamageReceived = Animator.StringToHash("DamageReceived");
        [SerializeField] private CoinDamageReceiver damageReceiver;

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            damageReceiver.OnHealthChanged += CoinDamageReceiverOnOnHealthChanged;
        }

        private void CoinDamageReceiverOnOnHealthChanged(float obj)
        {
            // _animator.SetTrigger(DamageReceived);
            _animator.CrossFade(CHEST_DAMAGE_RECEIVED_STATE_NAME,0,0);
        }
    }
}