using System;
using System.Collections.Generic;
using System.Linq;
using _Scripts.Core;
using _Scripts.Helpers;
using _Scripts.Systems;
using _Scripts.Traps;
using UnityEngine;

namespace _Scripts.Managers
{
    public class TrapsPreviewCursorManager : StaticInstance<TrapsPreviewCursorManager>
    {
        private Dictionary<TrapType, SimpleTrapPreview> _trapPreviews;
        private bool _previewSelected;
        private SimpleTrapPreview _currentTrapPreview;
        private Camera _mainCamera;

        protected override void Awake()
        {
            base.Awake();

            _mainCamera = Camera.main;

            _trapPreviews = ResourceSystem.Instance.TrapsSO
                .ToDictionary(t => t.TrapType,
                    t => Instantiate(t.TrapPreview, Vector3.zero, Quaternion.identity, transform));
        }

        private void Start()
        {
            TrapsManager.Instance.OnActiveTrapChanged += TrapsManagerOnActiveTrapChanged;
        }

        private void Update()
        {
            if (!_previewSelected) return;

            var cursorPosition = GetCursorPosition();
            _currentTrapPreview.transform.position =
                Vector3.Lerp(cursorPosition, _currentTrapPreview.transform.position, Time.deltaTime);

            if (Input.GetMouseButtonDown(0) && _currentTrapPreview.IsPlacementValid && !Helpers.Helpers.IsOverUI())
            {
                TrapsManager.Instance.TrySpawnTrap(_currentTrapPreview.TrapType,
                    _currentTrapPreview.transform.position);
            }

            if (Input.GetMouseButtonDown(1))
            {
                TrapsManager.Instance.ToggleTrap(TrapsManager.Instance.ActiveTrap);
            }
        }

        private Vector2 GetCursorPosition()
        {
            return _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        private void TrapsManagerOnActiveTrapChanged()
        {
            if (!TrapsManager.Instance.IsTrapSelected)
            {
                foreach (var (_, value) in _trapPreviews)
                {
                    value.gameObject.SetActive(false);
                }

                _previewSelected = false;
            }
            else
            {
                foreach (var (_, value) in _trapPreviews)
                {
                    value.gameObject.SetActive(false);
                }

                var currentTrapPreview = _trapPreviews[TrapsManager.Instance.ActiveTrap];
                currentTrapPreview.gameObject.SetActive(true);
                _currentTrapPreview = currentTrapPreview;
                _currentTrapPreview.transform.position = GetCursorPosition();

                _previewSelected = true;
            }
        }
    }
}