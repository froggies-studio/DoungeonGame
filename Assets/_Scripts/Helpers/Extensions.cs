using _Scripts.Core;
using UnityEngine;

namespace _Scripts.Helpers
{
    public static class Extensions
    {
        public static bool ContainsLayer(this LayerMask layerMask, int layer)
        {
            return layerMask == (layerMask | (1 << layer));
        }
        
        // public static bool ContainsLayer(this TriggerLayers layerMask, TriggerLayers layer)
        // {
        //     // return layerMask == (layerMask | (1 << layer));
        //     return (layerMask & layer) == layer;
        // }
    }
}