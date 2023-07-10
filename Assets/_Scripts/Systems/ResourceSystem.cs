#region

using System.Collections.Generic;
using System.Linq;
using _Scripts.Core;
using _Scripts.Helpers;
using _Scripts.ScriptableObjects;
using UnityEngine;

#endregion

namespace _Scripts.Systems
{
    public class ResourceSystem : StaticInstance<ResourceSystem>
    {
        private const string TRAPS_RESOURCES_PATH = "Traps";
        private const string COIN_RESOURCES_PATH = "Coins";

        private Dictionary<TrapType, TrapSO> _trapsSODictionary;
        public List<TrapSO> TrapsSO { get; private set; }
        public CoinSO CoinSO { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            
            AssembleResources();
        }

        private void AssembleResources()
        {
            TrapsSO = Resources.LoadAll<TrapSO>(TRAPS_RESOURCES_PATH).ToList();
            _trapsSODictionary = TrapsSO.ToDictionary(t => t.TrapType, t => t);
            Debug.Assert(TrapsSO.Count != 0, "TrapsSO not gathered");
            
            CoinSO = Resources.LoadAll<CoinSO>(COIN_RESOURCES_PATH).FirstOrDefault();
            Debug.Assert(CoinSO != null, "CoinSO == null");
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