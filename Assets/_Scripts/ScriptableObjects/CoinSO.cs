using System;
using _Scripts.Units;
using _Scripts.Units.Coins;
using UnityEngine;

namespace _Scripts.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Create CoinSO", fileName = "_CoinSO", order = 0)]
    public class CoinSO : ScriptableObject
    {
        [SerializeField] private Stats.Stats stats;
        public Stats.Stats BaseStats => stats;
        
        public Coin prefab;
    }
}