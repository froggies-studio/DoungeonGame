#region

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#endregion

namespace _Scripts.Core
{
    public class TrapSystem : MonoBehaviour
    {
        [SerializeField] private TrapInfoSO[] trapInfo;
        [SerializeField] private TrapCount[] trapCounts;
        private Dictionary<TrapType, int> _trapCounts;

        // public event Action<TrapInfoSO[]> OnTrapInfoChanged;
        private Dictionary<TrapType, TrapInfoSO> _trapDictionary;
        private Dictionary<TrapType, Transform> _trapPreviews;

        public static TrapSystem Instance { get; private set; }

        public TrapInfoSO[] TrapInfos => trapInfo;

        private void Awake()
        {
            Instance = this;

            _trapDictionary = trapInfo.ToDictionary(t => t.TrapType, t => t);
            _trapCounts = trapCounts.ToDictionary(t => t.trapType, t => t.baseCount);
            InitTrapPreviews();
        }

        private void Start()
        {
            // OnTrapInfoChanged?.Invoke(trapInfo);
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

        public bool TryUseTrapAt(TrapType trapType, Vector2 position)
        {
            if (_trapCounts[trapType] <= 0)
            {
                return false;
            }

            bool trapUsed = false;
            switch (trapType)
            {
                case TrapType.None:
                    Debug.LogError($"Can't use {TrapType.None}");
                    break;
                case TrapType.Chest:
                    var trap = _trapDictionary[trapType];
                    SpawnTrap(position, trap);
                    trapUsed = true;
                    break;
                case TrapType.Key:
                    RaycastHit hit;
                    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out hit))
                    {
                        Debug.Log("hit something");
                        if (hit.collider.gameObject.TryGetComponent(out Door door))
                        {
                            Debug.Log("Door clicked");
                        }
                    }

                    trapUsed = true;

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(trapType), trapType, null);
            }

            if (trapUsed)
            {
                _trapCounts[trapType] -= 1;
                OnTrapCountChanged?.Invoke(trapType, _trapCounts[trapType]);
            }

            return trapUsed;
        }

        void A()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {Debug.Log("HitSomething");
                    if (hit.transform.name == "MyObjectName")
                    {
                        print("My object is clicked by mouse");
                    }
                }
            }
        }

        public event Action<TrapType, int> OnTrapCountChanged;

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

        [Serializable]
        private struct TrapCount
        {
            public TrapType trapType;
            public int baseCount;
        }

        public int GetTrapCount(TrapType trapType)
        {
            return _trapCounts[trapType];
        }
    }
}