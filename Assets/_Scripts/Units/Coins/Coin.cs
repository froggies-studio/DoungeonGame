using _Scripts.ScriptableObjects;
using UnityEngine;

namespace _Scripts.Units.Coins
{
    public class Coin : MonoBehaviour
    {
        public Stats.Stats Stats { get; private set; }
        public void SetStats(Stats.Stats coinStats) => Stats = coinStats;
    }
}