using System;
using _Scripts.Core;
using _Scripts.Managers;
using UnityEngine;

namespace _Scripts.UI
{
    public class CoinSoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        
        private void Start()
        {
            GameManager.OnBeforeStateChanged += GameMasterOnBeforeStateChanged;
        }

        private void GameMasterOnBeforeStateChanged(GameState obj)
        {
            audioSource.enabled = obj == GameState.Starting;
        }

        private void OnDestroy()
        {
            GameManager.OnBeforeStateChanged -= GameMasterOnBeforeStateChanged;
        }
    }
}