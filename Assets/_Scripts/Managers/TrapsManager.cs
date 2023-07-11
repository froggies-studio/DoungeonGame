using System;
using System.Collections.Generic;
using System.Linq;
using _Scripts.Helpers;
using _Scripts.Systems;
using _Scripts.Traps;
using UnityEngine;

namespace _Scripts.Managers
{
    public class TrapsManager : StaticInstance<TrapsManager>
    {
        public bool IsTrapSelected { get; private set; }
        public TrapType ActiveTrap { get; private set; }

        private Dictionary<TrapType, int> _trapsCounts;

        public event Action<TrapType> OnTrapCountChanged;
        public event Action OnActiveTrapChanged; 

        protected override void Awake()
        {
            base.Awake();

            _trapsCounts =
                ResourceSystem.Instance.TrapsManagerSO.baseTrapsCounts
                    .ToDictionary(t => t.Key, t => t.Value);
        }

        private void Update()
        {
#if DEBUG
            if (Input.GetKeyDown(KeyCode.T))
            {
                if (IsTrapSelected)
                {
                    SpawnTrap(ActiveTrap, Vector3.back);
                }
            }
#endif
        }

        public void ToggleTrap(TrapType trapType)
        {
            if (IsTrapSelected)
            {
                if (trapType == ActiveTrap)
                {
                    IsTrapSelected = false;
                    ActiveTrap = TrapType.None;
                }
                else
                {
                    ActiveTrap = trapType;
                }
            }
            else
            {
                IsTrapSelected = true;
                ActiveTrap = trapType;
            }
            
            OnActiveTrapChanged?.Invoke();
        }

        public int GetTrapCount(TrapType trapType)
        {
            return _trapsCounts[trapType];
        }

        public int GetTrapMaxCount(TrapType trapType)
        {
            return ResourceSystem.Instance.TrapsManagerSO.maxTrapsCounts[trapType];
        }

        public bool TryIncreaseTrapCount(TrapType trapType, int count)
        {
            int maxTrapCount = GetTrapMaxCount(trapType);
            int trapCount = GetTrapCount(trapType);

            if (trapCount >= maxTrapCount)
            {
                return false;
            }

            _trapsCounts[trapType] = Mathf.Min(trapCount + count, maxTrapCount);
            OnTrapCountChanged?.Invoke(trapType);

            return true;
        }

        public void SpawnTrap(TrapType type, Vector3 position)
        {
            var trapSO = ResourceSystem.Instance.GetTrapSO(type);

            var spawned = Instantiate(trapSO.Prefab, position, Quaternion.identity, transform);

            _trapsCounts[type]--;
            OnTrapCountChanged?.Invoke(type);
        }

        public bool TrySpawnTrap(TrapType type, Vector3 position)
        {
            if (GetTrapCount(type) <= 0)
            {
                return false;
            }

            SpawnTrap(type, position);
            return true;
        }

        public void SelectTrap(TrapType trapType)
        {
            IsTrapSelected = true;
            ActiveTrap = trapType;
        }

        public void DeselectTrap()
        {
            IsTrapSelected = false;
            ActiveTrap = TrapType.None;
        }
    }
}