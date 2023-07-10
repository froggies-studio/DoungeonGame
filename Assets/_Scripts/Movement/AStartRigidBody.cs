// using System;
// using JetBrains.Annotations;
// using Pathfinding;
// using UnityEngine;
// using UnityEngine.Serialization;
//
// namespace Movement
// {
//     public class AStartRigidBody : MonoBehaviour
//     {
//         [SerializeField] [CanBeNull] private Transform target;
//         [SerializeField] private float maxSpeed;
//         [SerializeField] private float acceleration;
//         [SerializeField] private float nextWaypointDistance = 3f;
//         
//         private float _maxSpeedSqr;
//         
//         private Path _path;
//         private int _currentWaypoint = 0;
//         private bool _reachedEndOfPath = false;
//         
//         private Seeker _seeker;
//         private Rigidbody2D _rigidbody2D;
//         
//         private void Start()
//         {
//             _maxSpeedSqr = maxSpeed * maxSpeed;
//             _seeker = GetComponent<Seeker>();
//             _rigidbody2D = GetComponent<Rigidbody2D>();
//             
//             if(target != null)
//                 _seeker.StartPath(transform.position, target.position, OnPathComplete);
//             
//             InvokeRepeating(nameof(UpdatePath), 0f, .5f);
//         }
//
//         public void SetTarget(Transform point)
//         {
//             target = point;
//         }
//         
//         private void UpdatePath()
//         {
//             if (_seeker.IsDone() && target != null)
//             {
//                 _seeker.StartPath(transform.position, target.position, OnPathComplete);
//             }
//         }
//         
//         private void OnPathComplete(Path p)
//         {
//             if (p.error) 
//                 return;
//             
//             _path = p;
//             _currentWaypoint = 0;
//         }
//
//         private void FixedUpdate()
//         {
//             if (_path == null) 
//                 return;
//
//             if (_currentWaypoint >= _path.vectorPath.Count)
//             {
//                 _reachedEndOfPath = true;
//                 return;
//             }
//             else
//             {
//                 _reachedEndOfPath = false;
//             }
//             
//             Vector2 direction = ((Vector2)_path.vectorPath[_currentWaypoint] - _rigidbody2D.position).normalized;
//             Vector2 force = direction * acceleration * Time.deltaTime;
//             
//             _rigidbody2D.AddForce(force, ForceMode2D.Force);
//             
//             float distance = Vector2.Distance(_rigidbody2D.position, _path.vectorPath[_currentWaypoint]);
//             if (distance < nextWaypointDistance)
//             {
//                 _currentWaypoint++;
//             }
//             
//             if(_rigidbody2D.velocity.sqrMagnitude > _maxSpeedSqr)
//                 _rigidbody2D.velocity = _rigidbody2D.velocity.normalized * maxSpeed;
//         }
//     }
// }