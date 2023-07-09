#region

using UnityEngine;

#endregion

namespace _Scripts.Core
{
    [RequireComponent(typeof(Animator))]
    public class ChestAnimator : MonoBehaviour
    {
        private const string CHEST_DAMAGE_RECEIVED_STATE_NAME = "ChestDamageReceived";
        private static readonly int DamageReceived = Animator.StringToHash("DamageReceived");
        [SerializeField] private CoinReceiver coinReceiver;

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            coinReceiver.OnDamageReceived += CoinReceiverOnDamageReceived;
        }

        private void CoinReceiverOnDamageReceived(float obj)
        {
            _animator.SetTrigger(DamageReceived);
            _animator.CrossFade(CHEST_DAMAGE_RECEIVED_STATE_NAME,0,0);
        }
    }
}