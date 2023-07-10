using System;
using UnityEngine;

namespace _Scripts.Helpers
{
    /// <summary>
    /// Each awake resets Instance value
    /// </summary>
    /// <typeparam name="TSelf"></typeparam>
    public abstract class StaticInstance<TSelf> : MonoBehaviour where TSelf : MonoBehaviour
    {
        public static TSelf Instance { get; private set; }

        protected virtual void Awake()
        {
            Instance = this as TSelf;
        }

        protected void OnApplicationQuit()
        {
            Instance = null;
            Destroy(gameObject);
        }
    }

    public abstract class Singleton<TSelf> : StaticInstance<TSelf> where TSelf : MonoBehaviour
    {
        protected override void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            
            base.Awake();
        }
    }

    public abstract class PersistentSingleton<TSelf> : Singleton<TSelf> where TSelf : MonoBehaviour
    {
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }
    }
}