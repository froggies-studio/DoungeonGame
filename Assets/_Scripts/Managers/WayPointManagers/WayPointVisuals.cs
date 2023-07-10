using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Managers.WayPointManagers
{
    public class WayPointVisuals : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;
        private List<Transform> _points;

        private void Start()
        {
            GatherPoints();
            DrawLine();
        }

        private void GatherPoints()
        {
            _points = WayPointManager.Instance.Points;
        }

        private void DrawLine()
        {
            lineRenderer.positionCount = _points.Count;
            for (int i = 0; i < _points.Count; i++)
            {
                lineRenderer.SetPosition(i, _points[i].position);
            }
        }
    }
}