using System;
using DefaultNamespace;
using UnityEngine;

namespace Core
{
    public class GameMaster : MonoBehaviour
    {
        public static GameMaster Instance { get; private set; }
        
        [SerializeField] private WayPointSystem wayPointSystem;
        [SerializeField] private GameObject player;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            wayPointSystem.SetAgent(player);
        }
    }
}