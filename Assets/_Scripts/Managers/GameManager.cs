#region

using System;
using _Scripts.Helpers;
using UnityEngine;

#endregion

namespace _Scripts.Managers
{
    public class GameManager : StaticInstance<GameManager>
    {
        public GameState CurrentGameState { get; private set; }

        private void Start()
        {
            ChangeState(GameState.Starting);
        }

        public static event Action<GameState> OnBeforeStateChanged;
        public static event Action<GameState> OnAfterStateChanged;

        public void ChangeState(GameState newState)
        {
            OnBeforeStateChanged?.Invoke(newState);

            CurrentGameState = newState;

            switch (newState)
            {
                case GameState.Starting:
                    HandleStarting();
                    break;
                case GameState.Playing:
                    HandlePlaying();
                    break;
                case GameState.PlayerWin:
                    HandlePlayerWin();
                    break;
                case GameState.PlayerLoose:
                    HandlePlayerLoose();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
            }

            OnAfterStateChanged?.Invoke(newState);

            Debug.Log($"New state: {newState}");
        }

        private void HandleStarting()
        {
            //Initial setup
        }

        private void HandlePlaying()
        {
            // throw new NotImplementedException();
        }

        private void HandlePlayerWin()
        {
        }

        private void HandlePlayerLoose()
        {
        }
    }

    [Serializable]
    public enum GameState
    {
        Starting = 0,
        Playing = 1,
        PlayerWin = 2,
        PlayerLoose = 3,
    }
}