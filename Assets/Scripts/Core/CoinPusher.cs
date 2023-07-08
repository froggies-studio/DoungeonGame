using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CoinPusher : MonoBehaviour
{
    private const int MAX_COLLIDER_COUNT = 50;
    
    [SerializeField] private float force;
    [SerializeField] private float effectRadius;
    [SerializeField] private Transform target;
    
    private Collider2D[] _colliders = new Collider2D[MAX_COLLIDER_COUNT];
    
    public void Push(Vector3 position)
    {
        int count = Physics2D.OverlapCircleNonAlloc(position, effectRadius, _colliders);
        for (int i = 0; i < count; i++)
        {
            var coinObject = _colliders[i].gameObject;
            
            if(!coinObject.CompareTag("Coin"))
                continue;
            
            var direction = (coinObject.transform.position - target.position).normalized;
            coinObject.GetComponent<Rigidbody2D>().AddForce(direction * force, ForceMode2D.Impulse);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, effectRadius);
    }
}
