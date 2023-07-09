using UnityEngine;

namespace _Scripts.Helpers
{
    public static class Extensions
    {
        public static bool ContainsLayer(this LayerMask layerMask, int layer)
        {
            return layerMask == (layerMask | (1 << layer));
        }
    }
}