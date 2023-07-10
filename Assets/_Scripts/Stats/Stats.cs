using System;
using AYellowpaper.SerializedCollections;

namespace _Scripts.Stats
{
    [Serializable]
    public struct Stats
    {
        [SerializedDictionary("Stat Type", "value")]
        public SerializedDictionary<StatType, float> statsDictionary;

        public float GetStat(StatType statType)
        {
            return statsDictionary[statType];
        }
    }
}