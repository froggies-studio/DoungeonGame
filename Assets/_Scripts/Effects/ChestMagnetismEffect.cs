#region

using System.Collections.Generic;
using UnityEngine;

#endregion

namespace _Scripts.Effects
{
    public class ChestMagnetismEffect : MonoBehaviour
    {
        private const string COIN_TAG = "Coin";

        [SerializeField] private LineRenderer linePrefab;

        private HashSet<Connection> _coins = new ();

        private void Update()
        {
            foreach (var connection in _coins)
            {
                if (connection.Coin == null)
                {
                    connection.DestroyLine();
                    _coins.Remove(connection);
                    continue;
                }
                
                connection.Line.SetPosition(0, transform.position);
                connection.Line.SetPosition(1, connection.Coin.transform.position);
            }
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.CompareTag(COIN_TAG))
                _coins.Add(CreateConnection(other.gameObject));
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if(other.gameObject.CompareTag(COIN_TAG))
            {
                bool valueExists =
                    _coins.TryGetValue(new Connection(other.gameObject, null), out Connection connection);
                Debug.Assert(valueExists);
                connection.DestroyLine();
                _coins.Remove(connection);
            }
        }
        
        private Connection CreateConnection(GameObject coin)
        {
            var line = Instantiate(linePrefab.gameObject, transform).GetComponent<LineRenderer>();
            return new Connection(coin, line);
        }

        private struct Connection
        {
            private GameObject _coin;
            private LineRenderer _line;

            public GameObject Coin => _coin;

            public LineRenderer Line => _line;

            public Connection(GameObject coin, LineRenderer line)
            {
                _coin = coin;
                _line = line;
            }
            
            public void DestroyLine()
            {
                Destroy(_line);
            }

            public bool Equals(Connection other)
            {
                return Equals(_coin, other._coin);
            }

            public override bool Equals(object obj)
            {
                return obj is Connection other && Equals(other);
            }

            public override int GetHashCode()
            {
                return (_coin != null ? _coin.GetHashCode() : 0);
            }
        }
    }
}