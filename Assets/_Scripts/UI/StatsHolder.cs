using System;
using _Scripts.Stats;
using UnityEngine;

namespace _Scripts.UI
{
    public class StatsHolder : MonoBehaviour, IStatsHolder
    {
        public event Action OnStatsChanged;
        [field: SerializeField] public Stats.Stats Stats { get; private set; }
    }
}