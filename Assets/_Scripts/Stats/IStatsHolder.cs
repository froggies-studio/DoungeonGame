using System;

namespace _Scripts.Stats
{
    public interface IStatsHolder
    {
        event Action OnStatsChanged;
        Stats Stats { get; }
    }
}