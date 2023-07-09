using System;
using _Scripts.Core;
using UnityEngine;

namespace _Scripts.UI
{
    public class CoinSoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        
        private void Start()
        {
            GameMaster.Instance.OnStateChanged += GameMasterOnStateChanged;
        }

        private void GameMasterOnStateChanged(GameMaster.State obj)
        {
            audioSource.enabled = obj == GameMaster.State.Start;
        }

        private void OnDestroy()
        {
            GameMaster.Instance.OnStateChanged -= GameMasterOnStateChanged;
        }
    }
}