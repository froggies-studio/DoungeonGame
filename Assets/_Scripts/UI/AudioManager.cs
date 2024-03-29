﻿#region

using System;
using _Scripts.Core;
using UnityEngine;

#endregion

namespace _Scripts.UI
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioClip collectCoin;
        [SerializeField] private AudioClip chestCollectCoin;
        [SerializeField] private AudioClip deathSound;
        [SerializeField] private AudioClip winSound;
        [SerializeField] private AudioClip backgroundMusic;
        [SerializeField] private AudioClip doorOpened;
        [SerializeField] private AudioClip doorClosed;
        [SerializeField] private AudioClip buttonPressed;

        [SerializeField] private float globalVolume = 0.7f;
        public static AudioManager Instance { get; private set; }


        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            Player.Instance.CoinReceiver.OnDamageReceived += PlayerOnDamageReceived;
            GameMaster.Instance.OnStateChanged += GameMasterOnStateChanged;
            Chest.OnChestCoinReceived += ChestOnChestCoinReceived;
            Door.OnDoorOpened += DoorOnDoorOpened;
            Door.OnDoorClosed += DoorOnDoorClosed;
            UI.OnUIPressed += UIOnUIPressed;
        }

        private void UIOnUIPressed()
        {
            PlaySound(buttonPressed, Player.Instance.transform.position, 1.3f);
        }

        private void OnDestroy()
        {
            Player.Instance.CoinReceiver.OnDamageReceived -= PlayerOnDamageReceived;
            GameMaster.Instance.OnStateChanged -= GameMasterOnStateChanged;
            Chest.OnChestCoinReceived -= ChestOnChestCoinReceived;
            Door.OnDoorOpened -= DoorOnDoorOpened;  
            Door.OnDoorClosed -= DoorOnDoorClosed;
        }

        private void DoorOnDoorClosed(Vector3 obj)
        {
            PlaySound(doorOpened, obj);
        }

        private void DoorOnDoorOpened(Vector3 obj)
        {
            PlaySound(doorClosed, obj);
        }

        private void ChestOnChestCoinReceived(Vector3 obj)
        {
            PlaySound(chestCollectCoin, obj, 0.3f);
        }

        private void GameMasterOnStateChanged(GameMaster.State obj)
        {
            switch (obj)
            {
                case GameMaster.State.Start:
                    PlaySound(backgroundMusic, Player.Instance.transform.position);
                    break;
                case GameMaster.State.PlayerWin:
                    PlaySound(winSound, Player.Instance.transform.position);
                    break;
                case GameMaster.State.PlayerLoose:
                    PlaySound(deathSound, Player.Instance.transform.position);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(obj), obj, null);
            }
        }

        private void PlayerOnDamageReceived(float obj)
        {
            PlaySound(collectCoin, Player.Instance.transform.position);
        }

        private void PlaySound(AudioClip clip, Vector3 position, float volume = 1f)
        {
            AudioSource.PlayClipAtPoint(clip, position, volume * globalVolume);
        }
    }
}