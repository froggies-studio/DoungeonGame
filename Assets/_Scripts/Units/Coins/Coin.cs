using System;
using _Scripts.ScriptableObjects;
using _Scripts.Stats;
using UnityEngine;

namespace _Scripts.Units.Coins
{
    public class Coin : MonoBehaviour, IStatsHolder
    {
        public event Action OnStatsChanged;
        public Stats.Stats Stats { get; private set; }
        public void SetStats(Stats.Stats coinStats) => Stats = coinStats;
    }
}