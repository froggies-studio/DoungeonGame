using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Scripts.Helpers
{
    public static class Helpers
    {
        private static PointerEventData _eventDataCurrentPosition;
        private static List<RaycastResult> _results;

        public static bool IsOverUI()
        {
            _eventDataCurrentPosition = new PointerEventData(EventSystem.current) { position = Input.mousePosition };
            _results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(_eventDataCurrentPosition, _results);
            return _results.Count > 0;
        }

        public static void DestroyChildren(this Transform transform)
        {
            foreach (Transform child in transform)
            {
                Object.Destroy(child.gameObject);
            }
        }

        public static void DestroyChildrenExcept(this Transform transform, GameObject exceptGameObject)
        {
            foreach (Transform child in transform)
            {
                var gameObject = child.gameObject;
                if (gameObject != exceptGameObject)
                {
                    Object.Destroy(gameObject);
                }
            }
        }
        
        private static readonly Dictionary<float, WaitForSeconds> WaitForSecondsDictionary = new Dictionary<float, WaitForSeconds>();
        public static WaitForSeconds GetCachedWaitForSeconds(float seconds)
        {
            if (WaitForSecondsDictionary.TryGetValue(seconds, out var waitForSeconds))
            {
                return waitForSeconds;
            }
            
            WaitForSecondsDictionary.Add(seconds, new WaitForSeconds(seconds));
            return WaitForSecondsDictionary[seconds];
        }
    }
}