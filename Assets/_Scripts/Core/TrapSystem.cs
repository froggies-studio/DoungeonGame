using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using UnityEngine;

namespace _Scripts.Core
{
    public class TrapSystem : MonoBehaviour
    {
        [SerializeField] private TrapInfoSO[] trapInfo;

        public event Action<TrapInfoSO[]> OnTrapInfoChanged;
        private Dictionary<TrapType, TrapInfoSO> _trapDictionary;
        private Dictionary<TrapType, Transform> _trapPreviews;

        private void Awake()
        {
            _trapDictionary = trapInfo.ToDictionary(t => t.TrapType, t => t);
            InitTrapPreviews();
        }

        private void InitTrapPreviews()
        {
            _trapPreviews = new();
            foreach (var (trapType, trapInfoSO) in _trapDictionary)
            {
                var preview = Instantiate(trapInfoSO.TrapPreview, Vector3.zero, Quaternion.identity);
                _trapPreviews.Add(trapType, preview.transform);
                DisableTrapPreview(trapType);
            }
        }

        private void Start()
        {
            OnTrapInfoChanged?.Invoke(trapInfo);
        }

        public void SpawnTrap(Vector2 position, TrapType trapType)
        {
            var trap = _trapDictionary[trapType];
            SpawnTrap(position, trap);
        }

        public void SpawnTrap(Vector2 position, TrapInfoSO trap)
        {
            Instantiate(trap.Prefab, position, Quaternion.identity);
        }

        public Transform GetTrapPreview(TrapType trapType)
        {
            return _trapPreviews[trapType];
        }

        public void EnableTrapPreview(TrapType trapType)
        {
            _trapPreviews[trapType].gameObject.SetActive(true);
        }

        public void DisableTrapPreview(TrapType trapType)
        {
            _trapPreviews[trapType].gameObject.SetActive(false);
        }
    }
}