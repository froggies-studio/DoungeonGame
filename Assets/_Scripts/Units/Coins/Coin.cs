using System;
using _Scripts.ScriptableObjects;
using UnityEngine;

namespace _Scripts.Units
{
    public class Coin : MonoBehaviour
    {
        public CoinStats Stats { get; private set; }
        public void SetStats(CoinStats coinStats) => Stats = coinStats;
    }
}