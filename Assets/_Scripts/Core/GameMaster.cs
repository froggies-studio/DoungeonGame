#region

using System;
using DefaultNamespace;
using UnityEngine;

#endregion

namespace _Scripts.Core
{
    public class GameMaster : MonoBehaviour
    {
        public enum State
        {
            None,
            Start,
            PlayerWin,
            PlayerLoose
        }

        [SerializeField] private WayPointSystem wayPointSystem;
        [SerializeField] private GameObject player;

        public State CurrentState { get; private set; }
        public static GameMaster Instance { get; private set; }

        private void Awake()
        {
            Instance = this;

            CurrentState = State.None;
        }

        private void Start()
        {
            wayPointSystem.SetAgent(player);
            wayPointSystem.OnLastPointReached += () => ChangeState(State.PlayerWin);

            ChangeState(State.Start);
        }

        public event Action<State> OnStateChanged;

        public void ChangeState(State newState)
        {
            if (CurrentState == newState)
            {
                return;
            }

            switch (newState)
            {
                case State.Start:
                    Time.timeScale = 0;
                    break;
                case State.PlayerWin:
                    Time.timeScale = 0;
                    break;
                case State.PlayerLoose:
                    Time.timeScale = 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
            }

            CurrentState = newState;
            OnStateChanged?.Invoke(newState);
        }
    }
}