#region

using System.Collections.Generic;
using System.Linq;
using _Scripts.Core;
using _Scripts.Helpers;
using _Scripts.Managers;
using _Scripts.ScriptableObjects;
using _Scripts.Traps;
using UnityEngine;

#endregion

namespace _Scripts.Systems
{
    public class ResourceSystem : StaticInstance<ResourceSystem>
    {
        private const string TRAPS_RESOURCES_PATH = "Traps";
        private const string COIN_RESOURCES_PATH = "Coins";
        private const string MANAGERS_RESOURCES_PATH = "Managers";

        private Dictionary<TrapType, TrapSO> _trapsSODictionary;
        public List<TrapSO> TrapsSO { get; private set; }
        public CoinSO CoinSO { get; private set; }

        public TrapsManagerSO TrapsManagerSO { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            
            AssembleResources();
        }

        private void AssembleResources()
        {
            TrapsSO = Resources.LoadAll<TrapSO>(TRAPS_RESOURCES_PATH).ToList();
            _trapsSODictionary = TrapsSO.ToDictionary(t => t.TrapType, t => t);
            Debug.Assert(TrapsSO.Count != 0, $"{typeof(TrapSO)} not gathered");
            
            CoinSO = Resources.LoadAll<CoinSO>(COIN_RESOURCES_PATH).FirstOrDefault();
            Debug.Assert(CoinSO != null, $"{typeof(CoinSO)} == null");

            TrapsManagerSO = Resources.LoadAll<TrapsManagerSO>(MANAGERS_RESOURCES_PATH).FirstOrDefault();
            Debug.Assert(TrapsManagerSO != null, $"{typeof(TrapsManagerSO)} == null");
        }


        public TrapSO GetTrapSO(TrapType trapType)
        {
            return _trapsSODictionary[trapType];
        }

        public CoinSO GetCoinSO()
        {
            return CoinSO;
        }
    }
}