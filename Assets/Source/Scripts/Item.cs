using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Source.Scripts
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private ParticleSystem _crash;
        [SerializeField] private ParticleSystem _coins;
        [SerializeField] private List<GameObject> _loots;

        private Vector3 _pointSpawnCrashAndCoins = new Vector3(0, 1, 0);
        private int _maxHealth = 1;
        
        public event UnityAction ItemDied;
        public event UnityAction BulletHitting;

        public int Health => _health;

        private void Start()
        {
            _health = _maxHealth;
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;

            if (_health <= 0)
            {
                Death();
            }
            else
            {
                BulletHitting?.Invoke();
            }
        }

        private void Death()
        {
            Instantiate(_crash, transform.position + _pointSpawnCrashAndCoins, Quaternion.identity);
            Instantiate(_coins, transform.position + _pointSpawnCrashAndCoins, Quaternion.identity);

            foreach (var item in _loots)
            {
                Instantiate(item, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
            ItemDied?.Invoke();
        }
    }
}