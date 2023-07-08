using System;

namespace _Scripts.Core
{
    public interface ITrapPlacementValidator
    {
        bool IsPlacementValid { get; }
        
        event Action<bool> OnPlacementStateChanged; 
    }
}