using System;

namespace _Scripts.Traps.TrapPlacementValidators
{
    public interface ITrapPlacementValidator
    {
        bool IsPlacementValid { get; }
        event Action<bool> OnPlacementStateChanged; 
    }
}