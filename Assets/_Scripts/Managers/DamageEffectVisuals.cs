using System;
using _Scripts.DamageDealers;
using _Scripts.DamageReceivers;
using UnityEngine;

namespace _Scripts.Core
{
    public class DamageEffectVisuals : MonoBehaviour
    {
        [SerializeField] private CoinDamageReceiver[] damageReceivers;
        [SerializeField] private GameObject effectPrefab;
        private void Start()
        {
            foreach (var damageReceiver in damageReceivers)
            {
               damageReceiver.OnDamageReceived += DamageReceiverOnDamageReceived;
            }
        }

        private void DamageReceiverOnDamageReceived(IDamageDealer damageDealer, Vector3 position)
        {
            var effect = Instantiate(effectPrefab, position, Quaternion.identity, transform);
            effect.transform.right = ((CoinDamageDealer)damageDealer).transform.position - position;
        }
    }
}