using System;
using _Scripts.Units;
using UnityEngine;

namespace _Scripts.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Create CoinSO", fileName = "_CoinSO", order = 0)]
    public class CoinSO : ScriptableObject
    {
        [SerializeField] private CoinStats stats;
        public CoinStats BaseStats => stats;
        
        public Coin prefab;
    }
    
    [Serializable]
    public struct CoinStats
    {
        public float speed;
        public float damage;
    }
}